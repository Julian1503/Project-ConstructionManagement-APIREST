using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace GestionObra.Helpers
{
    public static class Capitalize
    {
        public static string CapitalizeFirstLetter(this string value)
        {
            value=value.ToLower();
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value);
        }
    }
}
