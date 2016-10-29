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


        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            RequestWindowFeature(Android.Views.WindowFeatures.NoTitle);
            SetContentView(Resource.Layout.Main);

            calc = new Calculator();
            currentResultNumber = new Number();

            // compilation time info
            FindViewById<TextView>(Resource.Id.buildInfo).Text = System.DateTime.Now.ToString();

            // Setup text information 
            resultView = FindViewById<TextView>(Resource.Id.result);
            resultView.Click += delegate
            {
                ShowInfo();
            };

            historyView = FindViewById<TextView>(Resource.Id.history);
            historyView.Click += delegate
            {
                ShowInfo();
            };

            PrepareButtonsEvents();
        }

        void PrepareButtonsEvents()
        {
            #region Function buttons
            // result button
            Button equalsButton = FindViewById<Button>(Resource.Id.equals);
            equalsButton.Click += delegate
            {
                if (currentResultNumber.GetNumber != 0)
                {
                    calc.AddCalculation(currentResultNumber.GetNumber, Calculator.OPERATION_TYPE.EQUALS);
                    currentResultNumber = new Number(calc.GetResult());
                    this.Refresh();
                    this.Restart();
                }
                else
                    this.InvalidOperation("Dividing by 0");


            };

            // restaring button
            Button clearButton = FindViewById<Button>(Resource.Id.clear);
            clearButton.Click += delegate
            {
                this.Restart();
                this.Refresh();

            };

            // memory buttons
            Button memoryCleanButton = FindViewById<Button>(Resource.Id.memoryClean);
            Button memoryResetButton = FindViewById<Button>(Resource.Id.memoryReset);
            Button memoryAddButton = FindViewById<Button>(Resource.Id.memoryAdd);
            #endregion
            #region Operation buttons
            // Operation buttons
            Button additionButton = FindViewById<Button>(Resource.Id.addition);
            additionButton.Click += delegate
            {
                calc.AddCalculation(currentResultNumber.GetNumber, Calculator.OPERATION_TYPE.ADDITION);
                currentResultNumber = new Number();
                this.Refresh();

            };

            Button substrictionButton = FindViewById<Button>(Resource.Id.substriction);
            substrictionButton.Click += delegate
            {
                calc.AddCalculation(currentResultNumber.GetNumber, Calculator.OPERATION_TYPE.SUBSTRACTION);
                currentResultNumber = new Number();
                this.Refresh();

            };

            Button divisionButton = FindViewById<Button>(Resource.Id.division);
            divisionButton.Click += delegate
            {
                if (currentResultNumber.GetNumber != 0)
                {
                    calc.AddCalculation(currentResultNumber.GetNumber, Calculator.OPERATION_TYPE.DIVISION);
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
                calc.AddCalculation(currentResultNumber.GetNumber, Calculator.OPERATION_TYPE.MULTIPLICATION);
                currentResultNumber = new Number();
                this.Refresh();

            };

            Button percentButton = FindViewById<Button>(Resource.Id.percent);
            percentButton.Click += delegate
            {
                double result = calc.GetResult();
                Number resultNumber = new Number(result);
                if (result < 0) resultNumber.ChangeSign();

                //Number result = 
                //calc = new Calculator();

                calc.AddCalculation(currentResultNumber.GetNumber, Calculator.OPERATION_TYPE.PERCENT);

                this.Refresh();

            };

            #endregion
            #region Number editon buttons
            Button backspaceButton = FindViewById<Button>(Resource.Id.backspace);
            backspaceButton.Click += delegate
            {
                currentResultNumber.RemoveDigit();
                this.Refresh();

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
            #endregion
            #region Select number buttons
            Button zeroButton = FindViewById<Button>(Resource.Id.zero);
            zeroButton.Click += delegate
            {
                AddDigit(0);
            };

            Button oneButton = FindViewById<Button>(Resource.Id.one);
            oneButton.Click += delegate
            {
                AddDigit(1);
            };

            Button twoButton = FindViewById<Button>(Resource.Id.two);
            twoButton.Click += delegate
            {
                AddDigit(2);
            };

            Button threeButton = FindViewById<Button>(Resource.Id.three);
            threeButton.Click += delegate
            {
                AddDigit(3);
            };

            Button fourButton = FindViewById<Button>(Resource.Id.four);
            fourButton.Click += delegate
            {
                AddDigit(4);
            };

            Button fiveButton = FindViewById<Button>(Resource.Id.five);
            fiveButton.Click += delegate
            {
                AddDigit(5);
            };

            Button sixButton = FindViewById<Button>(Resource.Id.six);
            sixButton.Click += delegate
            {
                AddDigit(6);
            };

            Button sevenButton = FindViewById<Button>(Resource.Id.seven);
            sevenButton.Click += delegate
            {
                AddDigit(7);
            };

            Button eigthButton = FindViewById<Button>(Resource.Id.eigth);
            eigthButton.Click += delegate
            {
                AddDigit(8);
            };

            Button nineButton = FindViewById<Button>(Resource.Id.nine);
            nineButton.Click += delegate
            {
                AddDigit(9);
            };
            #endregion
        }


        void AddDigit(int i)
        {
            currentResultNumber.AddDigit(i);
            this.Refresh();
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

        int clickNumber = 0;
        void ShowInfo()
        {
            clickNumber++;
            if (clickNumber == 2)
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
}

