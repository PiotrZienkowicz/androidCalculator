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
        Number current;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            RequestWindowFeature(Android.Views.WindowFeatures.NoTitle);
            SetContentView (Resource.Layout.Main);

            calc = new Calculator();
            current = new Number();

            FindViewById<TextView>(Resource.Id.buildInfo).Text = System.DateTime.Now.ToString();

            resultView = FindViewById<TextView>(Resource.Id.result);
            historyView = FindViewById<TextView>(Resource.Id.history);

            Button equalsButton = FindViewById<Button>(Resource.Id.equals);
            equalsButton.Click += delegate
            {

                //AlertDialog.Builder alert = new AlertDialog.Builder(this);
                //alert.SetMessage(num.GetNumber.ToString());

                //alert.Show();
                calc.AddCalculation(current, Calculator.OPERATION_TYPE.EQUALS);
                current = calc.GetResult();
                this.Refresh();

            };

            Button pointButton = FindViewById<Button>(Resource.Id.point);
            pointButton.Click += delegate
            {
                current.SetPoint();
                this.Refresh();

            };

            Button signButton = FindViewById<Button>(Resource.Id.sign);
            signButton.Click += delegate
            {
                current.ChangeSign();
                this.Refresh();

            };

            Button additionButton = FindViewById<Button>(Resource.Id.addition);
            additionButton.Click += delegate
            {
                calc.AddCalculation(current, Calculator.OPERATION_TYPE.ADDITION);
                current = new Number();
                this.Refresh();

            };

            Button substrictionButton = FindViewById<Button>(Resource.Id.substriction);
            substrictionButton.Click += delegate
            {
                calc.AddCalculation(current, Calculator.OPERATION_TYPE.SUBSTRACTION);
                current = new Number();
                this.Refresh();

            };

            Button divisionButton = FindViewById<Button>(Resource.Id.division);
            divisionButton.Click += delegate
            {
                calc.AddCalculation(current, Calculator.OPERATION_TYPE.DIVISION);
                current = new Number();
                this.Refresh();

            };

            Button multiplicationButton = FindViewById<Button>(Resource.Id.multiplication);
            multiplicationButton.Click += delegate
            {
                calc.AddCalculation(current, Calculator.OPERATION_TYPE.MULTIPLICATION);
                current = new Number();
                this.Refresh();

            };

            Button percentButton = FindViewById<Button>(Resource.Id.percent);
            percentButton.Click += delegate
            {
                calc.AddCalculation(current, Calculator.OPERATION_TYPE.PERCENT);

                this.Refresh();

            };

            Button backspaceButton = FindViewById<Button>(Resource.Id.backspace);
            backspaceButton.Click += delegate
            {
                current.RemoveDigit();
                this.Refresh();

            };

            Button clearButton = FindViewById<Button>(Resource.Id.clear);
            clearButton.Click += delegate
            {
                current = new Number();
                calc = new Calculator();
                this.Refresh();

            };

            Button memoryCleanButton = FindViewById<Button>(Resource.Id.memoryClean);
            Button memoryResetButton = FindViewById<Button>(Resource.Id.memoryReset);
            Button memoryAddButton = FindViewById<Button>(Resource.Id.memoryAdd);

            Button zeroButton = FindViewById<Button>(Resource.Id.zero);
            zeroButton.Click += delegate
            {
                current.AddDigit(0);
                this.Refresh();

            };
                
            Button oneButton = FindViewById<Button>(Resource.Id.one);
            oneButton.Click += delegate
            {
                current.AddDigit(1);
                this.Refresh();

            };

            Button twoButton = FindViewById<Button>(Resource.Id.two);
            twoButton.Click += delegate
            {
                current.AddDigit(2);
                this.Refresh();

            };

            Button threeButton = FindViewById<Button>(Resource.Id.three);
            threeButton.Click += delegate
            {
                current.AddDigit(3);
                this.Refresh();

            };

            Button fourButton = FindViewById<Button>(Resource.Id.four);
            fourButton.Click += delegate
            {
                current.AddDigit(4);
                this.Refresh();

            };

            Button fiveButton = FindViewById<Button>(Resource.Id.five);
            fiveButton.Click += delegate
            {
                current.AddDigit(5);
                this.Refresh();

            };

            Button sixButton = FindViewById<Button>(Resource.Id.six);
            sixButton.Click += delegate
            {
                current.AddDigit(6);
                this.Refresh();

            };

            Button sevenButton = FindViewById<Button>(Resource.Id.seven);
            sevenButton.Click += delegate
            {
                current.AddDigit(7);
                this.Refresh();

            };

            Button eigthButton = FindViewById<Button>(Resource.Id.eigth);
            eigthButton.Click += delegate
            {
                current.AddDigit(8);
                this.Refresh();

            };

            Button nineButton = FindViewById<Button>(Resource.Id.nine);
            nineButton.Click += delegate
            {
                current.AddDigit(9);
                this.Refresh();
            };
        }

        void Refresh()
        {
            historyView.Text = calc.GetHistory();
            resultView.Text = current.GetNumber.ToString();
        }

    }
}

