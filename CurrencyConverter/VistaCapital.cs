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
using System.IO;
using SQLite;
using Models;

namespace IngresosEgresos
{
    [Activity(Label = "VistaCapital")]
    public class VistaCapital : Activity
    {
        double defaultValue;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.VistaCapital);

            EditText txtCapitalM = FindViewById<EditText>(Resource.Id.txtCapitalM);
            EditText txtCapitalC = FindViewById<EditText>(Resource.Id.txtCapitalC);

            try
            {
                txtCapitalM.Text = Intent.GetDoubleExtra("CapitalM", defaultValue).ToString();
                txtCapitalC.Text = Intent.GetDoubleExtra("CapitalC", defaultValue).ToString();

                var path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                path = Path.Combine(path, "Base.db3");
                var conn = new SQLiteConnection(path);

                var elements = from s in conn.Table<Informacion>() select s;

                foreach (var fila in elements)
                {
                    Toast.MakeText(this, "IngresosMexico: " + fila.IngresosMexico.ToString(), ToastLength.Short).Show();
                    Toast.MakeText(this, "IngresosColombia: " + fila.IngresosColombia.ToString(), ToastLength.Short).Show();
                    Toast.MakeText(this, "EgresosMexico: " + fila.EgresosMexico.ToString(), ToastLength.Short).Show();
                    Toast.MakeText(this, "EgresosColombia: " + fila.EgresosColombia.ToString(), ToastLength.Short).Show();
                }

            }
            catch (Exception ex)
            {
                Toast.MakeText(this, ex.Message, ToastLength.Short).Show();
            }
        }
    }
}