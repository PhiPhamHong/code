using Core.Attributes;
using Core.DataBase.ADOProvider;
using Core.DataBase.ADOProvider.Attributes;
using Core.Utility;
using System;
using System.Collections.Generic;

namespace Core.Business.Entities.Others.PriceConfigs
{
    [TableInfo(TableName = "[PriceConfigs]", Name = "Cấu hình giá")]
    public class PriceConfig : MainDb.Entity<PriceConfig>, IModel<int>
    {
        [Field(IsKey = true, IsIdentity = true)] public int ConfigId { get; set; }
        [Field] public int StartDirection { get; set; }
        [Field] public int EndDirection { get;set; }
        [Field] public int ProductType { get; set; }
        [Field] public decimal Price { get; set; }
        [Field] public TranType ContainerType { get; set; }
        public int Key { get => ConfigId; set => ConfigId = value; }

        public class DataSource : DataSource<PriceConfig>.Module
        {
            public int? StartDirection { get; set; }
            public int? EndDirection { get; set; }
            public int? ProductType { get; set; }
            public TranType? ContainerType { get; set; }
            public override List<PriceConfig> GetEntities() => Inst.ExeStoreToList("sp_Priceconfigs_GetData", StartDirection, EndDirection, ProductType, ContainerType);

            public override int GetTotal()
            {
                throw new NotImplementedException();
            }
        }


        //Data display
        public int Row { get; set; }
        public string StartPointName { get; set; }
        public string EndPointName { get; set; }
        public string ProductTypeName { get; set; }
        public string TranTypeName { get; set; }
    }
    public enum TranType : int
    {
        [FieldInfo(Name = "--Chọn loại xe--")] Unknown = 0,
        [FieldInfo(Name = "CONTAINER 20T")] C20T = 1,
        [FieldInfo(Name = "CONTAINER 40T")] C40T = 2
    }
}
