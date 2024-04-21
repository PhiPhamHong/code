using Core.DataBase.ADOProvider;
using Core.DataBase.ADOProvider.Attributes;
using Core.Extensions;
namespace Core.Business.Entities.Log
{
    public partial class FieldConverter
    {
        public class Default : FieldConverter
        {
            public override string GetName(object vKey, IDataBaseService service)
            {
                var entity = Type.CreateInstance<ModelBase>();
                if (!entity.Is<IEntityForLogShowName>()) return string.Empty;
                entity.SetDataBaseService(service);

                if(entity is IModel<int>)
                {
                    var e = entity.As<IModel<int>>();
                    e.Key = vKey.To<int>();
                    if (e.Key == 0) return string.Empty;

                    entity.GetByKey();
                }

                return entity.As<IEntityForLogShowName>().Name;
            }
        }
    }
}