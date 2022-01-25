using System;
using System.IO;
using pengeapp.Data;
using Xamarin.Forms;

namespace pengeapp
{
    public partial class App : Application
    {
        static pengeDatabase database;

        // Create the database connection as a singleton.
        public static pengeDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new pengeDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Notes.db3"));
                }
                return database;
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