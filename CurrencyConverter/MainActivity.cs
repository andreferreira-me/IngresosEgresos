using Android.App;
using Android.Widget;
using Android.OS;
using System;
using Android.Content;
using System.IO;
using SQLite;
using Models;

namespace IngresosEgresos
{
    [Activity(Label = "IngresosEgresos", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        double CapitalM, CapitalC;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView (Resource.Layout.Main);

            var path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            path = Path.Combine(path, "Base.db3");
            var conn = new SQLiteConnection(path);
            conn.CreateTable<Informacion>();

            EditText txtIngresosM = FindViewById<EditText>(Resource.Id.txtIngresosM);
            EditText txtEgresosM = FindViewById<EditText>(Resource.Id.txtEgresosM);
            EditText txtIngresosC = FindViewById<EditText>(Resource.Id.txtIngresosC);
            EditText txtEgresosC = FindViewById<EditText>(Resource.Id.txtEgresosC);
            Button btnCalculate = FindViewById<Button>(Resource.Id.btnCalculate);

            double IngresosM, EgresosM, IngresosC, EgresosC;

            btnCalculate.Click += delegate
            {
                try
                {
                    IngresosM = double.Parse(txtIngresosM.Text);
                    EgresosM = double.Parse(txtEgresosM.Text);
                    IngresosC = double.Parse(txtIngresosC.Text);
                    EgresosC = double.Parse(txtEgresosC.Text);

                    CapitalM = IngresosM - EgresosM;
                    CapitalC = IngresosC - EgresosC;

                    var informacion = new Informacion();
                    informacion.IngresosMexico = IngresosM;
                    informacion.IngresosColombia = IngresosC;
                    informacion.EgresosMexico = EgresosM;
                    informacion.EgresosColombia = EgresosC;
                    conn.Insert(informacion);

                    Toast.MakeText(this, "Saved in SQLite", ToastLength.Short).Show();

                    Load();
                }
                catch (System.Exception ex)
                {
                    Toast.MakeText(this, ex.Message, ToastLength.Short).Show();
                }
            };
        }

        public void Load()
        {
            Intent intent = new Intent(this, typeof(VistaCapital));
            intent.PutExtra("CapitalM", CapitalM);
            intent.PutExtra("CapitalC", CapitalC);
            StartActivity(intent);
        }
    }
}

