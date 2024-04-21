using System;
namespace Core.DataBase.ADOProvider.Attributes
{
    public interface IEntityForLogShowName
    {
        string Name { get; }
    }
    public interface IEntityForLogDataExtend
    {
        object ExtendData { get; }
    }
    public interface IEntityForLog : IEntityForLogShowName, IEntityForLogDataExtend { }
    public interface IEntityForLogShowNameByRef
    {
        int NameKey { get; }
        Type TypeNameKey { get; }
    }
}