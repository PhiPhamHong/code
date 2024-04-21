using Core.Attributes;
namespace Core.Business.Enums
{
    public enum ColorSystem : byte
    {
        [ColorSystem(Name = "-- Mặc định --")] Unknown = 0,
        [ColorSystem(Css = "green", Name = "Xanh lá cây")] Green = 1,
        [ColorSystem(Css = "blue", Name = "Xanh da trời")] Blue = 2,
        [ColorSystem(Css = "maroon", Name = "Nâu đỏ")] Maroon = 3,
        [ColorSystem(Css = "red", Name = "Đỏ")] Red = 4,
        [ColorSystem(Css = "purple", Name = "Tím")] Purple = 5,
        [ColorSystem(Css = "navy", Name = "Đen sẫm")] Navy = 6,
        [ColorSystem(Css = "light-blue", Name = "Xanh nhạt")] LightBlue = 7,
        [ColorSystem(Css = "aqua", Name = "Xanh lục nhạt")] Aqua = 8,
        [ColorSystem(Css = "yellow", Name = "Vàng")] Yellow = 9,
        [ColorSystem(Css = "gray", Name = "Xám")] Gray = 10,
        [ColorSystem(Css = "teal", Name = "Xanh lục đậm")] Teal = 11,
        [ColorSystem(Css = "orange", Name = "Cam")] Orange = 12,
        [ColorSystem(Css = "black", Name = "Đen")] Black = 13
    }

    public class ColorSystemAttribute : FieldInfoAttribute
    {
        public string Css { set; get; }
    }
}
