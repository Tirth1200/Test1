using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace Distanceconversion_Test1
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        EditText etOutput, etInput;
        RadioButton rdbKM, rdbMK, rdbCI, rdbIC;
        Button btnConvert;
        double result;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            etOutput = (EditText)FindViewById(Resource.Id.etout);
            etInput = (EditText)FindViewById(Resource.Id.etin);
            rdbMK = (RadioButton)FindViewById(Resource.Id.rdMK);
            rdbKM = (RadioButton)FindViewById(Resource.Id.rdKM);
            rdbCI = (RadioButton)FindViewById(Resource.Id.rdCI);
            rdbIC = (RadioButton)FindViewById(Resource.Id.rdIC);
            btnConvert = (Button)FindViewById(Resource.Id.btConvert);
            btnConvert.Click += delegate
            {
                if (etInput.Text != "")
                {
                    double input = double.Parse(etInput.Text);
              
                    if (rdbKM.Checked)
                    {
                        result = input * 0.621371;
                    }
                    else if (rdbMK.Checked)
                    {
                        result = input * 1.60934;
                    }
                    else if (rdbCI.Checked)
                    {
                        result = input * 0.393701;
                    }
                    else if (rdbIC.Checked)
                    {
                        result = input * 2.54;
                    }
                    else
                    {
                        Toast.MakeText(this, "Please select the type of conversion", ToastLength.Long).Show();
                    }

                    etOutput.Text = result.ToString();
                }
                else
                {
                    Toast.MakeText(this, "Please enter an Input", ToastLength.Long).Show();
                }
                
            };
        }
            

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View) sender;
            Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
                .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
        }
	}
}

