using System;

namespace Kalkulator
{
    /// <summary>
    /// Class using to create a double number from calculator input buttons
    /// </summary>
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

            string num = x.ToString();

            if (isNegative) num = num.Substring(1, num.Length - 2);
            Int64 intP = Convert.ToInt64(x);

            isFloat = (Math.Abs(x - intP) > 0);
            
            if (isFloat)
            {
                int pointIndex = num.LastIndexOf('.');
                intPart = num.Substring(0, pointIndex);
                int offset = intPart.Length + 1;
                floatPart = num.Substring(offset, num.Length - 1 - offset);
            }
            else
                intPart = num;
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
