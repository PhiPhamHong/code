namespace Core.Extensions
{
    public static class SingleExtension
    {
        public static bool NullOrZero(this float? value)
        {
            return value == null || value == 0;
        }
    }
}