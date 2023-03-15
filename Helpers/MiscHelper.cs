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

        public static T Clone<T>(T obj) where T : class
        {
            var instantiated = CreateInstance<T>()();
            if (instantiated is null)
                throw new Exception("AAAAASA");

            foreach(var prop in instantiated.GetType().GetProperties())
            {
                var propValue = prop.GetValue(obj);
                prop.SetValue(instantiated, propValue);
            }

            return instantiated;
        }

        public static void CloneTo<T>(T source, T obj) where T : class
        {
            foreach (var prop in obj.GetType().GetProperties())
            {
                var propValue = prop.GetValue(source);
                prop.SetValue(obj, propValue);
            }
        }
    }
}
