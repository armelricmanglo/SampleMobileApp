using System;
using System.IO;
using SampleMobileApp.Data;
using Xamarin.Forms;
namespace SampleMobileApp
{
    public partial class App : Application
    {
        static SubjectDatabase database;
        static TDLDatabase database1;
        // Create the database connection as a singleton.
        public static SubjectDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new
                    SubjectDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                    "Notes.db3"));
                }
                return database;
            }
        }
        public static TDLDatabase Database1
        {
            get
            {
                if (database1 == null)
                {
                    database1 = new
                    TDLDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                    "Notes.db3"));
                }
                return database1;
            }
        }
        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
        }
        protected override void OnStart()
        {
        }
        protected override void OnSleep()
        {
        }
        protected override void OnResume()
        {
        }
    }
}
