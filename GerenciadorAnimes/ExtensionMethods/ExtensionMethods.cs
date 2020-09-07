using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace GerenciadorAnimes.ExtensionMethods
{
    public static partial class ExtensionMethods
    {
        public static int ToInt(this string value)
        {
            int number;

            Int32.TryParse(value, out number);

            return number;
        }

        public static long ToLong(this object @this)
        {
            return Convert.ToInt64(@this);
        }

        public static bool ToBoolean(this object @this)
        {
            return Convert.ToBoolean(@this);
        }
    }
}