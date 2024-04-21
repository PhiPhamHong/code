using Core.Attributes;
using Core.Attributes.Validators;
using Core.DataBase.ADOProvider;
using Core.DataBase.ADOProvider.Attributes;
using Core.Utility;
using Core.Web.WebBase.HtmlBuilders;
using System;
using System.Collections.Generic;

namespace Core.Business.Entities
{
    [TableInfo(TableName = "[Users.Groups]", Name = "Phòng")]
    public partial class GroupUser : MainDb.EntityAuthor<GroupUser>, IModel<int>, ICompanyNeedValidate, IEntityForLogShowName
    {
        #region Properties
        [Field(IsKey = true, IsIdentity = true), DataValueField(Default = "0")] public int GroupId { set; get; }
        [Field(Name = "Công ty")] public int CompanyId { set; get; }
        [Field(Name = "Tên phòng"), ValidatorRequire, ValidatorLength(Max = 200), DataTextField(Default = "-- Phòng --")] public string Name { set; get; }
        [Field(Name = "Nhóm phòng")] public EType GroupType { set; get; }
        [PropertyInfo(Name = "Nhóm phòng")] public string GroupTypeName
        {
            get { return GroupType == EType.Unknown ? string.Empty : EnumHelper<EType, TypeAttribute>.Inst.GetAttribute(GroupType).Name; }
        }

        [Field(Name = "Ghi chú"), ValidatorLength(Max = 500)] public string Description { set; get; }
        #endregion

        public static List<GroupUser> GetData(int companyId, string name = "", EType type = EType.Unknown, int start = 0, int length = int.MaxValue, string fieldOrder = "Name", string dir = "")
        => Inst.ExeStoreToList("sp_Users_Groups_GetData", companyId, name, type, start, length, fieldOrder, dir);

        public static int GetDataCount(int companyId, string name, EType type)
        => Inst.SelectFirstValue<int>("sp_Users_Groups_GetData_Count", companyId, name, type);

        public static List<GroupUser> GetByUserId(int userId, EType type, DateTime date)
        => Inst.ExeStoreToList("sp_Users_Groups_GetByUserId", userId, type, date);

        public int Key
        {
            get { return GroupId; }
            set { GroupId = value; }
        }

        public enum EType : byte
        {
            [Type(Name = "-- Loại phòng --")] Unknown = 0,
            [Type(Name = "Kinh doanh")] Sale = 1,
            [Type(Name = "Kế hoạch")] Plan = 2,
            [Type(Name = "Kỹ thuật")] Techical = 3,
            [Type(Name = "Bộ phận kho")] Stock = 4
        }

        public class TypeAttribute : FieldInfoAttribute { }
        public class DataSource : DataSource<GroupUser>.Module, ICompanyNeedValidate
        {
            public int CompanyId { set; get; }
            public string Name { set; get; }
            public EType GroupType { set; get; }

            public override List<GroupUser> GetEntities() => Inst.ExeStoreToList("sp_Users_Groups_GetData", CompanyId, Name, GroupType, Start, Length, FieldOrder, Dir);
            public override int GetTotal() => Inst.SelectFirstValue<int>("sp_Users_Groups_GetData_Count", CompanyId, Name, GroupType);
        }
    }
}
