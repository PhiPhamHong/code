using System.Collections.Generic;
using System.Linq;
using System.Web;
using Core.Web.Extensions;
using Core.Extensions;
using Core.Utility;
using Newtonsoft.Json;
using Core.Attributes.Validators;
using System.Text.RegularExpressions;
using System;
namespace Core.Web.WebBase
{
    public interface IAjax { }
    public static partial class IAjaxExtension
    {
        public static IEnumerable<T> GetObjects<T>(this IAjax ajax, string prefix, bool needValidate, bool validateFullProperties) where T : new() { return GetObjectsHelper<T>(prefix, needValidate, validateFullProperties); }
        public static IEnumerable<T> GetObjectsHelper<T>(string prefix, bool needValidate, bool validateFullProperties) where T : new()
        {
            var rex = new Regex(prefix + "-([0-9]+)\\[([^/]+)\\]", RegexOptions.Compiled);
            return HttpContext.Current.Request.Params.Cast<string>()
                .Select(key => new { key, value = HttpContext.Current.Request.Params[key] })
                .Select(kv => new { match = rex.Match(kv.key), kv }).Where(mkv => mkv.match.Success)
                .Select(mkv => new { stt = mkv.match.Groups[1].Value.To<int>(), key = mkv.match.Groups[2].Value, value = mkv.kv.value })
                .GroupBy(data => data.stt)
                .Select(g =>
                {
                    var values = g.ToDictionary(gi => gi.key, gi => (object)gi.value);
                    return needValidate ? Model<T>.ParseWithValidate(values, validateFullProperties) : Model<T>.Parse(values, false);
                });
        }
        public static void SetMsg(this IAjax ajax, string msg, params object[] dataFormats)
        {
            msg = msg.Translate();
            if (dataFormats != null && dataFormats.Length > 0)
                msg = msg.Frmat(dataFormats);
            SetData("Message", msg);
        }
        public static void SetData(string name, object data) => ResponseMessage.Current.Data[name] = data;
        public static bool HasParam(this IAjax ajax, string param) { return HttpContext.Current.Request.HasParam(param); }
        public static T Query<T>(this IAjax ajax, string key, T @default = default(T)) { return HttpContext.Current.Request.Query(key, @default); }
        public static string Query(this IAjax ajax, string key) { return ajax.Query<string>(key); }
        public static void SetData(this IAjax ajax, string name, object data) { ResponseMessage.Current.Data[name] = data; }
        public static T ParseParamTo<T>(this IAjax ajax, bool validateFullProperties) where T : new() => HttpContext.Current.Request.ParseWithValidate<T>(validateFullProperties);
        public static T ParseTo<T>(this IAjax ajax) where T : new() { return HttpContext.Current.Request.Parse<T>(); }
        public static void ParseParamTo(this IAjax ajax, object obj, bool validateFullProperties)
        {
            var vm = obj.Validate(HttpContext.Current.Request.Params, validateFullProperties);
            if (!vm.IsValid) throw new ValidatorException(vm);
            obj.Parse(HttpContext.Current.Request.Params, false);
        }
        public static void ParseTo(this IAjax ajax, object obj) { HttpContext.Current.Request.ParseTo(obj, true); }
        public static void Reload(this IAjax ajax) { ResponseMessage.Current.JavaScript = "window.location.reload()"; }
        public static void ReloadPath(this IAjax ajax) { ResponseMessage.Current.JavaScript = "window.location.href = window.location.pathname"; }
        public static void GotoUrl(this IAjax ajax, string url) { ResponseMessage.Current.JavaScript = "window.location.href = '" + url + "'"; }
        public static void Alert(this IAjax ajax, string msg) { ResponseMessage.Current.JavaScript = "Linkit.alert(" + JsonConvert.SerializeObject(msg) + ")"; }
        public static void SetJs(this IAjax ajax, string js) { ResponseMessage.Current.JavaScript = js; }
    }
    public static partial class IAjaxExtension
    {
        public static void ForChartByYear(this IAjax ajax, Func<int, object> data)
        {
            var year = ajax.Query<int>("Year", DateTime.Today.Year);
            ajax.SetData("Year", year);
            ajax.SetData("Summary", data(year));
        }
        public static void ForChartByMonth(this IAjax ajax, Func<int, int, object> data)
        {
            var year = ajax.Query<int>("Year", DateTime.Today.Year);
            var month = ajax.Query<int>("Month", DateTime.Today.Month);

            ajax.SetData("Year", year);
            ajax.SetData("Month", month);

            ajax.SetData("Summary", data(year, month));
        }
    }
}