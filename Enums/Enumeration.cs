using System.Reflection;

namespace Invoices.Enums
{
    public class Enumeration
    {
        public Enumeration() { }

        public int Id { get; set; }
        public string Name { get; set; }

        public static IEnumerable<T> GetAll<T>() where T : Enumeration
        {
            var fields = typeof(T).GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);
            return fields.Where(x => x.FieldType == typeof(T)).Select(f => f.GetValue(null)).Cast<T>();
        }
    }

}
