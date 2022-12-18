using Cleaning1.Components;
using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для AddEditServPage.xaml
    /// </summary>
    public partial class AddEditServPage : Page
    {
        public Services Services { get; set; }
        public List<Detergent> Detergents { get; set; }
        public AddEditServPage(Services _services = null)
        {
            DBConnect.db.Detergent.Load();
            Services = _services ?? new Services();
            Detergents = DBConnect.db.Detergent.Local.ToList();
            InitializeComponent();
        }

        private void SaveServBtn_Click(object sender, RoutedEventArgs e)
        {
            if(!DBConnect.db.Services.Local.All(Services => Services.Id == Services.Id))
                DBConnect.db.Services.Local.Add(Services);
            DBConnect.db.SaveChanges();
            MessageBox.Show("Сохранено");
            NavigationService.GoBack();

        }

        private void DetergentServ_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(DetergentServ.SelectedItem== null)
                return;
            Services.Detergent = DetergentServ.SelectedItem as Detergent;
        }
    }
}
