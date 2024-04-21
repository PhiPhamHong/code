using Core.Business.Enums;
using Core.Web.WebBase.HtmlBuilders;

namespace Core.Sites.Apps.Web.Inputs
{
    public class ColorSystemInput : SelectEnum<ColorSystem, ColorSystemAttribute, ColorSystemInput>
    {
        public ColorSystemInput()
        {
            BuildOptionAttribute += (attr) => $"data-css='{attr.Css}'";
        }
    }
}