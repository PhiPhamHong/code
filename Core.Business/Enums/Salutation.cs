using Core.Attributes;

namespace Core.Business.Enums
{
    public enum Salutation : byte
    {
        [FieldInfo(Name = "Mr")] Mr = 0,
        [FieldInfo(Name = "Mrs")] Mrs = 1,
        [FieldInfo(Name = "Mss")] Mss = 2
    }
}
