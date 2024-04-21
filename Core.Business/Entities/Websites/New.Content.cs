using Core.Attributes;
using Core.Attributes.Validators;
using Core.DataBase.ADOProvider;
using Core.DataBase.ADOProvider.Attributes;
using Core.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Business.Entities.Websites
{
    public partial class New
    {
        [TableInfo(TableName = "[News.Contents]", Name = "Tin (Tách ngôn ngữ))")]
        public class Content : MainDb.EntityAuthor<Content>,IModel<int>, ICompanyNeedValidate
        {
            [Field(IsKey = true, IsIdentity = true)] public int NewsId { get; set; }
            [Field(Name = "Công ty")] public int CompanyId { get; set; }
            [Field(Name = "Ngôn ngữ"), ValidatorRequire] public int LanguageId { get; set; }
            [Field(Name = "Tiêu đề"), ValidatorRequire] public string Title { get; set; }
            [Field(Name = "Mô tả vắn")] public string Sapo { get; set; }
            [Field(Name = "Từ khóa")] public string Keyword { get; set; }
            [Field(Name = "Nội dung")] public string NewsContent { get; set; }


            [Field(Name = "Ngày đăng"), ValidatorRequire] public DateTime? DatePublished { set; get; }
            [Field(Name = "Chuyên mục"), ValidatorRequire] public int CatId { set; get; }
            [Field(Name = "Ảnh đại diện")] public string Avatar { set; get; }
            [Field(Name = "Hiển thị")] public bool IsActive { set; get; }
            [Field(Name = "Tags")] public string Tags { set; get; }
            [Field(Name = "Đường dẫn Youtube")] public string YoutubeId { set; get; }
            [Field(Name = "Ảnh bài viết")] public string Avatars { set; get; }


            //Thêm mới cho bên KX: sau xong rồi thì bỏ đi
            [Field(Name = "Tệp đính kèm")] public string Attachment { get; set; }
            [Field(Name = "Load tài liệu trong chi tiết")] public bool AllowDetail { get; set; }
            [Field(Name = "Alias")] public string Alias { get; set; } //Title.UnicodeFormat()

            public int Key
            {
                get { return NewsId; }
                set { NewsId = value; }
            }
            [PropertyInfo(Name = "STT")] public int Row { get; set; }

            public class DataSource : DataSource<Content>.Module, ICompanyNeedValidate
            {
                public int CompanyId { get; set; }
                public int CatId { set; get; }
                public int LanguageId { get; set; }
                public string Title { get; set; }
                public override List<Content> GetEntities() => Inst.ExeStoreToList("sp_News_Contents_GetData", CompanyId, CatId, LanguageId, Title, Start, Length, FieldOrder, Dir);
                public override int GetTotal() => Inst.SelectFirstValue<int>("sp_News_Contents_GetData_Count", CompanyId, CatId, LanguageId, Title);
                
            }
        }
    }
}
