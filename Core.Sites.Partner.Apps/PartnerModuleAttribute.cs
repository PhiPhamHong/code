using Core.Sites.Libraries.Business;

namespace Core.Sites.Partner.Apps
{
    public class PartnerModuleAttribute : ModuleAttribute
    {
        protected override string GetDefaultRoot(string[] paths)
        {
            return "Web/Core.Sites.Partner.Apps/" + base.GetDefaultRoot(paths);
        }
    }
}