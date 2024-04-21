using Core.Sites.Libraries.Business;
namespace Core.Sites.Libraries.Utilities.Sites
{
    public interface IDashBoard
    {
        object ModelConfig { get; }
        void LoadItem(DashBoardItem item);
        CacheUrl.CacheUrlData UrlData { set; get; }
        DashBoardItem DashBoardItem { get; }
    }

    public interface IDashBoard<TConfig> : IDashBoard where TConfig : class, new()
    {
        TConfig Config { get; }
    }

    public interface IDashBoardModule<TConfig> : IDashBoardModule where TConfig : class, new()
    {
        TConfig Config { set; get; }
    }

    public interface IDashBoardModule
    {
        IDashBoard DashBoard { set; get; }
    }
}
