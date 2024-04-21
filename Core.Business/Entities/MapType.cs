using Core.DataBase.ADOProvider.Attributes;
using Core.Web.WebBase.HtmlBuilders;
namespace Core.Business.Entities
{
    [TableInfo(TableName = MainDbTable.MapTypes, Name="Loại bản đồ")]
    public class MapType : MainDb.Entity<MapType>
    {
        [Field(IsKey = true, IsIdentity = true)]
        [DataValueField(Default = "0")]
        public int MapTypeId { set; get; }

        [Field]
        [DataTextField(Default = "-- Loại bản đồ --")]
        public string Name { set; get; }
    }
}
