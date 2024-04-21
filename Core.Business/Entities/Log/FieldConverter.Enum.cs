using System.Linq;
using Core.DataBase.ADOProvider;
using SEnum = System.Enum;
using Core.Extensions;
using Core.Attributes;
using Core.Reflectors;
namespace Core.Business.Entities.Log
{
    public partial class FieldConverter
    {
        public class Enum : FieldConverter
        {
            public override string GetName(object vKey, IDataBaseService service)
            {
                var e = SEnum.ToObject(Type, vKey.To(SEnum.GetUnderlyingType(Type)));
                var fi = ReflectFieldInfo<FieldInfoAttribute>.Inst[Type].FirstOrDefault(f => f.FieldValue.Equals(e));
                return fi.Name;
            }
        }
    }
}