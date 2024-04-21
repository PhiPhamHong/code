using Core.Attributes.Validators;
using Core.Extensions;
using Core.Utility.Language;
namespace Core.Utility.Trees
{
    public interface ITreeItem
    {
        object TreeItemId { get; }
        string TreeItemName { get; set; }
        object TreeItemParent { get; }
        int TreeLevel { set; get; }
    }

    public static class ITreeItemExtension
    {
        public static void ThrowIfNotSelectParent<TEntity>(this TEntity entity) where TEntity : ITreeItem
        {
            if(entity.TreeItemParent.Equals(0))
                entity.ThrowExceptionOfPropertyParent("Mục cha không hợp lê");
        }

        public static void ThrowExceptionOfPropertyParent<TEntity>(this TEntity entity, string label) where TEntity : ITreeItem
        {
            var property = typeof(TEntity).GetProperty("TreeItemParent");
            var info = property.GetAttribute<TreeParentAttribute>();
            var field = info == null || info.Field.IsNull() ? property.Name : info.Field;
            var fieldText = info == null || info.Name.IsNull() ? field : info.Name;
            throw new ValidatorException(field, LanguageHelper.GetLabel(label).Frmat(LanguageHelper.GetLabel(fieldText)));
        }
    }
}
