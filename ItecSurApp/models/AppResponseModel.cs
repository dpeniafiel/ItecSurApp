using System;
using System.Collections.Generic;
using System.Text;
using static Xamarin.Forms.Internals.Profile;

namespace ItecSurApp.models
{
    public class AppResponseModel <T>
    {
        public List<T> data { get; set; }
        public string error { get; set; }
    }
}
