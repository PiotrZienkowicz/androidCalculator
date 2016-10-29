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
    class Calculator
    {
        public string Result { get; set; }
        public string History { get; set; }

        public double CurrentNumber { get; set; }
        public double LastNumber { get; set; }

        public Calculator()
        {
            LastNumber = 0;
            CurrentNumber = 0;
        }

        public void Add()
        {
            Result = (LastNumber + CurrentNumber).ToString();
        }
        public void Sub()
        {
            Result = (LastNumber + CurrentNumber).ToString();
        }
        public void Multi()
        {
            Result = (LastNumber + CurrentNumber).ToString();
        }
        public void Div()
        {
            Result = (LastNumber + CurrentNumber).ToString();
        }
        public void Percent()
        {

        }
    }
}