using System.Web.UI;
using System.Linq;
using Core.Web.WebBase;
using Core.Extensions;
using Core.Sites.Libraries.Business;
namespace Core.Sites.Apps.Web.Controls
{
    public partial class BoxSearch : ControlBase
    {
        [TemplateContainer(typeof(BoxContentContainer))]
        [TemplateInstance(TemplateInstance.Single)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public ITemplate ContentTemplate { set; get; }

        public class BoxContentContainer : Control, INamingContainer
        {
            internal BoxContentContainer() { }
        }

        private string nameKey = "Keyword";
        public string NameKey
        {
            get { return nameKey; }
            set { nameKey = PortalContext.GetLabel(value); }
        }

        private string placeHolder = PortalContext.GetLabel("Nhập từ khóa tìm kiếm");
        public string PlaceHolder
        {
            get { return placeHolder; }
            set { placeHolder = PortalContext.GetLabel(value); }
        }

        public override void InitData()
        {
            if (ContentTemplate == null) return;

            var container = new BoxContentContainer();
            ContentTemplate.InstantiateIn(container);
            pclContent.Controls.Add(container);
            pclContent.Controls.Cast<Control>().OfType<ControlBase>().ForEach(c => c.InitData());
        }
    }
}