using System;
using Core.DataBase.ADOProvider;
namespace Core.Business.Entities.Log
{
    public abstract partial class FieldConverter
    {
        public Type Type { set; get; }
        public abstract string GetName(object vKey, IDataBaseService service);
    }
}