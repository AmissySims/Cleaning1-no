using Cleaning1.Components;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Cleaning1.Pages
{
    /// <summary>
    /// Логика взаимодействия для ServicesListPage.xaml
    /// </summary>
    public partial class ServicesListPage : Page
    {
        int actPage = 0;

        public ObservableCollection<Services> ServicesList
        {
            get { return (ObservableCollection<Services>)GetValue(ServicesListProperty); }
            set { SetValue(ServicesListProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ServicesListProperty =
            DependencyProperty.Register("ServicesList", typeof(ObservableCollection<Services>), typeof(ServicesListPage));


        public ServicesListPage()
        {
            
            DBConnect.db.Services.Load();
            ServicesList = DBConnect.db.Services.Local;
            InitializeComponent();

            if(Navigation.AuthUser.RoleId == 2)
            {
                AddServBtn.Visibility = Visibility.Collapsed;
            }
        }

        private void CreateServBtn_Click(object sender, RoutedEventArgs e)
        {
            var selservice = (sender as Button).DataContext as Services;
            NavigationService.Navigate(new AddEditServPage(selservice));
        }

        private void AddOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            
            NavigationService.Navigate(new OrderPage(ServiceList.SelectedItems.Cast<Services>()));
        }

        private void CountCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
