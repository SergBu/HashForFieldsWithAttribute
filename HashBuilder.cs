using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HashForFieldsAttribute;
public static class HashBuilder
{
    /// <summary>
    /// Формирует строку хешируемую стрку для объекта используя поля помеченные аттрибутом HashField в указанном порядке
    /// </summary>
    public static string GetStringForHash(this object hashable)
    {
        PropertyInfo[] properties = hashable.GetType().GetProperties();

        var propertyList = properties.Where(prop => prop.GetCustomAttribute<HashFieldAttribute>() != null)
            .OrderBy(prop => prop.GetCustomAttribute<HashFieldAttribute>()?.Position);
        if (!properties.Any()) throw new UnprocessableHashObjectException();

        var sb = new StringBuilder();
        foreach (var property in propertyList)
        {
            var value = property.GetValue(hashable);
            if (value is DateTime dateTime)
            {
                sb.Append(dateTime.ToString("dd.MM.yyyy"));
            }
            else
            {
                sb.Append(value?.ToString());
            }
        }
        return sb.ToString();
    }
}

