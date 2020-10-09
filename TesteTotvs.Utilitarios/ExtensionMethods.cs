using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteTotvs.Utilitarios
{
    public static class ExtensionMethods
    {
        public static int ToInt32(this string value)
        {
            var intReturn = 0;

            if (!string.IsNullOrWhiteSpace(value) && int.TryParse(value, out intReturn))
                return intReturn;
            else
                return 0;
        }

        public static decimal ToDecimal(this string value)
        {
            var decimalReturn = 0m;

            if (!string.IsNullOrWhiteSpace(value) && decimal.TryParse(value, out decimalReturn))
                return decimalReturn; 
            else
                return 0;
        }

        public static bool ToBool(this string value)
        {
            var boolReturn = false;

            if (!string.IsNullOrWhiteSpace(value) && bool.TryParse(value, out boolReturn))
                return boolReturn;
            else
                return false;
        }

        public static int ToInt32<T>(this T soure) where T : IConvertible//enum
        {
            if (!typeof(T).IsEnum)
                throw new ArgumentException("T must be an enumerated type");

            return (int)(IConvertible)soure;
        }
    }
}
