using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;

namespace SampleCode
{
    [Activity(Label = "SampleCode", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
       
        Button btn_Login;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Login);
            btn_Login = (Button)FindViewById(Resource.Id.btn_login);

            btn_Login.Click += (sender, e) =>
            {                
                var intent = new Intent(this, typeof(Worklist));               
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

