using Core.Attributes;
namespace Core.Web.WebBase
{
    /// <summary>
    /// quy định method cần điều kiện gì mới được thực hiện
    /// </summary>
    public abstract class AjaxRequestConditionAttribute : MethodInfoAttribute
    {
        public abstract bool Condition { get; }
        public abstract string Msg { get; }
        public abstract object[] DataFormats { get; }
        public int Stt { set; get; }
    }

    public class AjaxRequestConditionNotNeedLoginAttribute : AjaxRequestConditionAttribute
    {
        public override bool Condition => true;
        public override string Msg => string.Empty;
        public override object[] DataFormats => null;
    }
}
