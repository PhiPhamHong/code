using Microsoft.Practices.EnterpriseLibrary.Data;
using Core.DataBase.ADOProvider;
using Core.DataBase.ADOProvider.Attributes;
using Core.Utility;
using System;
using Core.Attributes;

namespace Core.Business
{
    public class MainDb : MainDBBase
    {
        private static Database instDb = null;
        public static Database InstDb
        {
            get 
            {
                if (instDb == null)
                {
                    try { instDb = MainDBBaseExtension.GetDatabase(string.Empty); }
                    catch { }
                }
                return instDb; 
            }
        }

        protected override Database Db
        {
            get { return InstDb; }
        }

        public class Service : DataBaseService<MainDb> { }

        public abstract class Entity<T> : ModelBase<T> where T : ModelBase, new()
        {
            public override IDataBaseService GetDataBaseService()
            {
                return Singleton<Service>.Inst;
            }
        }

        public abstract class EntityAuthor<T> : Entity<T>, IAuthor where T : ModelBase, new()
        {
            [Field(LogWhenChange = false)] public int CreatedByUserId { set; get; }
            [Field(Name = "Ngày tạo", LogWhenChange = false)] public DateTime CreatedDate { set; get; }
            [Field(LogWhenChange = false)] public int UpdatedByUserId { set; get; }
            [Field(Name = "Ngày sửa", LogWhenChange = false)] public DateTime UpdatedDate { set; get; }

            [PropertyInfo(Name = "Người tạo")] public string CreatedByUserName { set; get; } // Không phải là trường trong db, nên để PropertyInfo thôi
            [PropertyInfo(Name = "Người sửa")] public string UpdatedByUserName { set; get; }
        }
    }
}