using System;
using System.Collections.Generic;
using System.Text;

namespace Practivas.test.NumerosRomanos
{
    public class RomanNumberTextRepresentation
    {
        public const string ROMAN_NUMBER_HAS_NO_ZERO = "No hay 0";

        public RomanNumberTextRepresentation()
        {
        }

        public string Of(int aNUmber)
        {
            if (aNUmber == 0)
                throw new InvalidOperationException(ROMAN_NUMBER_HAS_NO_ZERO);

            var aStringBuilder = new StringBuilder();
            int units = aNUmber % 10;
            int tens = (aNUmber / 10) % 10;
            int hundreds = (aNUmber / 100) % 10;

            ConvertDigitUsing(hundreds, aStringBuilder, "C", "D", "M");
            ConvertDigitUsing(tens, aStringBuilder, "X", "L", "C");
            ConvertDigitUsing(units, aStringBuilder, "I", "V", "X");

            return aStringBuilder.ToString();
        }

        private static void ConvertDigitUsing(int aNUmber, StringBuilder aStringBuilder, string asOne, string asFive, string asTen)
        {
            if (aNUmber >= 1 && aNUmber <= 3)
            {
                for (int i = 1; i <= aNUmber; i++)
                    aStringBuilder.Append(asOne);
            }

            if (aNUmber == 4)
                aStringBuilder.Append(asOne).Append(asFive);

            if (aNUmber >= 5 && aNUmber <= 8)
            {
                aStringBuilder.Append(asFive);
                for (int i = 1; i <= aNUmber - 5; i++)
                    aStringBuilder.Append(asOne);
            }

            if (aNUmber == 9)
                aStringBuilder.Append(asOne).Append(asTen);
        }
    }
}