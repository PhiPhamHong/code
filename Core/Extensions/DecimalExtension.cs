namespace Core.Extensions
{
    public static class DecimalExtension
    {
        public static bool NullOrZero(this decimal? value)
        {
            return value == null || value == 0;
        }
    }
}