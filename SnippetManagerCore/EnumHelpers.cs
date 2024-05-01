using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SnippetManagerCore
{
    public static class EnumHelpers
    {
        public static Dictionary<T, string> GetValuesWithNames<T>() where T : Enum
        {
            Dictionary<T, string> values = new();
            foreach (T value in Enum.GetValues(typeof(T)))
            {
                var memberInfo = typeof(T).GetMember(value.ToString());
                var attrs = memberInfo[0].GetCustomAttributes(typeof(EnumTextAttribute), false);
                EnumTextAttribute? attr = attrs.Length > 0 ? (EnumTextAttribute)attrs[0] : null;
                if (attr is not null)
                {
                    values.Add(value, attr.Text);
                }
                else
                {
                    values.Add(value, value.ToString());
                }
            }
            return values;
        }
    }
}
