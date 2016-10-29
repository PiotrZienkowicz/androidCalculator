using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;

namespace Kalkulator
{
    [Activity(Label = "Kalkulator", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {


        TextView resultView;
        TextView historyView;
        Calculator calc;
        Number currentResultNumber;
        int clickNumber = 0;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            RequestWindowFeature(Android.Views.WindowFeatures.NoTitle);
            SetContentView(Resource.Layout.Main);

            calc = new Calculator();
            currentResultNumber = new Number();

            FindViewById<TextView>(Resource.Id.buildInfo).Text = System.DateTime.Now.ToString();

            resultView = FindViewById<TextView>(Resource.Id.result);
            resultView.Click += delegate
            {
                clickNumber++;
                if (clickNumber == 2)
                    this.ShowInfo();
            };

            historyView = FindViewById<TextView>(Resource.Id.history);
            historyView.Click += delegate
            {
                clickNumber++;
                if (clickNumber == 2)
                    this.ShowInfo();
            };

            Button equalsButton = FindViewById<Button>(Resource.Id.equals);
            equalsButton.Click += delegate
            {
                if (currentResultNumber.GetNumber != 0)
                {
                    calc.AddCalculation(currentResultNumber, Calculator.OPERATION_TYPE.EQUALS);
                    currentResultNumber = calc.GetResult();
                    this.Refresh();
                    this.Restart();
                }
                else
                    this.InvalidOperation("Dividing by 0");


            };

            Button pointButton = FindViewById<Button>(Resource.Id.point);
            pointButton.Click += delegate
            {
                currentResultNumber.SetPoint();
                this.Refresh();

            };

            Button signButton = FindViewById<Button>(Resource.Id.sign);
            signButton.Click += delegate
            {
                currentResultNumber.ChangeSign();
                this.Refresh();

            };

            Button additionButton = FindViewById<Button>(Resource.Id.addition);
            additionButton.Click += delegate
            {
                calc.AddCalculation(currentResultNumber, Calculator.OPERATION_TYPE.ADDITION);
                currentResultNumber = new Number();
                this.Refresh();

            };

            Button substrictionButton = FindViewById<Button>(Resource.Id.substriction);
            substrictionButton.Click += delegate
            {
                calc.AddCalculation(currentResultNumber, Calculator.OPERATION_TYPE.SUBSTRACTION);
                currentResultNumber = new Number();
                this.Refresh();

            };

            Button divisionButton = FindViewById<Button>(Resource.Id.division);
            divisionButton.Click += delegate
            {
                if (currentResultNumber.GetNumber != 0)
                {
                    calc.AddCalculation(currentResultNumber, Calculator.OPERATION_TYPE.DIVISION);
                    currentResultNumber = new Number();
                    this.Refresh();
                }
                else
                {
                    this.InvalidOperation("Dividing by 0");
                }



            };

            Button multiplicationButton = FindViewById<Button>(Resource.Id.multiplication);
            multiplicationButton.Click += delegate
            {
                calc.AddCalculation(currentResultNumber, Calculator.OPERATION_TYPE.MULTIPLICATION);
                currentResultNumber = new Number();
                this.Refresh();

            };

            Button percentButton = FindViewById<Button>(Resource.Id.percent);
            percentButton.Click += delegate
            {


                Number result = calc.GetResult();
                calc = new Calculator();

                calc.AddCalculation(currentResultNumber, Calculator.OPERATION_TYPE.PERCENT);

                this.Refresh();

            };

            Button backspaceButton = FindViewById<Button>(Resource.Id.backspace);
            backspaceButton.Click += delegate
            {
                currentResultNumber.RemoveDigit();
                this.Refresh();

            };

            Button clearButton = FindViewById<Button>(Resource.Id.clear);
            clearButton.Click += delegate
            {
                this.Restart();
                this.Refresh();

            };

            Button memoryCleanButton = FindViewById<Button>(Resource.Id.memoryClean);
            Button memoryResetButton = FindViewById<Button>(Resource.Id.memoryReset);
            Button memoryAddButton = FindViewById<Button>(Resource.Id.memoryAdd);

            Button zeroButton = FindViewById<Button>(Resource.Id.zero);
            zeroButton.Click += delegate
            {
                currentResultNumber.AddDigit(0);
                this.Refresh();

            };

            Button oneButton = FindViewById<Button>(Resource.Id.one);
            oneButton.Click += delegate
            {
                currentResultNumber.AddDigit(1);
                this.Refresh();

            };

            Button twoButton = FindViewById<Button>(Resource.Id.two);
            twoButton.Click += delegate
            {
                currentResultNumber.AddDigit(2);
                this.Refresh();

            };

            Button threeButton = FindViewById<Button>(Resource.Id.three);
            threeButton.Click += delegate
            {
                currentResultNumber.AddDigit(3);
                this.Refresh();

            };

            Button fourButton = FindViewById<Button>(Resource.Id.four);
            fourButton.Click += delegate
            {
                currentResultNumber.AddDigit(4);
                this.Refresh();

            };

            Button fiveButton = FindViewById<Button>(Resource.Id.five);
            fiveButton.Click += delegate
            {
                currentResultNumber.AddDigit(5);
                this.Refresh();

            };

            Button sixButton = FindViewById<Button>(Resource.Id.six);
            sixButton.Click += delegate
            {
                currentResultNumber.AddDigit(6);
                this.Refresh();

            };

            Button sevenButton = FindViewById<Button>(Resource.Id.seven);
            sevenButton.Click += delegate
            {
                currentResultNumber.AddDigit(7);
                this.Refresh();

            };

            Button eigthButton = FindViewById<Button>(Resource.Id.eigth);
            eigthButton.Click += delegate
            {
                currentResultNumber.AddDigit(8);
                this.Refresh();

            };

            Button nineButton = FindViewById<Button>(Resource.Id.nine);
            nineButton.Click += delegate
            {
                currentResultNumber.AddDigit(9);
                this.Refresh();
            };
        }

        void InvalidOperation(string msg)
        {
            historyView.Text = "Invalid operation";
            resultView.Text = msg;
            calc = new Calculator();
            currentResultNumber = new Number();
        }

        void Restart()
        {
            calc = new Calculator();
            currentResultNumber = new Number();
        }

        void Refresh()
        {
            historyView.Text = calc.GetHistory();
            resultView.Text = currentResultNumber.GetNumber.ToString();
        }

        void ShowInfo()
        {
            AlertDialog.Builder alert = new AlertDialog.Builder(this);
            alert.SetTitle("Author");
            alert.SetNeutralButton("OK", delegate {; });
            alert.SetMessage("Piotr Zienkowicz\n2016");
            alert.Show();
            clickNumber = 0;
        }
    }
}

