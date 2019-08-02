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
using DatabaseWrapper.DataHelper;
using Android.Views.InputMethods;

namespace SampleCode
{
    [Activity(Label = "Registration")]
    public class Registration : Activity
    {
        Button btn_SaveGO;
        EditText edt_UID;
        EditText edt_Name;
        EditText edt_ContactNo;
        EditText edt_Age;
        RadioButton rdb_Male;
        RadioButton rdb_Female;
        string GenderValues = string.Empty;
        EditText edt_Address;
        EditText edt_State;
        EditText edt_District;
        private DBManager dbManager;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Registration);
            btn_SaveGO = (Button)FindViewById(Resource.Id.btn_SaveAndGo);
            edt_UID = (EditText)FindViewById(Resource.Id.edt_PatId);
            edt_Name = (EditText)FindViewById(Resource.Id.edt_PatName);
            edt_ContactNo = (EditText)FindViewById(Resource.Id.edt_ContactNumber);
            edt_Age = (EditText)FindViewById(Resource.Id.edt_Age);
            edt_Address = (EditText)FindViewById(Resource.Id.edt_Address);
            edt_State = (EditText)FindViewById(Resource.Id.edt_State);
            edt_District = (EditText)FindViewById(Resource.Id.edt_District);
            rdb_Male = (RadioButton)FindViewById(Resource.Id.rdo_Male);
            rdb_Female = (RadioButton)FindViewById(Resource.Id.rdo_Female);
            dbManager = new DBManager(this);            

            rdb_Male.Click += Rdb_Male_Click;
            btn_SaveGO.Click += (sender, e) =>
            {
                AlertDialog.Builder builderForUIDExists = new AlertDialog.Builder(this);
                builderForUIDExists.SetTitle("Alert");
                builderForUIDExists.SetMessage("Member already exists");
                builderForUIDExists.SetCancelable(false);
                builderForUIDExists.SetPositiveButton("OK", (object ssender, DialogClickEventArgs se) =>
                {
                    edt_UID.RequestFocus();
                    return;
                    
                });

                AlertDialog alertForUIDExists = builderForUIDExists.Create();


                if (!ValidateMandatoryFields())
                {
                    return;
                }

                dbManager.open();              
                bool IsUIDDoesntExists = dbManager.PSGetPatientUIdCount(edt_UID.Text);
                if (IsUIDDoesntExists)
                {
                    dbManager.insertPatient(edt_UID.Text, edt_Name.Text, edt_ContactNo.Text, edt_Age.Text, GenderValues, edt_Address.Text, edt_State.Text, edt_District.Text);
                    var intent = new Intent(this, typeof(Worklist));
                    StartActivity(intent);
                }
                else
                {
                    alertForUIDExists.Show();
                }

                
            };
        }
        private bool ValidateMandatoryFields()
        {
            if (!ValidatePatientRegistration(edt_UID.Text, "UID"))
            {
                edt_UID.RequestFocus();
                InputMethodManager imm = (InputMethodManager)GetSystemService(Context.InputMethodService);
                imm.ShowSoftInput(edt_UID, InputMethodManager.ShowImplicit);
                return false;
            }
            if (!ValidatePatientRegistration(edt_Name.Text, "Name"))
            {
                edt_Name.RequestFocus();
                InputMethodManager imm = (InputMethodManager)GetSystemService(Context.InputMethodService);
                imm.ShowSoftInput(edt_Name, InputMethodManager.ShowImplicit);
                return false;
            }
            if (!ValidatePatientRegistration(edt_ContactNo.Text, "Contact Number"))
            {
                edt_ContactNo.RequestFocus();
                InputMethodManager imm = (InputMethodManager)GetSystemService(Context.InputMethodService);
                imm.ShowSoftInput(edt_ContactNo, InputMethodManager.ShowImplicit);
                return false;
            }
            if (!ValidatePatientRegistration(edt_Age.Text, "Age"))
            {
                edt_Age.RequestFocus();
                InputMethodManager imm = (InputMethodManager)GetSystemService(Context.InputMethodService);
                imm.ShowSoftInput(edt_Age, InputMethodManager.ShowImplicit);
                return false;
            }
            if (!ValidatePatientRegistration(GenderValues, "Gender"))
            {
                edt_UID.ClearFocus();
                edt_Name.ClearFocus();
                edt_ContactNo.ClearFocus();
                edt_Age.ClearFocus();
                return false;
            }           

            if (!ValidatePatientRegistration(edt_Address.Text, "Address"))
            {
                edt_Address.RequestFocus();
                InputMethodManager imm = (InputMethodManager)GetSystemService(Context.InputMethodService);
                imm.ShowSoftInput(edt_State, InputMethodManager.ShowImplicit);
                return false;
            }

            if (!ValidatePatientRegistration(edt_State.Text, "State"))
            {
                edt_State.RequestFocus();
                InputMethodManager imm = (InputMethodManager)GetSystemService(Context.InputMethodService);
                imm.ShowSoftInput(edt_State, InputMethodManager.ShowImplicit);
                return false;
            }
            if (!ValidatePatientRegistration(edt_District.Text, "District"))
            {
                edt_District.RequestFocus();
                InputMethodManager imm = (InputMethodManager)GetSystemService(Context.InputMethodService);
                imm.ShowSoftInput(edt_District, InputMethodManager.ShowImplicit);
                return false;
            }
            return true;
        }

        bool ValidatePatientRegistration(string sValidateUserEntry, string sMessageText)
        {
            AlertDialog.Builder builder = new AlertDialog.Builder(this);
            builder.SetTitle("Alert");
            builder.SetMessage("Please provide " + "'" + sMessageText + "'" + " to proceed further");
            builder.SetCancelable(false);
            builder.SetPositiveButton("OK", (object sender, DialogClickEventArgs e) =>
            {
                
            });

            AlertDialog alert = builder.Create();

            if (sMessageText == "Age")
            {
                AlertDialog.Builder builderForAge = new AlertDialog.Builder(this);
                builderForAge.SetTitle("Alert");
                builderForAge.SetMessage("Please enter valid 'Age' between 0 and 150");
                builderForAge.SetCancelable(false);
                builderForAge.SetPositiveButton("OK", (object sender, DialogClickEventArgs e) =>
                {
                    
                });

                AlertDialog alertForAge = builderForAge.Create();

                if (edt_Age.Text == null || edt_Age.Text == string.Empty)
                {
                    alert.Show();
                    return false;
                }
                else if (Convert.ToInt32(edt_Age.Text) > 150 || Convert.ToInt32(edt_Age.Text) <= 0)               
                {
                    alertForAge.Show();
                    return false;
                }
            }           
            
            if (string.IsNullOrEmpty(sValidateUserEntry))
            {
                alert.Show();
                return false;
            }           
            return true;
        }

        private void Rdb_Male_Click(object sender, EventArgs e)
        {
            edt_UID.ClearFocus();
            edt_Name.ClearFocus();
            edt_ContactNo.ClearFocus();
            edt_Age.ClearFocus();
            edt_Address.ClearFocus();
            edt_State.ClearFocus();
            edt_District.ClearFocus();
            RadioButton rbGender = (RadioButton)sender;
            GenderValues = rbGender.Text;
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
