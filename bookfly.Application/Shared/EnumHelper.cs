using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace bookfly.Application.Shared
{
    public static class EnumHelper
    {
        public static string GetDisplayName(this Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attribute = field?.GetCustomAttribute<DisplayAttribute>();
            return attribute?.Name ?? value.ToString();
        }
    }
}
