using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Core.Utility.Spiders
{
    public class VirtualWebBrowser
    {
        private class ActionEvent
        {
            public Action<WebBrowser> Action { set; get; }
            public Func<WebBrowser, bool> ConditionEnd { set; get; }
            public Func<WebBrowser, bool> ConditionContinue { set; get; }
        }

        private List<ActionEvent> steps = new List<ActionEvent>();
        public void AddStep(Action<WebBrowser> action, Func<WebBrowser, bool> conditionEnd = null, Func<WebBrowser, bool> conditionContinue = null)
        {
            steps.Add(new ActionEvent { Action = action, ConditionEnd = conditionEnd, ConditionContinue = conditionContinue });
        }

        private static bool isRunning = false;

        public async Task<bool> Run()
        {
            if (steps.Count == 0) return false;

            var tcsThread = new TaskCompletionSource<bool>();
            Thread th = null;
            
            th = new Thread(() =>
            {
                while(isRunning)
                {
                    Thread.Sleep(100);
                }
                isRunning = true;
                var stepIndex = 0;

                using (var web = new WebBrowser())
                {
                    web.ScriptErrorsSuppressed = true;
                    web.AllowNavigation = true;
                    web.Disposed += (s, e) => 
                    {
                        Application.ExitThread();
                    };
                    web.DocumentCompleted += (s, e) =>
                    {
                        // Kiểm tra nếu mất mạng thì cũng cho kết thúc luôn
                        if (web.DocumentTitle == "Navigation Canceled" || web.DocumentTitle == "This page can’t be displayed")
                        {
                            Application.ExitThread();
                            tcsThread.TrySetResult(false);
                            return;
                        }
                        // Kiểm tra nếu mất mạng thì cũng cho kết thúc luôn

                        var end = steps[stepIndex].ConditionEnd;
                        var @continue = steps[stepIndex].ConditionContinue;

                        if (end == null && @continue == null)
                        {
                            Application.ExitThread();
                            tcsThread.TrySetResult(true);
                            return;
                        }

                        if (end(web)) // Nếu web lấy đc không thỏa mãn nội dung lấy được. Mà trang
                        {
                            if (@continue == null || !@continue(web)) // Mà trang có thể bị reload thì có thể sẽ cho load tiếp
                            {
                                Application.ExitThread();
                                tcsThread.TrySetResult(true);
                            }
                            return;
                        }

                        stepIndex++;

                        if (stepIndex <= steps.Count - 1)
                        {
                            steps[stepIndex].Action(web);
                            return;
                        }

                        Application.ExitThread();
                        tcsThread.TrySetResult(true);
                    };

                    steps[stepIndex].Action(web);
                    Application.Run();
                }
            });
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
            var taskDelay = Task.Delay(60000);

            var taskDone = await Task.WhenAny(tcsThread.Task, taskDelay);
            isRunning = false;
            if(taskDone != tcsThread.Task)
            {
                th.Abort();
                tcsThread.TrySetResult(false);
                return false;
            }
            return true;
        }
    }

    public static class WebBrowserExt
    {
        public static HtmlElement FindByAttribute(this WebBrowser webBrowser, string tagName, string attrName, string attrValue)
        {
            var aElements = webBrowser.Document.GetElementsByTagName(tagName).Cast<HtmlElement>();
            return aElements.FirstOrDefault(c => c.GetAttribute(attrName) == attrValue);
        }
        public static HtmlElement FindAByHref(this WebBrowser webBrowser, string href)
        {
            return webBrowser.FindByAttribute("a", "href", href);
        }
    }

    //public class VirtualWebBrowser
    //{
    //    private WebBrowser web = null;

    //    private async Task<bool> Step(Action<WebBrowser> action, int millisecondsDelay = 0, Func<WebBrowser, bool> loadDone = null)
    //    {
    //        TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
    //        WebBrowserDocumentCompletedEventHandler handler = (s, e) =>
    //        {
    //            if (loadDone == null || loadDone(web))
    //            {
    //                tcs.TrySetResult(true);
    //            }
    //        };

    //        var cts = new CancellationTokenSource((int)TimeSpan.FromMinutes(3).TotalMilliseconds);
    //        var navigationCts = CancellationTokenSource.CreateLinkedTokenSource(cts.Token);
    //        navigationCts.CancelAfter((int)TimeSpan.FromSeconds(30).TotalMilliseconds);
    //        var navigationToken = navigationCts.Token;

    //        using (navigationToken.Register(() => tcs.TrySetCanceled(), useSynchronizationContext: true))
    //        {
    //            web.DocumentCompleted += handler;
    //            try
    //            {
    //                action(web);
    //                await tcs.Task; // wait for DocumentCompleted
    //            }
    //            finally
    //            {
    //                web.DocumentCompleted -= handler;
    //            }
    //        }
    //        return tcs.Task.Result;
    //    }

    //    public HtmlElement FindByAttribute(string tagName, string attrName, string attrValue)
    //    {
    //        var aElements = web.Document.GetElementsByTagName(tagName).Cast<HtmlElement>();
    //        return aElements.FirstOrDefault(c => c.GetAttribute(attrName) == attrValue);
    //    }
    //    public HtmlElement FindAByHref(string href)
    //    {
    //        return FindByAttribute("a", "href", href);
    //    }

    //    private List<Func<Task<bool>>> steps = new List<Func<Task<bool>>>();

    //    public void AddStep(Action<WebBrowser> action, int millisecondsDelay = 0, Func<WebBrowser, bool> loadDone = null)
    //    {
    //        Func<Task<bool>> func = () => Step(action, millisecondsDelay, loadDone);
    //        steps.Add(func);
    //    }

    //    private async Task<object> Run()
    //    {


    //        using (var apartment = new MessageLoopApartment())
    //        {
    //            web = apartment.Invoke(() => new WebBrowser());
    //            try
    //            {
    //                for (var i = 0; i < steps.Count; i++)
    //                {
    //                    var cts = new CancellationTokenSource((int)TimeSpan.FromMinutes(3).TotalMilliseconds);
    //                    var navigationCts = CancellationTokenSource.CreateLinkedTokenSource(cts.Token);
    //                    navigationCts.CancelAfter((int)TimeSpan.FromSeconds(30).TotalMilliseconds);
    //                    var navigationToken = navigationCts.Token;

    //                    var step = steps[i]();
    //                    //var step = steps //apartment.Run(steps[i], new CancellationToken { });
    //                    await step;
    //                    if (!step.Result)
    //                        break;
    //                }
    //            }
    //            finally
    //            {
    //                apartment.Invoke(() => web.Dispose());
    //            }
    //        }
    //        return true;
    //    }

    //    public void Start()
    //    {
    //        Run().Wait();
    //    }

    //    public class MessageLoopApartment : IDisposable
    //    {
    //        Thread _thread; // the STA thread

    //        TaskScheduler _taskScheduler; // the STA thread's task scheduler

    //        public TaskScheduler TaskScheduler { get { return _taskScheduler; } }

    //        /// <summary>MessageLoopApartment constructor</summary>
    //        public MessageLoopApartment()
    //        {
    //            var tcs = new TaskCompletionSource<TaskScheduler>();

    //            // start an STA thread and gets a task scheduler
    //            _thread = new Thread(startArg =>
    //            {
    //                EventHandler idleHandler = null;

    //                idleHandler = (s, e) =>
    //                {
    //                    // handle Application.Idle just once
    //                    Application.Idle -= idleHandler;
    //                    // return the task scheduler
    //                    tcs.SetResult(TaskScheduler.FromCurrentSynchronizationContext());
    //                };

    //                // handle Application.Idle just once
    //                // to make sure we're inside the message loop
    //                // and SynchronizationContext has been correctly installed
    //                Application.Idle += idleHandler;
    //                Application.Run();
    //            });

    //            _thread.SetApartmentState(ApartmentState.STA);
    //            _thread.IsBackground = true;
    //            _thread.Start();
    //            _taskScheduler = tcs.Task.Result;
    //        }

    //        /// <summary>shutdown the STA thread</summary>
    //        public void Dispose()
    //        {
    //            if (_taskScheduler != null)
    //            {
    //                var taskScheduler = _taskScheduler;
    //                _taskScheduler = null;

    //                // execute Application.ExitThread() on the STA thread
    //                Task.Factory.StartNew(
    //                    () => Application.ExitThread(),
    //                    CancellationToken.None,
    //                    TaskCreationOptions.None,
    //                    taskScheduler).Wait();

    //                _thread.Join();
    //                _thread = null;
    //            }
    //        }

    //        /// <summary>Task.Factory.StartNew wrappers</summary>
    //        public void Invoke(Action action)
    //        {
    //            Task.Factory.StartNew(action,
    //                CancellationToken.None, TaskCreationOptions.None, _taskScheduler).Wait();
    //        }

    //        public TResult Invoke<TResult>(Func<TResult> action)
    //        {
    //            return Task.Factory.StartNew(action,
    //                CancellationToken.None, TaskCreationOptions.None, _taskScheduler).Result;
    //        }

    //        public Task Run(Action action, CancellationToken token)
    //        {
    //            return Task.Factory.StartNew(action, token, TaskCreationOptions.None, _taskScheduler);
    //        }

    //        public Task<TResult> Run<TResult>(Func<TResult> action, CancellationToken token)
    //        {
    //            return Task.Factory.StartNew(action, token, TaskCreationOptions.None, _taskScheduler);
    //        }

    //        public Task Run(Func<Task> action, CancellationToken token)
    //        {
    //            return Task.Factory.StartNew(action, token, TaskCreationOptions.None, _taskScheduler).Unwrap();
    //        }

    //        public Task<TResult> Run<TResult>(Func<Task<TResult>> action, CancellationToken token)
    //        {
    //            return Task.Factory.StartNew(action, token, TaskCreationOptions.None, _taskScheduler).Unwrap();
    //        }
    //    }
    //}

    /////// <summary>
    /////// WebBrowserExt - WebBrowser extensions
    /////// by Noseratio - https://stackoverflow.com/a/22262976/1768303
    /////// https://stackoverflow.com/questions/22239357/how-to-cancel-task-await-after-a-timeout-period/22262976#22262976
    /////// </summary>
    ////public static class WebBrowserExt
    ////{
    ////    const int POLL_DELAY = 500;

    ////    // navigate and download 
    ////    public static async Task<bool> NavigateAsync(this WebBrowser webBrowser, CancellationToken token, Action<WebBrowser> action, Func<WebBrowser, bool> loadDone = null)
    ////    {
    ////        // navigate and await DocumentCompleted
    ////        var tcs = new TaskCompletionSource<bool>();
    ////        WebBrowserDocumentCompletedEventHandler handler = (s, arg) =>
    ////        {
    ////            if (loadDone == null || loadDone(webBrowser))
    ////                tcs.TrySetResult(true);
    ////        };

    ////        using (token.Register(() => tcs.TrySetCanceled(), useSynchronizationContext: true))
    ////        {
    ////            webBrowser.DocumentCompleted += handler;
    ////            try
    ////            {                    
    ////                action(webBrowser);
    ////                await tcs.Task; // wait for DocumentCompleted
    ////            }
    ////            finally
    ////            {
    ////                webBrowser.DocumentCompleted -= handler;
    ////            }
    ////        }

    ////        // get the root element
    ////        var documentElement = webBrowser.Document.GetElementsByTagName("html")[0];

    ////        // poll the current HTML for changes asynchronosly
    ////        var html = documentElement.OuterHtml;
    ////        while (true)
    ////        {
    ////            // wait asynchronously, this will throw if cancellation requested
    ////            await Task.Delay(POLL_DELAY, token);

    ////            // continue polling if the WebBrowser is still busy
    ////            if (webBrowser.IsBusy)
    ////                continue;

    ////            var htmlNow = documentElement.OuterHtml;
    ////            if (html == htmlNow)
    ////                break; // no changes detected, end the poll loop

    ////            html = htmlNow;
    ////        }

    ////        // consider the page fully rendered 
    ////        token.ThrowIfCancellationRequested();
    ////        //return tcs.Task.Result;
    ////        return true;
    ////    }

    ////    public static HtmlElement FindByAttribute(this WebBrowser webBrowser, string tagName, string attrName, string attrValue)
    ////    {
    ////        var aElements = webBrowser.Document.GetElementsByTagName(tagName).Cast<HtmlElement>();
    ////        return aElements.FirstOrDefault(c => c.GetAttribute(attrName) == attrValue);
    ////    }
    ////    public static HtmlElement FindAByHref(this WebBrowser webBrowser, string href)
    ////    {
    ////        return webBrowser.FindByAttribute("a", "href", href);
    ////    }

    ////    //// enable HTML5 (assuming we're running IE10+)
    ////    //// more info: https://stackoverflow.com/a/18333982/1768303
    ////    //public static void SetFeatureBrowserEmulation()
    ////    //{
    ////    //    if (System.ComponentModel.LicenseManager.UsageMode != System.ComponentModel.LicenseUsageMode.Runtime)
    ////    //        return;
    ////    //    var appName = System.IO.Path.GetFileName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
    ////    //    Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION",
    ////    //        appName, 10000, RegistryValueKind.DWord);
    ////    //}
    ////}

    ////public class VirtualWebBrowser2
    ////{
    ////    public class MessageLoopApartment : IDisposable
    ////    {
    ////        Thread _thread; // the STA thread

    ////        TaskScheduler _taskScheduler; // the STA thread's task scheduler

    ////        public TaskScheduler TaskScheduler { get { return _taskScheduler; } }

    ////        /// <summary>MessageLoopApartment constructor</summary>
    ////        public MessageLoopApartment()
    ////        {
    ////            var tcs = new TaskCompletionSource<TaskScheduler>();

    ////            // start an STA thread and gets a task scheduler
    ////            _thread = new Thread(startArg =>
    ////            {
    ////                EventHandler idleHandler = null;

    ////                idleHandler = (s, e) =>
    ////                {
    ////                    // handle Application.Idle just once
    ////                    Application.Idle -= idleHandler;
    ////                    // return the task scheduler
    ////                    tcs.SetResult(TaskScheduler.FromCurrentSynchronizationContext());
    ////                };

    ////                // handle Application.Idle just once
    ////                // to make sure we're inside the message loop
    ////                // and SynchronizationContext has been correctly installed
    ////                Application.Idle += idleHandler;
    ////                Application.Run();
    ////            });

    ////            _thread.SetApartmentState(ApartmentState.STA);
    ////            _thread.IsBackground = true;
    ////            _thread.Start();
    ////            _taskScheduler = tcs.Task.Result;
    ////        }

    ////        /// <summary>shutdown the STA thread</summary>
    ////        public void Dispose()
    ////        {
    ////            if (_taskScheduler != null)
    ////            {
    ////                var taskScheduler = _taskScheduler;
    ////                _taskScheduler = null;

    ////                // execute Application.ExitThread() on the STA thread
    ////                Task.Factory.StartNew(
    ////                    () => Application.ExitThread(),
    ////                    CancellationToken.None,
    ////                    TaskCreationOptions.None,
    ////                    taskScheduler).Wait();

    ////                _thread.Join();
    ////                _thread = null;
    ////            }
    ////        }

    ////        /// <summary>Task.Factory.StartNew wrappers</summary>
    ////        public void Invoke(Action action)
    ////        {
    ////            Task.Factory.StartNew(action,
    ////                CancellationToken.None, TaskCreationOptions.None, _taskScheduler).Wait();
    ////        }

    ////        public TResult Invoke<TResult>(Func<TResult> action)
    ////        {
    ////            return Task.Factory.StartNew(action,
    ////                CancellationToken.None, TaskCreationOptions.None, _taskScheduler).Result;
    ////        }

    ////        public Task Run(Action action, CancellationToken token)
    ////        {
    ////            return Task.Factory.StartNew(action, token, TaskCreationOptions.None, _taskScheduler);
    ////        }

    ////        public Task<TResult> Run<TResult>(Func<TResult> action, CancellationToken token)
    ////        {
    ////            return Task.Factory.StartNew(action, token, TaskCreationOptions.None, _taskScheduler);
    ////        }

    ////        public Task Run(Func<Task> action, CancellationToken token)
    ////        {
    ////            return Task.Factory.StartNew(action, token, TaskCreationOptions.None, _taskScheduler).Unwrap();
    ////        }

    ////        public Task<TResult> Run<TResult>(Func<Task<TResult>> action, CancellationToken token)
    ////        {
    ////            return Task.Factory.StartNew(action, token, TaskCreationOptions.None, _taskScheduler).Unwrap();
    ////        }
    ////    }

    ////    private List<Pair<Action<WebBrowser>, Func<WebBrowser, bool>>> steps = new List<Pair<Action<WebBrowser>, Func<WebBrowser, bool>>>();

    ////    private async Task Run(CancellationToken token)
    ////    {
    ////        using (var apartment = new MessageLoopApartment())
    ////        {
    ////            // create WebBrowser inside MessageLoopApartment
    ////            var webBrowser = apartment.Invoke(() => new WebBrowser());
    ////            try
    ////            {
    ////                //action(webBrowser);

    ////                foreach(var step in steps)
    ////                {
    ////                    // cancel in 30s or when the main token is signalled
    ////                    var navigationCts = CancellationTokenSource.CreateLinkedTokenSource(token);
    ////                    navigationCts.CancelAfter((int)TimeSpan.FromSeconds(30).TotalMilliseconds);
    ////                    var navigationToken = navigationCts.Token;

    ////                    // run the navigation task inside MessageLoopApartment
    ////                    var result = await apartment.Run(() =>
    ////                        webBrowser.NavigateAsync(navigationToken, step.T1, step.T2), navigationToken);

    ////                    if (!result) break;
    ////                }

    ////                //foreach (var url in urls)
    ////                //{
    ////                //    Console.WriteLine("URL:\n" + url);

    ////                //    // cancel in 30s or when the main token is signalled
    ////                //    var navigationCts = CancellationTokenSource.CreateLinkedTokenSource(token);
    ////                //    navigationCts.CancelAfter((int)TimeSpan.FromSeconds(30).TotalMilliseconds);
    ////                //    var navigationToken = navigationCts.Token;

    ////                //    // run the navigation task inside MessageLoopApartment
    ////                //    string html = await apartment.Run(() =>
    ////                //        webBrowser.NavigateAsync(url, navigationToken), navigationToken);

    ////                //    Console.WriteLine("HTML:\n" + html);
    ////                //}
    ////            }
    ////            finally
    ////            {
    ////                // dispose of WebBrowser inside MessageLoopApartment
    ////                apartment.Invoke(() => webBrowser.Dispose());
    ////            }
    ////        }
    ////    }

    ////    public void AddStep(Action<WebBrowser> action , Func<WebBrowser, bool> condition)
    ////    {
    ////        steps.Add(new Pair<Action<WebBrowser>, Func<WebBrowser, bool>> { T1 = action, T2 = condition });
    ////    }

    ////    public void Start()
    ////    {
    ////        var cts = new CancellationTokenSource((int)TimeSpan.FromMinutes(3).TotalMilliseconds);
    ////        var task = Run(cts.Token);
    ////        task.Wait();
    ////    }
    ////}

    //public class ProgramT
    //{
    //    // by Noseratio - https://stackoverflow.com/a/22262976/1768303

    //    // main logic
    //    static async Task ScrapSitesAsync(string[] urls, CancellationToken token)
    //    {
    //        using (var apartment = new MessageLoopApartment())
    //        {
    //            // create WebBrowser inside MessageLoopApartment
    //            var webBrowser = apartment.Invoke(() => new WebBrowser());
    //            webBrowser.ScriptErrorsSuppressed = true;
    //            webBrowser.AllowNavigation = true;
    //            try
    //            {
    //                foreach (var url in urls)
    //                {
    //                    Console.WriteLine("URL:\n" + url);

    //                    // cancel in 30s or when the main token is signalled
    //                    var navigationCts = CancellationTokenSource.CreateLinkedTokenSource(token);
    //                    navigationCts.CancelAfter((int)TimeSpan.FromSeconds(300).TotalMilliseconds);
    //                    var navigationToken = navigationCts.Token;

    //                    // run the navigation task inside MessageLoopApartment
    //                    string html = await apartment.Run(() =>
    //                        webBrowser.NavigateAsync(url, navigationToken), navigationToken);

    //                    Console.WriteLine("HTML:\n" + html);
    //                }
    //            }
    //            finally
    //            {
    //                // dispose of WebBrowser inside MessageLoopApartment
    //                apartment.Invoke(() => webBrowser.Dispose());
    //            }
    //        }
    //    }

    //    // entry point
    //    public static void Main(params string[] args)
    //    {
    //        try
    //        {
    //            WebBrowserExt.SetFeatureBrowserEmulation(); // enable HTML5

    //            var cts = new CancellationTokenSource((int)TimeSpan.FromMinutes(3).TotalMilliseconds);

    //            var task = ScrapSitesAsync(
    //                new[] { "http://24h.com.vn" },
    //                cts.Token);

    //            task.Wait();

    //            Console.WriteLine("Press Enter to exit...");
    //            Console.ReadLine();
    //        }
    //        catch (Exception ex)
    //        {
    //            while (ex is AggregateException && ex.InnerException != null)
    //                ex = ex.InnerException;
    //            Console.WriteLine(ex.Message);
    //            Environment.Exit(-1);
    //        }
    //    }
    //}

    ///// <summary>
    ///// WebBrowserExt - WebBrowser extensions
    ///// by Noseratio - https://stackoverflow.com/a/22262976/1768303
    ///// </summary>
    //public static class WebBrowserExt
    //{
    //    const int POLL_DELAY = 500;

    //    // navigate and download 
    //    public static async Task<string> NavigateAsync(this WebBrowser webBrowser, string url, CancellationToken token)
    //    {
    //        // navigate and await DocumentCompleted
    //        var tcs = new TaskCompletionSource<bool>();
    //        WebBrowserDocumentCompletedEventHandler handler = (s, arg) =>
    //        {
    //            tcs.TrySetResult(true);
    //            var c = 1;
    //            var a = c / 1;
    //        };

    //        using (token.Register(() => tcs.TrySetCanceled(), useSynchronizationContext: true))
    //        {
    //            webBrowser.DocumentCompleted += handler;
    //            try
    //            {
    //                webBrowser.Navigate(url);
    //                await tcs.Task; // wait for DocumentCompleted
    //            }
    //            finally
    //            {
    //                webBrowser.DocumentCompleted -= handler;
    //            }
    //        }

    //        // get the root element
    //        var documentElement = webBrowser.Document.GetElementsByTagName("html")[0];

    //        // poll the current HTML for changes asynchronosly
    //        var html = documentElement.OuterHtml;
    //        while (true)
    //        {
    //            // wait asynchronously, this will throw if cancellation requested
    //            await Task.Delay(POLL_DELAY, token);

    //            // continue polling if the WebBrowser is still busy
    //            if (webBrowser.IsBusy)
    //                continue;

    //            var htmlNow = documentElement.OuterHtml;
    //            if (html == htmlNow)
    //                break; // no changes detected, end the poll loop

    //            html = htmlNow;
    //        }

    //        // consider the page fully rendered 
    //        token.ThrowIfCancellationRequested();
    //        return html;
    //    }

    //    // enable HTML5 (assuming we're running IE10+)
    //    // more info: https://stackoverflow.com/a/18333982/1768303
    //    public static void SetFeatureBrowserEmulation()
    //    {
    //        //if (System.ComponentModel.LicenseManager.UsageMode != System.ComponentModel.LicenseUsageMode.Runtime)
    //        //    return;
    //        //var appName = System.IO.Path.GetFileName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
    //        //Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION",
    //        //    appName, 10000, RegistryValueKind.DWord);
    //    }
    //}

    ///// <summary>
    ///// MessageLoopApartment
    ///// STA thread with message pump for serial execution of tasks
    ///// by Noseratio - https://stackoverflow.com/a/22262976/1768303
    ///// </summary>
    //public class MessageLoopApartment : IDisposable
    //{
    //    Thread _thread; // the STA thread

    //    TaskScheduler _taskScheduler; // the STA thread's task scheduler

    //    public TaskScheduler TaskScheduler { get { return _taskScheduler; } }

    //    /// <summary>MessageLoopApartment constructor</summary>
    //    public MessageLoopApartment()
    //    {
    //        var tcs = new TaskCompletionSource<TaskScheduler>();

    //        // start an STA thread and gets a task scheduler
    //        _thread = new Thread(startArg =>
    //        {
    //            EventHandler idleHandler = null;

    //            idleHandler = (s, e) =>
    //            {
    //                // handle Application.Idle just once
    //                Application.Idle -= idleHandler;
    //                // return the task scheduler
    //                tcs.SetResult(TaskScheduler.FromCurrentSynchronizationContext());
    //            };

    //            // handle Application.Idle just once
    //            // to make sure we're inside the message loop
    //            // and SynchronizationContext has been correctly installed
    //            Application.Idle += idleHandler;
    //            Application.Run();
    //        });

    //        _thread.SetApartmentState(ApartmentState.STA);
    //        _thread.IsBackground = true;
    //        _thread.Start();
    //        _taskScheduler = tcs.Task.Result;
    //    }

    //    /// <summary>shutdown the STA thread</summary>
    //    public void Dispose()
    //    {
    //        if (_taskScheduler != null)
    //        {
    //            var taskScheduler = _taskScheduler;
    //            _taskScheduler = null;

    //            // execute Application.ExitThread() on the STA thread
    //            Task.Factory.StartNew(
    //                () => Application.ExitThread(),
    //                CancellationToken.None,
    //                TaskCreationOptions.None,
    //                taskScheduler).Wait();

    //            _thread.Join();
    //            _thread = null;
    //        }
    //    }

    //    /// <summary>Task.Factory.StartNew wrappers</summary>
    //    public void Invoke(Action action)
    //    {
    //        Task.Factory.StartNew(action,
    //            CancellationToken.None, TaskCreationOptions.None, _taskScheduler).Wait();
    //    }

    //    public TResult Invoke<TResult>(Func<TResult> action)
    //    {
    //        return Task.Factory.StartNew(action,
    //            CancellationToken.None, TaskCreationOptions.None, _taskScheduler).Result;
    //    }

    //    public Task Run(Action action, CancellationToken token)
    //    {
    //        return Task.Factory.StartNew(action, token, TaskCreationOptions.None, _taskScheduler);
    //    }

    //    public Task<TResult> Run<TResult>(Func<TResult> action, CancellationToken token)
    //    {
    //        return Task.Factory.StartNew(action, token, TaskCreationOptions.None, _taskScheduler);
    //    }

    //    public Task Run(Func<Task> action, CancellationToken token)
    //    {
    //        return Task.Factory.StartNew(action, token, TaskCreationOptions.None, _taskScheduler).Unwrap();
    //    }

    //    public Task<TResult> Run<TResult>(Func<Task<TResult>> action, CancellationToken token)
    //    {
    //        return Task.Factory.StartNew(action, token, TaskCreationOptions.None, _taskScheduler).Unwrap();
    //    }
    //}
}
