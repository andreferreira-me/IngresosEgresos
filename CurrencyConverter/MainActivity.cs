using Android.App;
using Android.Widget;
using Android.OS;

namespace CurrencyConverter
{
    [Activity(Label = "CurrencyConverter", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView (Resource.Layout.Main);

            Button btnConvert = FindViewById<Button>(Resource.Id.btnCalculate);
            //EditText txtDolares = FindViewById<EditText>(Resource.Id.txtDolares);
            //EditText txtPesos = FindViewById<EditText>(Resource.Id.txtPesos);

            double pesos, dolares;

            btnConvert.Click += delegate
            {
                try
                {
                    //dolares = double.Parse(txtDolares.Text);
                    //pesos = dolares * 19.5;
                    //txtPesos.Text = pesos.ToString();
                }
                catch (System.Exception ex)
                {
                    Toast.MakeText(this, ex.Message, ToastLength.Short).Show();
                }
            };
        }
    }
}

