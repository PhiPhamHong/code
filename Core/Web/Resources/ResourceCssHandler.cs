namespace Core.Web.Resources
{
    public class ResourceCssHandler : ResourceHandler<ResourcesConfig>
    {
        protected override HandlerType ContentType
        {
            get { return HandlerType.Css; }
        }
    }
}
