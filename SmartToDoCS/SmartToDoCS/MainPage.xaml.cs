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
    public sealed partial class MainPage : SmartToDoCS.Common.LayoutAwarePage
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.Loaded += new RoutedEventHandler(MainPage_Loaded);
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            var dbpath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "alltask.db3");
            SQLiteConnection db = new SQLite.SQLiteConnection(dbpath);
            //db.CreateTable<TaskTable>();
            int tasks = db.Table<TaskTable>().Count();
            if (tasks > 10)
                BgGrid.Background = new SolidColorBrush(Windows.UI.Colors.Tomato);
            else if (tasks > 5)
                BgGrid.Background = new SolidColorBrush(Windows.UI.Colors.YellowGreen);
            else
                BgGrid.Background = new SolidColorBrush(Windows.UI.Colors.Green);
            /*DateTime dt = DateTime.Today;
            List<TaskTable> res;
            if (dt.DayOfWeek == DayOfWeek.Saturday || dt.DayOfWeek == DayOfWeek.Sunday)
            {
                if (dt.Hour >= 5 && dt.Hour < 12)
                    res = db.Query<TaskTable>("SELECT * FROM TaskTable WHERE Week=1 OR Time=1 ORDER BY Week DESC");
                else if (dt.Hour >= 12 && dt.Hour < 18)
                    res = db.Query<TaskTable>("SELECT * FROM TaskTable WHERE Week = 1 OR Time=2 ORDER BY Week DESC");
                else
                    res = db.Query<TaskTable>("SELECT * FROM TaskTable WHERE Week = 1 OR Time=3 ORDER BY Week DESC");
                if (res.Count > 0)
                    CurrTask.ItemsSource = res;
            }
            else
            {
                if (dt.Hour >= 5 && dt.Hour < 12)
                    res = db.Query<TaskTable>("SELECT * FROM TaskTable WHERE Time=1");
                else if (dt.Hour >= 12 && dt.Hour < 18)
                    res = db.Query<TaskTable>("SELECT * FROM TaskTable WHERE Time=2");
                else
                    res = db.Query<TaskTable>("SELECT * FROM TaskTable WHERE Time=3");
                if (res.Count > 0)
                    CurrTask.ItemsSource = res;
            }*/
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
            if (this.Frame != null)
            {
                this.Frame.Navigate(typeof(SecondPage));
            }
        }

        private void Third_Click(object sender, RoutedEventArgs e)
        {
            if (this.Frame != null)
            {
                this.Frame.Navigate(typeof(ThirdPage));
            }
        }
    }
}
