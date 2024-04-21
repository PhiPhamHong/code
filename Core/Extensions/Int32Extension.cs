namespace Core.Extensions
{
    public static class Int32Extension
    {
        public static bool NullOrZero(this int? value)
        {
            return value == null || value == 0;
        }

        public static bool NotNullAndEqual(this int? t1, int? t2)
        {            
            return !t1.NullOrZero() && !t2.NullOrZero() && t1 == t2;
        }
    }
}