namespace Server.Utils
{
    using System.Reflection;
    using System.Collections.Generic;
    using System;

    public static class Mapper
    {
        private static Dictionary<Type, List<PropertyInfo>> propertyCache;

        static Mapper()
        {
            Mapper.propertyCache = new Dictionary<Type, List<PropertyInfo>>();
        }

        public static void Map<T1, T2>(T1 obj1, T2 obj2)
        {

        }

        private static List<PropertyInfo> LoadProperties(Type t)
        {
            if (Mapper.propertyCache.TryGetValue(t, out var res))
            {
                return res;
            }

            res = new List<PropertyInfo>(t.GetProperties());

            Mapper.propertyCache.Add(t, res);

            return res;
        }
    }
}