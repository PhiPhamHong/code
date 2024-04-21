using System.Linq;
using System.Collections.Generic;
using Core.DataBase.ADOProvider;
using Core.Extensions;
namespace Core.Utility.Trees
{
    public class Tree<TEntity> where TEntity : ModelBase<TEntity>, ITreeItem, new()
    {
        public const string Prefix = "→";
        protected virtual List<TEntity> GetData()
        {
            if (Service == null) return Singleton<TEntity>.Inst.GetAllToList();
            return Singleton<TEntity>.New.InService(Service).GetAllToList();
        }

        public IDataBaseService Service { set; get; }

        private List<TEntity> _data = null;
        public List<TEntity> Data
        {
            get
            {
                if (_data == null) _data = GetData();
                return _data;
            }
        }

        public List<TEntity> GetInTreeView(object parent, bool withparent, string prefix = "")
        {
            var dataReturn = new List<TEntity>();
            var data = Data;

            prefix = prefix.IsNull() ? Prefix : prefix;
            if (withparent && parent.ToString() != "0")
            {
                var item = data.FirstOrDefault(s => s.TreeItemId.Equals(parent));
                NewItem(dataReturn, 0, string.Empty, item);
                GetInTreeView(parent, string.Empty, dataReturn, 1, prefix, false, data);
            }
            else GetInTreeView(parent, string.Empty, dataReturn, 0, prefix, true, data);
            return dataReturn;
        }
        private void GetInTreeView(object parent, string ch, List<TEntity> dataReturn, int level, string prefix, bool isFirst, List<TEntity> source)
        {
            if (!isFirst) { ch = ch + prefix; level++; }

            var dataFind = source.Where(s => s.TreeItemParent.Equals(parent));
            foreach(var item in dataFind)
            {
                NewItem(dataReturn, level, ch, item);
                GetInTreeView(item.TreeItemId, ch, dataReturn, level, prefix, false, source);
            }
        }
        private void NewItem(List<TEntity> dataReturn, int level, string ch, TEntity item)
        {
            item.TreeLevel = level;
            if (ch.IsNull()) item.TreeItemName = item.TreeItemName;
            else item.TreeItemName = ch + " " + item.TreeItemName;
            dataReturn.Add(item);
        }
        private IEnumerable<TEntity> DoFindChild(object parent, List<TEntity> source)
        {
            var childs = source.Where(s => s.TreeItemParent.Equals(parent));
            return childs.Concat(childs.SelectMany(c => DoFindChild(c.TreeItemId, source)));
        }
        public List<TEntity> FindChild(object parent)
        {
            return DoFindChild(parent, Data).ToList();
        }
        public static IEnumerable<TEntity> DoFindParent(TEntity item, List<TEntity> source)
        {
            var parent = source.FirstOrDefault(s => s.TreeItemId.Equals(item.TreeItemParent));
            if (parent != null)
            {
                yield return parent;
                var parents = DoFindParent(parent, source);
                foreach (var p in parents)
                    yield return p;
            }
        }
        public static List<TEntity> FindParent(object id, List<TEntity> source)
        {            
            var item = source.FirstOrDefault(s => s.TreeItemId.Equals(id));
            if (item == null) return new List<TEntity>();
            return DoFindParent(item, source).Reverse().ToList();
        }
        public void ThrownIfParentNotValid(TEntity t)
        {
            if (t.TreeItemId.ToString() != "0" && (t.TreeItemId.Equals(t.TreeItemParent) || FindChild(t.TreeItemId).Any(item => item.TreeItemId.Equals(t.TreeItemParent))))
                t.ThrowExceptionOfPropertyParent("Vui lòng chọn {0}");
        }
    }
}