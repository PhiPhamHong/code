using System;
namespace Core.DataBase.ADOProvider.Attributes
{
    public interface IFieldLogChange
    {
        bool LogWhenChange { get; }
        string Name { get; }

        Type TypeRef { get; }
    }
}