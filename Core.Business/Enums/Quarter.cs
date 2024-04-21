using Core.Attributes;
namespace Core.Business.Enums
{
    public enum Quarter : byte
    {
        [FieldInfo(Name = "Quý 1")] Quy1 = 1,
        [FieldInfo(Name = "Quý 2")] Quy2 = 2,
        [FieldInfo(Name = "Quý 3")] Quy3 = 3,
        [FieldInfo(Name = "Quý 4")] Quy4 = 4
    }
}