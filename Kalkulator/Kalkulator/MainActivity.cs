using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using static Kalkulator.Calculator;

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

            // hide titlebar
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
            Button equalsButton = FindViewById<Button>(Resource.Id.equals);
            equalsButton.Click += delegate
            {
                DoOperation(OPERATION_TYPE.EQUALS);
            };

            Button additionButton = FindViewById<Button>(Resource.Id.addition);
            additionButton.Click += delegate
            {
                DoOperation(OPERATION_TYPE.ADDITION);
            };

            Button substrictionButton = FindViewById<Button>(Resource.Id.substriction);
            substrictionButton.Click += delegate
            {
                DoOperation(OPERATION_TYPE.SUBSTRACTION);
            };

            Button divisionButton = FindViewById<Button>(Resource.Id.division);
            divisionButton.Click += delegate
            {
                DoOperation(OPERATION_TYPE.DIVISION);
            };

            Button multiplicationButton = FindViewById<Button>(Resource.Id.multiplication);
            multiplicationButton.Click += delegate
            {
                DoOperation(OPERATION_TYPE.MULTIPLICATION);
            };

            Button percentButton = FindViewById<Button>(Resource.Id.percent);
            percentButton.Click += delegate
            {

                DoOperation(OPERATION_TYPE.PERCENT);
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

        void DoOperation(OPERATION_TYPE type)
        {
            if(calc.IsEmpty())
            {
                if(calc.IsRestarted && currentResultNumber.GetNumber == 0)
                {
                    currentResultNumber = new Number(calc.LastResult);
                }

                calc.AddCalculation(currentResultNumber.GetNumber, type);

                if (type != OPERATION_TYPE.EQUALS)
                {
                    currentResultNumber = new Number();
                    this.Refresh();
                }
                else
                {
                    currentResultNumber = new Number(calc.GetResult());
                    this.Refresh();
                    this.Restart();
                }
            }
            else
            {
                bool canCalculate = true;
                //if ((type == OPERATION_TYPE.EQUALS) && calc.CheckLastOperation(OPERATION_TYPE.DIVISION))
                if ( calc.CheckLastOperation(OPERATION_TYPE.DIVISION))

                {
                    if (currentResultNumber.GetNumber == 0)
                    {
                        InvalidOperation("Dividing by 0");
                        canCalculate = false;
                    }
                }

                if (canCalculate)
                {
                    calc.AddCalculation(currentResultNumber.GetNumber, type);
                    currentResultNumber = new Number();
                    this.Refresh();
                }

                if ((type == OPERATION_TYPE.EQUALS) && canCalculate)
                {
                    currentResultNumber = new Number(calc.GetResult());
                    this.Refresh();
                    this.Restart();
                }
            }
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
        }

        void Restart()
        {
            calc.Restart();
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
                alert.SetMessage("Created by Piotr Zienkowicz (2016)");
                alert.Show();
                clickNumber = 0;
            }
        }
    }
}

