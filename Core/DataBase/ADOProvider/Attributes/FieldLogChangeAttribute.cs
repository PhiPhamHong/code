using System;
using Core.Attributes;
namespace Core.DataBase.ADOProvider.Attributes
{
    public class FieldLogChangeAttribute : PropertyInfoAttribute, IFieldLogChange
    {
        public bool LogWhenChange
        {
            get { return true; }
        }
    }
}