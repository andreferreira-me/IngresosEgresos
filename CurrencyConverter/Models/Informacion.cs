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

namespace Models
{
    public class Informacion
    {
        public double IngresosMexico { get; set; }
        public double IngresosColombia { get; set; }
        public double EgresosMexico { get; set; }
        public double EgresosColombia { get; set; }
    }
}