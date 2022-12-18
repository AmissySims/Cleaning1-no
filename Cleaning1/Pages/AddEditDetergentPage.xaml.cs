using Cleaning1.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Логика взаимодействия для AddEditDetergentPage.xaml
    /// </summary>
    public partial class AddEditDetergentPage : Page, INotifyPropertyChanged
    {
        public Detergent Detergent { get; set; }
        
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        public AddEditDetergentPage(Detergent _detergent = null)
        {
            DBConnect.db.Supplier.Load();
            Detergent = _detergent ?? new Detergent();
            InitializeComponent();
        }

        private void SaveDetBtn_Click(object sender, RoutedEventArgs e)
        {
            if(!DBConnect.db.Detergent.Local.Any(Detergent => Detergent.Id == Detergent.Id))
                DBConnect.db.Detergent.Local.Add(Detergent);
            DBConnect.db.SaveChanges();
            MessageBox.Show("Сохранено");
            NavigationService.GoBack();
        }
    }
}
