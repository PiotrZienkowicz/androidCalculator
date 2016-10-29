using Android.App;
using Android.Widget;
using Android.OS;

namespace Kalkulator
{
    [Activity(Label = "Kalkulator", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {

        enum OPERATION { ADDITION, SUBSTRACTION, MULTIPLICATION, DIVISIOM, PERCENT };
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            RequestWindowFeature(Android.Views.WindowFeatures.NoTitle);
            SetContentView (Resource.Layout.Main);

            TextView resultView = FindViewById<TextView>(Resource.Id.result);
            TextView historyView = FindViewById<TextView>(Resource.Id.history);

            Button equalsButton = FindViewById<Button>(Resource.Id.equals);
            Button pointButton = FindViewById<Button>(Resource.Id.point);
            Button signButton = FindViewById<Button>(Resource.Id.sign);
            Button additionButton = FindViewById<Button>(Resource.Id.addition);
            Button substrictionButton = FindViewById<Button>(Resource.Id.substriction);
            Button divisionButton = FindViewById<Button>(Resource.Id.division);
            Button multiplicationButton = FindViewById<Button>(Resource.Id.multiplication);
            Button percentButton = FindViewById<Button>(Resource.Id.percent);

            Button backspaceButton = FindViewById<Button>(Resource.Id.backspace);
            Button clearButton = FindViewById<Button>(Resource.Id.clear);

            Button memoryCleanButton = FindViewById<Button>(Resource.Id.memoryClean);
            Button memoryResetButton = FindViewById<Button>(Resource.Id.memoryReset);
            Button memoryAddButton = FindViewById<Button>(Resource.Id.memoryAdd);

            Button zeroButton = FindViewById<Button>(Resource.Id.zero);
            Button oneButton = FindViewById<Button>(Resource.Id.one);
            Button twoButton = FindViewById<Button>(Resource.Id.two);
            Button threeButton = FindViewById<Button>(Resource.Id.three);
            Button fourButton = FindViewById<Button>(Resource.Id.four);
            Button fiveButton = FindViewById<Button>(Resource.Id.five);
            Button sixButton = FindViewById<Button>(Resource.Id.six);
            Button sevenButton = FindViewById<Button>(Resource.Id.seven);
            Button eigthButton = FindViewById<Button>(Resource.Id.eigth);
            Button nineButton = FindViewById<Button>(Resource.Id.nine);


            equalsButton.Click += delegate
            {
                AlertDialog.Builder alert = new AlertDialog.Builder(this);
                alert.SetMessage("oooo");

                alert.Show();
            };
        }

        
    }
}

