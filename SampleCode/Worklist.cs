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
using Android.Database;
using DatabaseWrapper.DataHelper;
using SampleCode;

namespace SampleCode
{
    [Activity(Label = "Worklist")]
    public class Worklist : Activity
    {
        Button btn_Registration;
        Button btn_GoBack;
        private DBManager dbManager;
        List<PateintTableItem> tableItems = new List<PateintTableItem>();
        private ListView listView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Worklist);
            btn_Registration = (Button)FindViewById(Resource.Id.btn_registration);
            btn_GoBack= (Button)FindViewById(Resource.Id.btn_GoBack);
            listView = (ListView)FindViewById(Resource.Id.list);

            dbManager = new DBManager(this);
            dbManager.open();
            ICursor cursor = dbManager.selectListveiwData();
            if (cursor != null)
            {
                if (cursor.Count > 0)
                {
                    while (cursor.MoveToNext())
                    {
                        tableItems.Add(new PateintTableItem()
                        {
                                                        
                            UID = cursor.GetString(1),
                            Name = cursor.GetString(2),
                            ContactNumber = cursor.GetString(3),
                            Age = cursor.GetString(4),
                            Gender = cursor.GetString(5),
                            Address = cursor.GetString(6),
                            State = cursor.GetString(7),
                            District = cursor.GetString(8),                           
                        });
                    }
                }
            }
            if (cursor != null)
                cursor.Close();
            if (tableItems != null)
                listView.Adapter = new WorklistAdapter(this, Resource.Layout.Worklist, tableItems);


            btn_Registration.Click += (sender, e) =>
            {
                var intent = new Intent(this, typeof(Registration));
                StartActivity(intent);
            };

            btn_GoBack.Click += (sender, e) =>
            {
                var intent = new Intent(this, typeof(MainActivity));
                StartActivity(intent);
            };
        }

        protected override void OnResume()
        {
            base.OnResume();
        }

        protected override void OnStart()
        {
            base.OnStart();
        }

        protected override void OnPause()
        {
            base.OnPause();
        }

        protected override void OnStop()
        {
            base.OnStop();
        }
    }
}