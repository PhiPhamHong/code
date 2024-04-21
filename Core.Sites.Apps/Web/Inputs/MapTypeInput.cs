using Core.Business.Entities;
using Core.Web.WebBase.HtmlBuilders;
namespace Core.Sites.Apps.Web.Inputs
{
    public class MapTypeInput : SelectModel<MapType, MapTypeInput>
    {
        public MapTypeInput()
        {
            DisableSearch(true);
        }
    }
}