using System;

namespace Contingencia
{
    static class Conversion
    {
        public static string Enletras(string num)
        {
            var dec = "";
            double nro;

            try
            {
                nro = Convert.ToDouble(num);
            }
            catch
            {
                return "";
            }

            var entero = Convert.ToInt64(Math.Truncate(nro));
            var decimales = Convert.ToInt32(Math.Round((nro - entero)*100, 2));

            if (decimales > 0)
            {
                dec = "con " + decimales.ToString() + "/100 M.N.";
            }
            else
            {
                dec = "con 0/100 M.N.";
            }

            var res = UppercaseFirst(ToText(Convert.ToDouble(entero)) + " pesos " +dec);

            return res;
        }

        private static string ToText(double value)
        {
            var num2Text = "";

            value = Math.Truncate(value);

            if (value == 0) num2Text = "cero";
            else if (value == 1) num2Text = "uno";
            else if (value == 2) num2Text = "dos";
            else if (value == 3) num2Text = "tres";
            else if (value == 4) num2Text = "cuatro";
            else if (value == 5) num2Text = "cinco";
            else if (value == 6) num2Text = "seis";
            else if (value == 7) num2Text = "siete";
            else if (value == 8) num2Text = "ocho";
            else if (value == 9) num2Text = "nueve";
            else if (value == 10) num2Text = "diez";
            else if (value == 11) num2Text = "once";
            else if (value == 12) num2Text = "doce";
            else if (value == 13) num2Text = "trece";
            else if (value == 14) num2Text = "catorce";
            else if (value == 15) num2Text = "quince";
            else if (value < 20) num2Text = "dieci" + ToText(value - 10);
            else if (value == 20) num2Text = "veinte";
            else if (value < 30) num2Text = "veinti" + ToText(value - 20);
            else if (value == 30) num2Text = "treinta";
            else if (value == 40) num2Text = "cuarenta";
            else if (value == 50) num2Text = "cincuenta";
            else if (value == 60) num2Text = "sesenta";
            else if (value == 70) num2Text = "setenta";
            else if (value == 80) num2Text = "ochenta";
            else if (value == 90) num2Text = "noventa";
            else if (value < 100) num2Text = ToText(Math.Truncate(value/10)*10) + " y " + ToText(value%10);
            else if (value == 100) num2Text = "cien";
            else if (value < 200) num2Text = "ciento " + ToText(value - 100);
            else if ((value == 200) || (value == 300) || (value == 400) || (value == 600) || (value == 800))
                num2Text = ToText(Math.Truncate(value/100)) + "cientos";
            else if (value == 500) num2Text = "quinietos";
            else if (value == 700) num2Text = "setecientos";
            else if (value == 900) num2Text = "novecientos";
            else if (value < 1000) num2Text = ToText(Math.Truncate(value/100)*100) + " " + ToText(value%100);
            else if (value == 1000) num2Text = "mil";
            else if (value < 2000) num2Text = "mil " + ToText(value%1000);
            else if (value < 1000000)
            {
                num2Text = ToText(Math.Truncate(value/1000)) + " mil";
                if ((value%1000) > 0) num2Text = num2Text + " " + ToText(value%1000);
            }
            else if (value == 1000000) num2Text = "un millon";
            else if (value < 2000000) num2Text = "un millon " + ToText(value%1000000);
            else if (value < 1000000000000)
            {
                num2Text = ToText(Math.Truncate(value/1000000)) + " millones ";
                if ((value - Math.Truncate(value/1000000)*1000000) > 0)
                    num2Text = num2Text + " " + ToText(value - Math.Truncate(value/1000000)*1000000);
            }
            else if (value == 1000000000000) num2Text = "un billon";
            else if (value < 2000000000000)
                num2Text = "un billon " + ToText(value - Math.Truncate(value/1000000000000)*1000000000000);
            else
            {
                num2Text = ToText(Math.Truncate(value/1000000000000)) + " billones";
                if ((value - Math.Truncate(value/1000000000000)*1000000000000) > 0)
                    num2Text = num2Text + " " + ToText(value - Math.Truncate(value/1000000000000)*1000000000000);
            }
            return num2Text;
        }

        static string UppercaseFirst(string s)
        {
            // Check for empty string.
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            // Return char and concat substring.
            return char.ToUpper(s[0]) + s.Substring(1);
        }
    }
}

