namespace Core.DataBase.ADOProvider.Attributes
{
    public class LogEntityDetail
    {
        public string Field { set; get; } // Tên trường bị thay đổi trong DataBase
        public string Name { set; get; }  // Nhãn label
        public object OldValue { set; get; }
        public object NewValue { set; get; }

        public string TypeRef { set; get; }
    }
}