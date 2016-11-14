using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Lakshya_Yatra
{
    public static class ExtensionMethods
    {

        public static string SetFormattedInteger(this String normalText)
        {
            int plainInt = Convert.ToInt32(normalText.Replace(",",""));
            CultureInfo indianNumber = new CultureInfo("en-IN");
            return plainInt.ToString("N0", indianNumber);
        }

        public static int GetInteger(this String formattedNumber)
        {
            formattedNumber = formattedNumber.Replace(",", "");
            return Convert.ToInt32(formattedNumber);
        }

        public static string SetFormattedSingle(this String normalText, string decimalPlaces = "3")
        {
            Single plainSingle = Convert.ToSingle(normalText.Replace(",",""));
            CultureInfo indianNumber = new CultureInfo("en-IN");
            return plainSingle.ToString("N" + decimalPlaces, indianNumber);
        }

        public static Single GetSingle(this String formattedNumber)
        {
            formattedNumber = formattedNumber.Replace(",", "");
            return Convert.ToSingle(formattedNumber);
        }

    }
}
