using System;
using System.Linq;
using System.Reflection;
using System.Web.UI;
using Core.Reflectors;
using Core.Extensions;
using Core.Utility.Language;
using Newtonsoft.Json;
using System.Collections.Generic;
using Core.Attributes.Validators;
namespace Core.Web.WebBase
{
    public class PageAjax : PageAjaxBase, IAjax
    {
        protected override void DoOnPageLoad()
        {
            // Type của đối tượng chứa phương thức Ajax mà client đang yêu cầu
            var typeAjaxable = "{0}.{1},{0}".Frmat(GetAssemblyOfMethod(), Request.QueryString["_o"]);
            var typeAjax = Type.GetType(typeAjaxable);

            // Lấy phương thức cần thực hiện
            var method = typeAjax.GetMethod(Request.QueryString["_m"]);

            // Lấy ra điều kiện gọi phương thức và kiểm tra có được phép gọi phương thức hay không
            var conditions = method.GetAttributes<AjaxRequestConditionAttribute>().OrderBy(a => a.Stt).ToList();//.FirstOrDefault(c => !c.Condition);
            if (conditions.Count != 0)
            {
                var condition = conditions.FirstOrDefault(c => !c.Condition);
                if (condition != null) throw new ErrorMessageException(condition.Msg, condition.DataFormats);
            }

            BeforeRequest(conditions);

            // Tìm attribute bound method
            var abr = ReflectMethodInfo<AjaxBoundRequestAttribute>.Inst[method];

            // Trước khi thực hiện gọi phương thức ajax
            if (abr != null) abr.Before();

            // Gọi phương thức
            var @params = method.GetParameters().Select(p =>
            {
                var rValue = Request.Params[p.Name];

                var objValue = rValue == null ? p.ParameterType.GetDefault() : JsonConvert.DeserializeObject(rValue, p.ParameterType);
                var nva = p.GetCustomAttribute<NeedValidateAttribute>();

                if (nva != null)
                {
                    if (nva is INeedBuildValue) objValue = nva.As<INeedBuildValue>().BuildValue(objValue);

                    var vm = objValue.Validate(true);
                    if (!vm.IsValid) throw new ValidatorException(vm);
                }

                OnValidateParam(objValue);
                return objValue;
            }).ToArray();
            var result = method.Invoke(Activator.CreateInstance(typeAjax), @params);
            this.SetData("Output", result);

            EndCallMethod(method, result);

            // Sau khi thực hiện phương thức ajax
            if (abr != null) abr.After();
        }
        protected virtual void EndCallMethod(MethodInfo method, object result) { }
        protected virtual void BeforeRequest(List<AjaxRequestConditionAttribute> conditions) { }
        protected virtual void OnValidateParam(object obj) { }
        protected virtual string GetAssemblyOfMethod() => Request.QueryString["_n"];
    }

    public class PageAjaxBase : Page, IAjax
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Exception exp1 = null, exp2 = null;
            try
            {
                DoOnPageLoad();
            }
            catch (Exception ex)
            {
                // Lấy ra Exception ở bên trong
                var exInner = ex.InnerException;

                // Chừng nào mà Exception bên trong không phải null thì kiểm tra lấy tiếp
                Exception exTemp = null;
                while (exInner != null)
                {
                    exTemp = exInner;
                    exInner = exInner.InnerException;
                }

                // Lấy ra Exeption 
                exTemp = exTemp ?? ex;

                // Thông báo

                var msg = exTemp.Message;
                if (exTemp.Is<IExceptionMessage>())
                {
                    msg = msg.Translate();

                    var em = exTemp.As<IExceptionMessage>();
                    var dataFormats = em.DataFormats;
                    if (dataFormats != null && dataFormats.Length > 0)
                        msg = msg.Frmat(dataFormats);
                }
                this.SetData("MessageError", msg);

                //this.SetData("MessageError", exTemp.Is<ValidatorException>() ?
                //                                 exTemp.Message :
                //                                 (exTemp.Is<ExceptionNotTranslate>() ? exTemp.Message : exTemp.Message.Translate()));

                this.SetData("ErrorType", ex.GetType().Name);
                if (exTemp.Is<ValidatorException>())
                    this.SetData("FieldError", exTemp.As<ValidatorException>().ValidatorMessage.FieldName);

                if (exTemp != null) this.SetData("ErrorTypeInner", exTemp.GetType().Name);

                exp1 = ex;
                exp2 = exTemp;
            }
            finally
            {
                OnWriteResponse();
                if ((exp1 != null && exp1.GetType().Name == typeof(EndException).Name) || (exp2 != null && exp2.GetType().Name == typeof(EndException).Name)) ;
                else
                {
                    EndRequest();
                }
            }
        }
        protected virtual void OnWriteResponse() => Response.Write(ResponseMessage.Current.ToJson2());
        protected virtual void EndRequest() { }
        protected virtual void DoOnPageLoad() { }
    }

    public interface IExceptionMessage
    {
        object[] DataFormats { get; }
    }

    public class ErrorMessageException : Exception, IExceptionMessage
    {
        public object[] DataFormats { private set; get; }
        public ErrorMessageException(string msg, params object[] dataFormats) : base(msg) => DataFormats = dataFormats;
    }

    public class StringFormat
    {
        public string String { private set; get; }
        public object[] DataFormats { private set; get; }

        public StringFormat(string str, params object[] dataFormats)
        {
            String = str;
            DataFormats = dataFormats;
        }
    }
}
