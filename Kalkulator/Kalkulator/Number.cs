using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Kalkulator
{
    class Number
    {
        string intPart;
        string floatPart;
        double number = 0;

        bool isFloat;

        public Number()
        {
            intPart = string.Empty;
            floatPart = string.Empty;
            isFloat = false;
        }

        public double GetNumber
        {
            get
            {
                if (intPart.Length != 0)
                {
                    number = Int32.Parse(intPart);
                }
                else
                    number = 0;
                
                if(isFloat && floatPart.Length != 0)
                {
                    double fPart = (Double.Parse(floatPart) / Math.Pow(10, floatPart.Length));
                    number += fPart;
                }
                return number;
            }
        }

        public void ChangeSign()
        {
            number = -number;
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
            if (!isFloat) intPart.Remove(intPart.Length - 1);
            else floatPart.Remove(floatPart.Length - 1);
        }

        public void SetPoint()
        {
            isFloat = true;
        }
    }
}
