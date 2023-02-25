namespace Helpers
{
    public static class MiscHelper
    {
        public static Func<T?> CreateInstance<T>()
        {
            System.Reflection.ConstructorInfo constructor = (typeof(T)).GetConstructor(Type.EmptyTypes);
            if (ReferenceEquals(constructor, null))
            {
                return () => { return default; };
            }
            else
            {
                return () => { return (T)constructor.Invoke(new object[0]); };
            }
        }
    }
}
