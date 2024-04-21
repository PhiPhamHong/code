using Core.Attributes;
using Core.Web.WebBase.HtmlBuilders;
namespace Core.Sites.Apps.Web.Inputs
{
    public class ChartTypeInput : SelectEnum<ChartTypeInput.Chart, ChartTypeInput>
    {
        public enum Chart : byte
        {
            [FieldInfo(Name = "Biểu đồ cột")] Bar = 0,
            [FieldInfo(Name = "Biểu đồ đường sóng")] Line = 1,
            //[FieldInfo(Name = "Biểu đồ tròn")] Pie = 2
        }
    }
}