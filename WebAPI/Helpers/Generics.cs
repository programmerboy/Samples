namespace Samples.WebAPI.Helpers
{
    public class Generics
    {

    }

    public static class Arrays<T>
    {
        private static readonly T[] empty = new T[0];
        public static T[] Empty { get { return empty; } }
    }
}