using System.Web.UI.WebControls;

namespace Core.Web.Extensions
{
    public class ShRepeater : Repeater
    {
        sealed protected override void OnItemDataBound(RepeaterItemEventArgs e)
        {
            base.OnItemDataBound(e);
            if (!e.IsItem()) return;
            if (ItemDataBound != null) ItemDataBound(this, e);
        }

        new public event RepeaterItemEventHandler ItemDataBound;
    }
}