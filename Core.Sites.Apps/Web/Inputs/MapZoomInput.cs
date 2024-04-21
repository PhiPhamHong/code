using Core.DataBase.ADOProvider;
using Core.Web.WebBase.HtmlBuilders;
using System.Collections.Generic;
using System.Linq;
namespace Core.Sites.Apps.Web.Inputs
{
    public class MapZoomInput : SelectModel<MapZoomInput.MapZoom, MapZoomInput>
    {
        public MapZoomInput()
        {
            DisableSearch(true);
        }

        protected override List<MapZoom> GetData()
        {
            return Enumerable.Range(10, 11).Select(i => new MapZoom { Zoom = i }).ToList();
        }

        public class MapZoom : ModelBase
        {
            [DataValueField(Default = "0")]
            [DataTextField(Default = "-- Mức phóng --")]
            public int Zoom { set; get; }
        }
    }
}