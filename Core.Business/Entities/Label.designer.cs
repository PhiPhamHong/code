using System.Collections.Generic;
using Core.Extensions;
namespace Core.Business.Entities
{
    public partial class Label
    {
        public static List<LabelItem> GetAllLabelItems()
        {
            return Inst.ExeStoreToList<LabelItem>(MainDbStore.sp_Languages_Labels_GetAll);
        }

        public static IEnumerable<LabelItem> GetAllLabelItems(int companyId, int languageId)
        {
            return Inst.ExeStoreCastToList<LabelItem>("sp_Languages_Labels_GetByLanguageId", companyId, languageId);
        }

        public class LabelItem
        {
            public int LanguageId { set; get; }
            public string Value { set; get; }
            public string Lexicon { set; get; }
            public bool ForAdmin { set; get; }

            public override string ToString()
            {
                return Lexicon + "_" + LanguageId;
            }
        }
    }
}
