namespace Extensions
{
    public static class TypeExtensions
    {
        public static bool IsGenericList(this Type type)
        {
            foreach (Type @interface in type.GetInterfaces())
            {
                if (@interface.IsGenericType)
                {
                    if (@interface.GetGenericTypeDefinition() == typeof(ICollection<>))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
