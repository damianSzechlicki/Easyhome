using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace EasyHome.Data
{
    public static class EnumExtensionMethods
    {
        public static TAttribute GetAttribute<TAttribute>(this Enum enumValue) where TAttribute : Attribute
        {
            return enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .First()
                            .GetCustomAttribute<TAttribute>();
        }

        public static string GetDisplayAttributeOrValue(this Enum enumValue)
        {
            var displayName = enumValue.GetAttribute<DisplayAttribute>();
            if (displayName != null)
            {
                return displayName.Name;
            }
            return enumValue.ToString();
        }
    }
}
