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
using Android.Database.Sqlite;
using Android.Util;
using Android.Database;

namespace DatabaseWrapper.DataHelper
{
    public class DBManager
    {
        private DatabaseHelper dbHelper;
        private static readonly string TAG = "DatabaseHelper";

        private Context context;

        private SQLiteDatabase database;

        public DBManager(Context c)
        {
            context = c;
        }

        public DBManager open()
        {
            dbHelper = new DatabaseHelper(context);
            // Create and/or open the database for writing           
            database = dbHelper.WritableDatabase;
            Log.Info(TAG, "DbHelper Opening Version: " + this.database.Version);
            return this;
        }
        public void close()
        {
            dbHelper.Close();
        }

        public void insertPatient(String UID, String Name, String ContactNumber, String Age, String Sex, String Address, String State, String District)
        {
            try
            {              
               
                ContentValues contentValue = new ContentValues();
                contentValue.Put(DatabaseHelper.UID, UID);
                contentValue.Put(DatabaseHelper.Name, Name);
                contentValue.Put(DatabaseHelper.ContactNumber, ContactNumber);
                contentValue.Put(DatabaseHelper.Age, Age);
                contentValue.Put(DatabaseHelper.Sex, Sex);
                contentValue.Put(DatabaseHelper.Address, Address);
                contentValue.Put(DatabaseHelper.State, State);
                contentValue.Put(DatabaseHelper.District, District);               
                database.Insert(DatabaseHelper.TABLE_PatientInfo, null, contentValue);                
            }
            catch (Exception ex)
            {
                Log.Info("insertPatient", ex.Message);
            }
        }

        public ICursor selectListveiwData()
        {
            try
            {
                ICursor cursor = database.RawQuery("SELECT * FROM tbl_PatientInfo order by _id desc", null);
                return cursor;
            }
            catch (Exception ex)
            {
                Log.Info("PSselectListveiwDataBasedOnUser", ex.Message);
                return null;
            }
        }

        public bool PSGetPatientUIdCount(string UID)
        {
            long patientUId = 0;
            try
            {

                ICursor cursor = database.RawQuery("select Count(UID) from tbl_PatientInfo where UID = '" + UID + "'", null);
                if (cursor != null)
                {
                    cursor.MoveToFirst();
                }
                patientUId = cursor.GetInt(0);
                if (patientUId > 0)
                    return false;
                else
                    return true;

            }
            catch (Exception ex)
            {
                Log.Info("PSGetPatientUIdCount", ex.Message);
                return false;
            }
        }
    }
}