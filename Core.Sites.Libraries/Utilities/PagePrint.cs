using System.Web.UI;
using Core.Sites.Libraries.Business;
using Core.Sites.Libraries.Utilities.Sites;

namespace Core.Sites.Libraries.Utilities
{
    public class PagePrint : Page
    {
        protected string LogoBg
        {
            get { return PortalContext.Config.LogoBackground; }
        }

        protected int LogoBgWidth
        {
            get { return 680; }
        }

        protected int LogoBgHeight
        {
            get { return 450; }
        }

        protected string LogoPrint
        {
            get { return PortalContext.Config.LogoPrint; }
        }
        protected string HeaderPrint
        {
            get { return PortalContext.Config.HeaderPrint; }
        }
        protected int LogoPrintWidth
        {
            get { return 200; }
        }
    }

    public class ModulePrint : PortalModule
    {
        protected string LogoBg
        {
            get { return PortalContext.Config.LogoBackground; }
        }
        protected int LogoBgWidth
        {
            get { return 680; }
        }
        protected int LogoBgHeight
        {
            get { return 450; }
        }
        protected string LogoPrint
        {
            get { return PortalContext.Config.LogoPrint; }
        }
        protected int LogoPrintWidth
        {
            get { return PortalContext.Config.LogoPrintWidth; }
        }
        protected string HeaderPrint
        {
            get { return PortalContext.Config.HeaderPrint; }
        }
    }
}