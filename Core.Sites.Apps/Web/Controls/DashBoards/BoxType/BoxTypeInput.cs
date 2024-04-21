using System;
using Core.Attributes;
using Core.Web.WebBase.HtmlBuilders;
namespace Core.Sites.Apps.Web.Controls.DashBoards.BoxType
{
    public class BoxTypeInput : SelectEnum<BoxTypeInput.BoxType, BoxTypeInput>
    {
        public enum BoxType
        {
            [BoxTypeInfo(Name = "Bình thường", Type = typeof(BoxLarge), DbBoxType = DbBoxType.Large1)] Normal = 0,
            [BoxTypeInfo(Name = "Nhỏ xanh nước biển", Type = typeof(BoxSmallAQua), DbBoxType = DbBoxType.Small1)] BoxSmallAQua = 2,
            [BoxTypeInfo(Name = "Nhỏ xanh lá cây", Type = typeof(BoxSmallGreen), DbBoxType = DbBoxType.Small1)] BoxSmallGreen = 3,
            [BoxTypeInfo(Name = "Nhỏ đỏ", Type = typeof(BoxSmallRed), DbBoxType = DbBoxType.Small1)] BoxSmallRed = 4,
            [BoxTypeInfo(Name = "Nhỏ vàng", Type = typeof(BoxSmallYellow), DbBoxType = DbBoxType.Small1)] BoxSmallYellow = 5,
            [BoxTypeInfo(Name = "Nhỏ 2 đỏ", Type = typeof(BoxInfoSmallRed), DbBoxType = DbBoxType.Small2)] BoxInfoSmallRed = 13,
            [BoxTypeInfo(Name = "Nhỏ 2 xanh nước biển", Type = typeof(BoxInfoSmallAQua), DbBoxType = DbBoxType.Small2)] BoxInfoSmallAQua = 14,
            [BoxTypeInfo(Name = "Nhỏ 2 xanh lá cây", Type = typeof(BoxInfoSmallGreen), DbBoxType = DbBoxType.Small2)] BoxInfoSmallGreen = 15,
            [BoxTypeInfo(Name = "Nhỏ 2 vàng", Type = typeof(BoxInfoSmallYellow), DbBoxType = DbBoxType.Small2)] BoxInfoSmallYellow = 16,
            [BoxTypeInfo(Name = "Nhỏ 3 đỏ", Type = typeof(BoxInfo2SmallRed), DbBoxType = DbBoxType.Small3)] BoxInfo2SmallRed = 17,
            [BoxTypeInfo(Name = "Nhỏ 3 xanh nước biển", Type = typeof(BoxInfo2SmallAQua), DbBoxType = DbBoxType.Small3)] BoxInfo2SmallAQua = 18,
            [BoxTypeInfo(Name = "Nhỏ 3 xanh lá cây", Type = typeof(BoxInfo2SmallGreen), DbBoxType = DbBoxType.Small3)] BoxInfo2SmallGreen = 19,
            [BoxTypeInfo(Name = "Nhỏ 3 vàng", Type = typeof(BoxInfo2SmallYellow), DbBoxType = DbBoxType.Small3)] BoxInfo2SmallYellow = 20,
            [BoxTypeInfo(Name = "Lớn", Type = typeof(BoxLarge), DbBoxType = DbBoxType.Large1)] BoxLarge = 6,
            [BoxTypeInfo(Name = "Lớn xanh nhạt", Type = typeof(BoxLargeInfo), DbBoxType = DbBoxType.Large1)] BoxLargeInfo = 7,
            [BoxTypeInfo(Name = "Lớn xanh đậm", Type = typeof(BoxLargePrimary), DbBoxType = DbBoxType.Large1)] BoxLargePrimary = 8,
            [BoxTypeInfo(Name = "Lớn xanh lá cây", Type = typeof(BoxLargeSuccess), DbBoxType = DbBoxType.Large1)] BoxLargeSuccess = 9,
            [BoxTypeInfo(Name = "Lớn vàng", Type = typeof(BoxLargeWarning), DbBoxType = DbBoxType.Large1)] BoxLargeWarning = 21,
            [BoxTypeInfo(Name = "Lớn đỏ", Type = typeof(BoxLargeDanger), DbBoxType = DbBoxType.Large1)] BoxLargeDanger = 22,
            [BoxTypeInfo(Name = "Lớn solid xanh dương", Type = typeof(BoxLargeSolidBlue), DbBoxType = DbBoxType.Large1)] BoxLargeSolidBlue = 10,
            [BoxTypeInfo(Name = "Lớn solid teal", Type = typeof(BoxLargeSolidTeal), DbBoxType = DbBoxType.Large1)] BoxLargeSolidTeal = 11,
            [BoxTypeInfo(Name = "Lớn solid xanh lá", Type = typeof(BoxLargeSolidGreen), DbBoxType = DbBoxType.Large1)] BoxLargeSolidGreen = 12
        }

        public class BoxTypeInfoAttribute : FieldInfoAttribute
        {
            public Type Type { set; get; }
            public DbBoxType DbBoxType { set; get; }
        }
    }
}