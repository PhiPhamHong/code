using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using Core.Extensions;
using Core.Utility.IO;
namespace Core.Utility
{
    /// <summary>
    /// Định nghĩa lại BackgroundWorker nhằm
    /// 1. Có khả năng Start, Stop
    /// 2. Có khả năng ghi ra thông báo
    /// 3. Disposable
    /// 4. Control được quá trình ghi log lỗi khi thực hiện công việc trong Worker
    /// </summary>
    public abstract class ShBackgroundWorker : Messagable, IDisposable
    {
        private BackgroundWorker worker = null;

        /// <summary>
        /// Công việc được thực hiện trong BackgroundWorker
        /// </summary>
        protected abstract void DoWork();

        public void Start()
        {
            if (IsRuning) return;

            worker = new BackgroundWorker();
            worker.DoWork += worker_DoWork;

            BeforeRun();
            IsRuning = true;
            worker.RunWorkerAsync();
        }

        protected virtual void BeforeRun() { }

        public void Stop()
        {
            if (!IsRuning) return;

            IsRuning = false;
            try
            {
                if (worker != null) worker.Dispose();
            }
            catch { }
            finally
            {
                try
                {
                    OnFinish(this);
                    Dispose();
                }
                catch (Exception ex)
                {
                    FileHelper.WriteLog(GetType().FullName + " OnFinish", ex);
                }
            }
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            // Phương thức chuẩn bị trước khi bắt đầu công việc trong Thread
            if (!OnPrepare(this)) return;

            while (IsRuning)
            {
                IsWorking = true;
                try { DoWork(); }
                catch (ThreadAbortException) { IsRuning = false; }
                catch (Exception ex)
                {
                    // Bắt Exception theo như mong muốn của class kế thừa
                    // Nếu không sẽ thực hiện ghi log như bình thường
                    if (!exceptions.Get(ex.GetType().FullName, delg => { delg.DynamicInvoke(ex); }))
                    {
                        ShowMessage(ex.Message);
                        WriteLogException(ex);
                        if (ex.InnerException != null) WriteLogException(ex.InnerException);
                    }
                    if (Error != null) Error(this, ex);
                }
                finally { IsWorking = false; }

                // Ngủ một tí
                if (Interval != TimeSpan.Zero) Thread.Sleep(interval);
            }
        }

        public void WriteLogException(Exception ex)
        {
            FileHelper.WriteLog(GetType().FullName, ex.Message + Environment.NewLine + ex.StackTrace, "Worker/" + GetType().FullName);
        }

        /// <summary>
        /// Danh sách các xử lý Exception ngoại lệ mà class kế thừa mong muốn xử lý
        /// </summary>
        private Dictionary<string, Delegate> exceptions = new Dictionary<string, Delegate>();

        /// <summary>
        /// Phương thức để đưa vào một phương thức xử lý với một loại Exception khi mà có Exception xảy ra 
        /// trong quá trình thực hiện DoWork
        /// </summary>
        /// <typeparam name="T">Loại Exception cần được xử lý</typeparam>
        /// <param name="func">Cách thức xử lý khi DoWork xảy ra Exception</param>
        public void WithThrow<T>(Action<T> func) where T : Exception
        {
            exceptions[typeof(T).FullName] = func;
        }

        public bool IsRuning { private set; get; }
        public bool IsWorking { private set; get; }

        private TimeSpan interval = TimeSpan.Zero;
        public TimeSpan Interval
        {
            get { return interval; }
            set { interval = value; }
        }

        /// <summary>
        /// Sự kiện chuẩn bị trước khi start
        /// </summary>
        public event Func<object, bool> Prepare;
        protected virtual bool OnPrepare(object sender)
        {
            if (Prepare != null) return Prepare(sender);
            return true;
        }

        /// <summary>
        /// Sự kiện khi ngừng thread
        /// </summary>
        public event Action<object> Finish;
        protected virtual void OnFinish(object sender)
        {
            worker = null;
            if (Finish != null) Finish(sender);
        }

        /// <summary>
        /// Khai báo sự kiện khi có lỗi trong quá trình thực hiện công việc của Thread
        /// </summary>
        public event Action<object, Exception> Error;

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }

    public class Timeout : ShBackgroundWorker
    {
        int i = 0;

        private int seconds = 5;
        public virtual int Seconds
        {
            get { return seconds; }
            set { seconds = value; }
        }

        protected override void DoWork()
        {
            i++;
            OnTick(i);
            if (i >= Seconds)
            {
                try
                {
                    if (End != null) End();
                }
                catch(Exception ex)
                {

                }
                Stop();
            }
        }

        public event Action End;

        protected virtual void OnTick(int seconds)
        {
            if (Tick != null) Tick(seconds);
        }

        public event Action<int> Tick;

        protected override void BeforeRun()
        {
            Interval = new TimeSpan(0, 0, 1);
        }
    }

    public static class ShBackgroundWorkerExtension
    {
        public static void StopAndWait<T>(this List<T> workers, int millisecondsTimeout = 100) where T : ShBackgroundWorker
        {
            workers.ForEach(w => w.Stop());
            workers.WaitStop(millisecondsTimeout);
        }

        public static void StopAndWait(this ShBackgroundWorker worker, int millisecondsTimeout = 100)
        {
            worker.Stop();
            worker.WaitStop(millisecondsTimeout);
        }

        public static void WaitStop<T>(this List<T> workers, int millisecondsTimeout = 100) where T : ShBackgroundWorker
        {
            while (workers.Count != 0 && workers.Any(w => w.IsRuning || w.IsWorking)) { Thread.Sleep(millisecondsTimeout); }
        }

        public static void WaitStop(this ShBackgroundWorker worker, int millisecondsTimeout = 100)
        {
            while (worker.IsRuning || worker.IsWorking) { Thread.Sleep(millisecondsTimeout); }
        }
    }
}