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

namespace DatabaseWrapper.DataHelper
{
    public class DatabaseHelper : SQLiteOpenHelper
    {
        private static readonly string TAG = "DatabaseHelper";
        // Database Info
        // Database Information
        public static readonly String DB_NAME = "Registration.db";
        // database version
        public static readonly int DB_VERSION = 1;

        // Table Names
        public static readonly String TABLE_PatientInfo = "tbl_PatientInfo";
        // tbl_PatientInfo Table columns
        public static readonly String ID = "_id";
        public static readonly String UID = "UID";
        public static readonly String Name = "Name";
        public static readonly String ContactNumber = "ContactNumber";
        public static readonly String Age = "Age";
        public static readonly String Sex = "Sex";
        public static readonly String Address = "Address";
        public static readonly String State = "State";
        public static readonly String District = "District";      
       

        
        // Creating table query
        private static readonly String CREATE_Patient_TABLE = "create table " + TABLE_PatientInfo + "("
            + ID + " INTEGER PRIMARY KEY AUTOINCREMENT,"
            + UID + " TEXT NOT NULL,"
            + Name + " TEXT NOT NULL,"
            + ContactNumber + " TEXT NOT NULL,"
            + Age + " TEXT NOT NULL,"
            + Sex + " TEXT NOT NULL,"
            + Address + " TEXT NOT NULL,"
            + State + " TEXT NOT NULL,"           
            + District + " TEXT NOT NULL);";


        /// Singleton Pattern
        private static DatabaseHelper sInstance;

        public static DatabaseHelper getInstance(Context context)
        {
            // Use the application context, which will ensure that you 
            // don't accidentally leak an Activity's context.
            // See this article for more information: http://bit.ly/6LRzfx
            if (sInstance == null)
            {
                sInstance = new DatabaseHelper(context.ApplicationContext);
            }
            Log.Info(TAG, "getInstance: " + context.ApplicationContext);
            return sInstance;
        }

        /// <summary>
        ///Constructor should be private to prevent direct instantiation.
        ///Make a call to the static method "getInstance()" instead.  
        /// </summary>
        /// <param name="context"></param>
       /* private DatabaseHelper(Context context) : base(context, DB_NAME, null, DB_VERSION)
        {
            //context.ApplicationContext.GetDir

            //if (android.os.Build.VERSION.SDK_INT >= 17)
            //{
            //    DB_PATH = context.GetApplicationInfo().dataDir + "/databases/";
            //}
            //else
            //{
            //    DB_PATH = "/data/data/" + context.getPackageName() + "/databases/";
            //}

        }*/
        public DatabaseHelper(Context context) : base(context, DB_NAME, null, DB_VERSION)
        {
            //context.ApplicationContext.GetDir

            //if (android.os.Build.VERSION.SDK_INT >= 17)
            //{
            //    DB_PATH = context.GetApplicationInfo().dataDir + "/databases/";
            //}
            //else
            //{
            //    DB_PATH = "/data/data/" + context.getPackageName() + "/databases/";
            //}

        }
        public override void OnCreate(SQLiteDatabase db)
        {
            db.ExecSQL(CREATE_Patient_TABLE);
            Log.Info(TAG, "OnCreate Method: " + CREATE_Patient_TABLE + "... new ");
        }

        public override void OnUpgrade(SQLiteDatabase db, int oldVersion, int newVersion)
        {
            if (oldVersion != newVersion)
            {
                // Simplest implementation is to drop all old tables and recreate them
                db.ExecSQL("DROP TABLE IF EXISTS " + TABLE_PatientInfo);                
                OnCreate(db);

                Log.Info(TAG, "OnUpgrade Method: " + oldVersion + "... new" + newVersion);
            }
            Log.Info(TAG, "OnUpgrade Method: " + oldVersion + "... OUTSIDE" + newVersion);
        }
    }
}