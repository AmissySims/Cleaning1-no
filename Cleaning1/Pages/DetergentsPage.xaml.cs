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
    /// Логика взаимодействия для DetergentsPage.xaml
    /// </summary>
    public partial class DetergentsPage : Page
    {
        public ObservableCollection<Detergent> Detergents
        {
            get { return (ObservableCollection<Detergent>)GetValue(DetergentsProperty); }
            set { SetValue(DetergentsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DetergentsProperty =
            DependencyProperty.Register("Detergents", typeof(ObservableCollection<Detergent>), typeof(DetergentsPage));
        public DetergentsPage()
        {
            DBConnect.db.Detergent.Load();
            Detergents = DBConnect.db.Detergent.Local;
            InitializeComponent();
            if(Navigation.AuthUser.RoleId == 3)
            {
                AddSupBtn.Visibility = Visibility.Collapsed;
                AddDetBtn.Visibility = Visibility.Collapsed;
            }
        }

        private void CreateDetBtn_Click(object sender, RoutedEventArgs e)
        {
            var seldetergent = (sender as Button).DataContext as Detergent;
            NavigationService.Navigate(new AddEditDetergentPage(seldetergent));
        }
    }
}
