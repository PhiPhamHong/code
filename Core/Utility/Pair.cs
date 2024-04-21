namespace Core.Utility
{
    public class Pair<T1Value, T2Value>
    {
        public T1Value T1 { set; get; }
        public T2Value T2 { set; get; }
    }

    public class Pair<T1Value, T2Value, T3Value> : Pair<T1Value, T2Value>
    {
        public T3Value T3 { set; get; }
    }
    public class Pair<T1Value, T2Value, T3Value, T4Value> : Pair<T1Value, T2Value, T3Value>
    {
        public T4Value T4 { set; get; }
    }
}