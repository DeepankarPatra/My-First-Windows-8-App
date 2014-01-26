using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using SQLite;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace SmartToDoCS
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class SecondPage : SmartToDoCS.Common.LayoutAwarePage
    {
        public int nextTask=0;
        public SQLiteConnection db;
        public List<TaskTable> res;
        public int week = 0;
        public int daytime = 0;
        private int nextflag = 0;
        public SecondPage()
        {
            this.InitializeComponent();
            this.Loaded += new RoutedEventHandler(SecondPage_Loaded);
        }
        private void SecondPage_Loaded(object sender, RoutedEventArgs e)
        {
            nextTask = 0;
            var dbpath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "alltask.db3");
            db = new SQLite.SQLiteConnection(dbpath);
            DateTime dt = DateTime.Today;
            if (dt.DayOfWeek == DayOfWeek.Saturday || dt.DayOfWeek == DayOfWeek.Sunday)
            {
                if (dt.Hour >= 5 && dt.Hour < 12)
                    res = db.Query<TaskTable>("SELECT * FROM TaskTable WHERE Week=1 OR Time=1 OR Time=0 ORDER BY Week DESC, Time DESC");
                else if (dt.Hour >= 12 && dt.Hour < 18)
                    res = db.Query<TaskTable>("SELECT * FROM TaskTable WHERE Week = 1 OR Time=2 OR Time=0 ORDER BY Week DESC, Time DESC");
                else
                    res = db.Query<TaskTable>("SELECT * FROM TaskTable WHERE Week = 1 OR Time=3 OR Time=0 ORDER BY Week DESC, Time DESC");
                if (res.Count > 0)
                    Task.Text = res[0].ToString();
            }
            else
            {
                if (dt.Hour >= 5 && dt.Hour < 12)
                    res = db.Query<TaskTable>("SELECT * FROM TaskTable WHERE Time=1 OR Time=0 ORDER BY Time DESC");
                else if (dt.Hour >= 12 && dt.Hour < 18)
                    res = db.Query<TaskTable>("SELECT * FROM TaskTable WHERE Time=2 OR Time=0 ORDER BY Time DESC");
                else
                    res = db.Query<TaskTable>("SELECT * FROM TaskTable WHERE Time=3 OR Time=0 ORDER BY Time DESC");
                if (res.Count > 0)
                    Task.Text = res[0].ToString();
            }
            nextTask = 0;// res[0].getId();
            db.Close();
        }

        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="navigationParameter">The parameter value passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested.
        /// </param>
        /// <param name="pageState">A dictionary of state preserved by this page during an earlier
        /// session.  This will be null the first time a page is visited.</param>
        protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="pageState">An empty dictionary to be populated with serializable state.</param>
        protected override void SaveState(Dictionary<String, Object> pageState)
        {
        }

        private void First_Click(object sender, RoutedEventArgs e)
        {
            if (this.Frame != null)
            {
                this.Frame.Navigate(typeof(FirstPage));
            }
        }

        private void Second_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Third_Click(object sender, RoutedEventArgs e)
        {
            if (this.Frame != null)
            {
                this.Frame.Navigate(typeof(ThirdPage));
            }
        }

        private void Delete_Task(object sender, RoutedEventArgs e)
        {
            var dbpath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "alltask.db3");
            db = new SQLite.SQLiteConnection(dbpath);
            if (Task.Text == "Well Done! Proud of you :P" || Task.Text == "\"Show Next Possible Task\" is your button I guess :P")
                Task.Text = "\"Show Next Possible Task\" is your button I guess :P";
            else if (nextTask < res.Count)
            {
                db.Delete<TaskTable>(res[nextTask].getId());
                Task.Text = "Well Done! Proud of you :P";
            }
            else
            {
                Task.Text = "\"Show Next Possible Task\" is your button I guess :P";
            }
            db.Close();
        }

        private void Update_Morn(object sender, RoutedEventArgs e)
        {
            daytime = 1;
            var dbpath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "alltask.db3");
            db = new SQLite.SQLiteConnection(dbpath);
            if (nextTask < res.Count)
                db.InsertOrReplace(new TaskTable() { Id = res[nextTask].getId(), Desc = res[nextTask].Desc, Time = daytime, Week = week });
            db.Close();
        }

        private void Update_Even(object sender, RoutedEventArgs e)
        {
            daytime = 2;
            var dbpath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "alltask.db3");
            db = new SQLite.SQLiteConnection(dbpath);
            if (nextTask < res.Count)
                db.InsertOrReplace(new TaskTable() { Id = res[nextTask].getId(), Desc = res[nextTask].Desc, Time = daytime, Week = week });
            db.Close();
        }

        private void Update_Nigh(object sender, RoutedEventArgs e)
        {
            daytime = 3;
            var dbpath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "alltask.db3");
            db = new SQLite.SQLiteConnection(dbpath);
            if (nextTask < res.Count)
                db.InsertOrReplace(new TaskTable() { Id = res[nextTask].getId(), Desc = res[nextTask].Desc, Time = daytime, Week = week });
            db.Close();
        }

        private void Update_week(object sender, RoutedEventArgs e)
        {
            week = 1;
            var dbpath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "alltask.db3");
            db = new SQLite.SQLiteConnection(dbpath);
            if (nextTask < res.Count)
                db.InsertOrReplace(new TaskTable() { Id = res[nextTask].getId(), Desc = res[nextTask].Desc, Time = daytime, Week = week });
            db.Close();

        }

        private void Next_Task(object sender, RoutedEventArgs e)
        {
            var dbpath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "alltask.db3");
            db = new SQLite.SQLiteConnection(dbpath);
            if (nextTask < res.Count - 1)
            {
                nextTask++;
                Task.Text = res[nextTask].ToString();
            }
            else if (nextflag == 0)
            {
                DateTime dt = DateTime.Today;
                nextflag = 1;
                if (dt.Hour >= 5 && dt.Hour < 12)
                    res = db.Query<TaskTable>("SELECT * FROM TaskTable WHERE Time=2 OR Time=3  ORDER BY Time DESC");
                else if (dt.Hour >= 12 && dt.Hour < 18)
                    res = db.Query<TaskTable>("SELECT * FROM TaskTable WHERE Time=1 OR Time=3 ORDER BY Time DESC");
                else
                    res = db.Query<TaskTable>("SELECT * FROM TaskTable WHERE Time=1 OR Time=2 ORDER BY Time DESC");
                if (res.Count > 0)
                {
                    Task.Text = res[0].ToString();
                    nextTask = 0;
                }
                else
                    Task.Text = "Either you ignored all the tasks or YOU ARE FREE OF TASKS NOW!";
            }
            else
            {
                Task.Text = "Either you ignored all the tasks or YOU ARE FREE OF TASKS NOW!";
            }
            rd1.IsChecked = false;
            rd2.IsChecked = false;
            rd3.IsChecked = false;
            chk.IsChecked = false;
            db.Close();
        }

        private void GoHome(object sender, DoubleTappedRoutedEventArgs e)
        {
            if (this.Frame != null)
            {
                this.Frame.Navigate(typeof(MainPage));
            }
        }

    }
}
