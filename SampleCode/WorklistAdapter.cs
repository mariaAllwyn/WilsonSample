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
    public class WorklistAdapter : BaseAdapter<PateintTableItem>
    {

        List<PateintTableItem> items;
        Activity context;
        int selectedIndex = -1;
        public WorklistAdapter(Activity context,int activity_radio_button, List<PateintTableItem> items)
        {
            this.context = context;
            this.items = items;
        }
        public void setSelectedIndex(int index)
        {
            selectedIndex = index;
        }
        public override Java.Lang.Object GetItem(int position)
        {
            return position;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override PateintTableItem this[int position]
        {
            get { return items[position]; }
        }

        //Fill in cound here, currently 0
        public override int Count
        {
            get { return items.Count; }
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;
            ViewHolderVA holder = null;
            var item = items[position];
            if (view == null) // no view to re-use, create new
            {
                view = context.LayoutInflater.Inflate(Resource.Layout.CustomWorklist, null);
                holder = new ViewHolderVA();
                holder.Text1 = view.FindViewById<TextView>(Resource.Id.Text1);
                holder.Text2 = view.FindViewById<TextView>(Resource.Id.Text2);

                view.Tag = holder;
            }
            else
            {
                holder = view.Tag as ViewHolderVA;
            }
            if (item != null)
            {
                holder.Text1.Text = item.Name;
                holder.Text2.Text = item.UID + "," + item.Age + "," + item.Gender;
            }
                return view;
        }

       


    }

    public class ViewHolderVA : Java.Lang.Object
    {
        public TextView Text1 { get; set; }
        public TextView Text2 { get; set; }
         public int id { get; set; }       
    }
}