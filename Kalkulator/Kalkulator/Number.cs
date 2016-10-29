using System;

namespace Kalkulator
{
    class Number
    {
        string intPart;
        string floatPart;
        double number = 0;

        bool isFloat;
        bool isNegative;

        public Number()
        {
            intPart = string.Empty;
            floatPart = string.Empty;
            isFloat = false;
            isNegative = false;
        }

        public Number(double x)
        {
            isNegative = (x < 0);

            Int64 intP = Convert.ToInt64(x);
            isFloat = ((x - intP) > 0);

            intPart = Convert.ToString(intP);
            if(isFloat)
            {
                floatPart = Convert.ToString(x - intP);
                floatPart = floatPart.Substring(2, floatPart.Length - 2);
            }
        }

        public double GetNumber
        {
            get
            {
                if (intPart.Length != 0)
                {
                    number = Int64.Parse(intPart);
                }
                else
                    number = 0;

                if (isFloat && floatPart.Length != 0)
                {
                    double fPart = (Double.Parse(floatPart) / Math.Pow(10, floatPart.Length));
                    number += fPart;
                }
                return (!isNegative) ? number : -number;
            }
        }

        public void ChangeSign()
        {
            isNegative = !isNegative;
        }

        public void AddDigit(int digit)
        {
            if (!isFloat)
            {
                if (!(digit == 0 && intPart.Length == 0))
                    intPart += digit;
            }
            else floatPart += digit;
        }

        public void RemoveDigit()
        {
            if (!isFloat)
            {
                if (intPart.Length > 0)
                    intPart = intPart.Substring(0, intPart.Length - 1);

                if (intPart.Length == 0) isNegative = false;
            }
            else
            {
                if (floatPart.Length > 0)
                    floatPart = floatPart.Substring(0, floatPart.Length - 1);

                if (floatPart.Length == 0) isFloat = false;
            }
        }

        public void SetPoint()
        {
            isFloat = true;
        }
    }
}
