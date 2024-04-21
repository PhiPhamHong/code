using System.Collections.Generic;
using Core.DataBase.ADOProvider;
namespace Core.Business.Entities
{
    public partial class Language
    {
        public static List<TEntity> SelectForModule<TEntity, TEntityLanguage>(TEntity entity, TEntityLanguage entityLanguage, string keyword, int languageId, int start, int length, string fieldOrder, string dir) 
            where TEntity : ModelBase, new()
            where TEntityLanguage : ModelBase
        {
            return Inst.ExeStoreToList<TEntity>(MainDbStore.sp_Languages_SelectForModule, keyword, entity.GetFieldKeyName(), entity.GetTableName(),
                entityLanguage.GetTableName(), entity.GetFieldByFieldSearchAttribute(), entityLanguage.GetFieldsByLanguageAttribute(),
                languageId, start, length, fieldOrder, dir);
        }

        public static int SelectForModuleCount<TEntity, TEntityLanguage>(TEntity entity, TEntityLanguage entityLanguage, string keyword, int languageId)
            where TEntity : ModelBase, new()
            where TEntityLanguage : ModelBase
        {
            return Inst.SelectFirstValue<int>(MainDbStore.sp_Languages_SelectForModule_Count, keyword, entity.GetFieldKeyName(), entity.GetTableName(),
                entityLanguage.GetTableName(), entity.GetFieldByFieldSearchAttribute(), entityLanguage.GetFieldsByLanguageAttribute(), languageId);
        }
    }
}
