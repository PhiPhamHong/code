namespace Core.Web.Resources
{
    public class ResourceJsHandler : ResourceHandler<ResourcesConfig>
    {
        protected override HandlerType ContentType
        {
            get { return HandlerType.Js; }
        }
    }
}
