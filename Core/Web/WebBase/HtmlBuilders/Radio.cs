namespace Core.Web.WebBase.HtmlBuilders
{
    public class Radio<T> : Checkbox<T>
    {
        protected override string Type
        {
            get { return "radio"; }
        }
    }
}