using Core.Utility.Xml;
namespace Core.Web.Resources
{
    /// <summary>
    /// Class để tải nội dung Resource ở trong file config
    /// </summary>
    public abstract class ResourceHandler<TConfig> : HandlerResourceBase where TConfig : ResourcesConfig, new()
    {
        public override string GetResource()
        {
            return ReadConfig<TConfig>.Load().LoadContent(ContentType);
        }
    }
}
