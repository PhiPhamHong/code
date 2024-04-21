namespace Core.Utility
{
    public enum Bool : byte
    {
        Null = 0,
        True = 1,
        False = 2
    }

    public static class BoolExtension
    {
        public static bool? ToBool(this Bool @bool)
        {
            switch (@bool)
            {
                case Bool.True: return true;
                case Bool.False: return false;
                default: return null;
            }
        }
    }
}
