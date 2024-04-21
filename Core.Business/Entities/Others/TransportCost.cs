using Core.Attributes;
using Core.Attributes.Validators;
using Core.DataBase.ADOProvider;
using Core.DataBase.ADOProvider.Attributes;
using Core.Utility;
using System.Collections.Generic;
using System.Linq;


namespace Core.Business.Entities.Others
{
    [TableInfo(TableName = "TransportCosts", Name = "Chi phí vận tải")]
    public class TransportCost : MainDb.EntityAuthor<TransportCost>, IModel<int>, ICompanyNeedValidate
    {
        [Field(IsIdentity = true, IsKey = true)] public int TranId { get; set; }
        [Field(Name = "Công ty")] public int CompanyId { get; set; }
        [Field(Name = "Quốc gia"), ValidatorRequire] public int NationId { get; set; }
        [Field(Name = "Khu vực"), ValidatorRequire] public int AreaId { get; set; }
        [Field(Name = "Địa chỉ"), ValidatorRequire] public string Address { get; set; }
        [Field(Name = "Loại hàng"), ValidatorRequire] public int ProductCatId { get; set; }
        [Field(Name = "Áp dụng")] public bool IsActive { get; set; }
        [PropertyInfo(Name = "Stt")] public int Row { get; set; }
        public int Key
        {
            get { return TranId; }
            set { TranId = value; }
        }

        [TableInfo(TableName = "[TransportCost.Prices]")]
        public class Price : MainDb.Entity<Price>, IModel<int>, IEmpty, IModelForeign<int>
        {
            [Field(IsKey = true, IsIdentity = true)] public int PriceId { get; set; }
            [Field] public int TranId { get; set; }
            [Field] public TranType Type { get; set; }
            [Field] public decimal? Cost { get; set; }
            public int Key
            {
                get { return PriceId; }
                set { PriceId = value; }
            }
            [PropertyInfo(Name = "Loại xe")] public string TypeString { get { return EnumHelper<TranType, FieldInfoAttribute>.Inst.GetAttribute(Type).Name; } }
            public bool IsEmpty => Type == 0 || Cost == 0;

            public int KeyForeign
            {
                get { return TranId; }
                set { TranId = value; }
            }
            public int Stt { get; set; }
            public bool Editted { get; set; }

            public static List<Price> GetByTranId(int tranId)
            {
                return Inst.GetAllToList().Where(c => c.TranId == tranId).ToList();
            }
        }

        public class DataSource : DataSource<TransportCost>.Module, ICompanyNeedValidate
        {
            public int CompanyId { get; set; }
            public int NationId { get; set; }
            public int AreaId { get; set; }
            public override List<TransportCost> GetEntities() => Inst.ExeStoreToList("sp_TransportCosts_GetData", CompanyId, NationId, AreaId, Start, Length, FieldOrder, Dir);
            public override int GetTotal() => Inst.SelectFirstValue<int>("sp_TransportCosts_GetData_Count", CompanyId, NationId, AreaId);

        }
    }
    public enum TranType : int
    {
        [FieldInfo(Name = "-- Chọn loại xe --")] Unknown = 0,
        [FieldInfo(Name = "CONTAINER 20T")] C20T = 1,
        [FieldInfo(Name = "CONTAINER 40T")] C40T = 2
    }
}
