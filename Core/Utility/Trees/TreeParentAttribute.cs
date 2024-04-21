using Core.Attributes;
namespace Core.Utility.Trees
{
    public class TreeParentAttribute : PropertyInfoAttribute
    {
        public string Field { set; get; }
    }
}
