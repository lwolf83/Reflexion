using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ReflectionTest
{
    class ReflectedClass
    {
        private Int32 _id;
        private string _id2;
        public Int32 _id3;
        private String Name { get; set; }
        public int LastName { get; set; }

        public ReflectedClass()
        {
            _id = 0;
            Name = String.Empty;
        }

        private void DoSomething()
        {
            Console.WriteLine("I am doing something ...");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var reflected = new ReflectedClass();
            List<PropertyInfo> propertyInfos = GetAllProperties(reflected, typeof(int));
            DisplayTab<PropertyInfo>(propertyInfos);
            Console.WriteLine();

            List<FieldInfo> fieldInfos = GetAllFields(reflected, typeof(string));
            DisplayTab<FieldInfo>(fieldInfos);
            Console.WriteLine();

            List<MethodInfo> methodInfos = GetAllMethods(reflected);
            DisplayTab<MethodInfo>(methodInfos);
            Console.WriteLine();

        }

        private static List<MethodInfo> GetAllMethods(object reflected)
        {
            Type objectType = reflected.GetType();
            MethodInfo[] properties = objectType.GetMethods(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
            return properties.ToList();
        }


        private static List<FieldInfo> GetAllFields(object reflected, Type type)
        {
            Type objectType = reflected.GetType();
            FieldInfo[] properties = objectType.GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
            return properties.Where(x => x.FieldType == type).ToList();
        }

        private static List<PropertyInfo> GetAllProperties(object reflected, Type type)
        {
            Type objectType = reflected.GetType();
            PropertyInfo[] properties = objectType.GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
            return properties.Where(x => x.PropertyType == type).ToList();
        }

        private static void DisplayTab<T>(IEnumerable<T> tab)
        {
            foreach(var t in tab)
            {
                Console.WriteLine("\t" + t);
            }
        }

    }
}
