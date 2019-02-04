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
            if (obj1 == null || obj2 == null)
            {
                return;
            }

            var p1 = LoadProperties(typeof(T1));
            var p2 = LoadProperties(typeof(T2));

            foreach (var property in p1)
            {
                if (p2.Contains(property))
                {
                    property.SetValue(obj1, property.GetValue(obj1));
                }
            }
        }

        public static void Copy<T1>(T1 a, T1 b)
        {
            if (a == null || b == null)
            {
                return;
            }

            var properties = LoadProperties(typeof(T1));

            foreach (var property in properties)
            {
                property.SetValue(b, property.GetValue(a));
            }
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