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

namespace SampleCode
{
    public class PateintTableItem
    {
        public String UID { get; set; }
        public String Name { get; set; }
        public String ContactNumber { get; set; }
        public String Age { get; set; }
        public String Gender { get; set; }
        public String Address { get; set; }       
        public String State { get; set; }
        public String District { get; set; }
    }
}