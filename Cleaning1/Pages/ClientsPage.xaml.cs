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
    /// Логика взаимодействия для ClientsPage.xaml
    /// </summary>
    public partial class ClientsPage : Page
    {



        public ObservableCollection<User> Users
        {
            get { return (ObservableCollection<User>)GetValue(UsersProperty); }
            set { SetValue(UsersProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UsersProperty =
            DependencyProperty.Register("Users", typeof(ObservableCollection<User>), typeof(ClientsPage));


        public ClientsPage()
        {
            DBConnect.db.User.Load();
            Users = DBConnect.db.User.Local;
            InitializeComponent();
        }

        private void AddUserBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UserCabPage());
        }

        private void DetergentsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            NavigationService.Navigate(new UserCabPage());
        }
    }
}
