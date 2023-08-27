using System.ComponentModel;
using System.Reflection;

namespace ApiDigitalLesson.Migration.Extension
{
    public static class AttributeExtension
    {
        public static string DescriptionName<T>(this T source)
        {
            var fi = source.GetType().GetField(source.ToString() ?? string.Empty);

            var attributes = (DescriptionAttribute[])fi?.GetCustomAttributes(
                typeof(DescriptionAttribute), false);

            return attributes is {Length: > 0} ? attributes[0].Description : source.ToString();
        }
    }
}