using System.Collections.Generic;

namespace Core.DataBase.ADOProvider
{
    public class ModelListSave<T>
    {
        public List<T> Upserts { set; get; }
        public List<T> Deletes { set; get; }
        public List<T> Olds { set; get; }
    }
}
