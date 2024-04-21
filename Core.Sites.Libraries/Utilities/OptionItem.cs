using Core.Web.WebBase;
namespace Core.Sites.Libraries.Utilities
{
    public class OptionItem
    {
        public abstract class Base : IAjax
        {
            protected abstract object GetData();

            public void DoGetData()
            {
                this.SetData(GetType().Name, GetData());
            }
        }


    }
}