using Core.Utility;
using Core.Extensions;
using System.Collections.Generic;
using Core.Utility.Trees;
namespace Core.Business.Entities
{
    public partial class Company : ITreeItem
    {
        public class Tree : Tree<Company> { }

        public static List<Company> GetData(string name, int companyId, int start, int length, string fieldOrder, string dir)
        {
            return Inst.ExeStoreToList(MainDbStore.sp_Companies_GetData, name, companyId, start, length, fieldOrder, dir);
        }
        public static int GetDataCount(string name, int companyId)
        {
            return Inst.SelectFirstValue<int>(MainDbStore.sp_Companies_GetData_Count, name, companyId);
        }

        public object TreeItemId
        {
            get { return CompanyId; }
        }
        public string TreeItemName
        {
            get { return Name; }
            set { Name = value; }
        }
        [TreeParent(Name = "Công ty cha", Field = "ParentId")]
        public object TreeItemParent
        {
            get { return ParentId; }
        }
        public int TreeLevel { set; get; }
    }
}