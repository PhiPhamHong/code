using Core.Attributes;

namespace Core.Utility.Sockets
{
    /// <summary>
    /// Attribute cho các Command là để chỉ ra Command sẽ xử lý các CommandInfo đến từ khối nào
    /// Để tránh dùng CommandInfoAttribute nhiều lần thì CommandInfoAttribute nên đặt
    /// vào các class astract mà định nghĩa Command cho từng luồng. 
    /// Như vậy tất cả các Command cho luồng đó sẽ luôn có Attribute này
    /// </summary>
    public class CommandAttribute : ClassInfoAttribute
    {
        public CommandFrom CommandFrom { set; get; }
    }
}
