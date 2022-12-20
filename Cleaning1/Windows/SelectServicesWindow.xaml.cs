using Cleaning1.Components;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace Cleaning1.Windows
{
    /// <summary>
    /// Логика взаимодействия для SelectProductWindow.xaml
    /// </summary>
    public partial class SelectServicesWindow : Window
    {
        public IEnumerable<Services> Service { get; set; }
        public IEnumerable<Services> SelectedServ => ServList.SelectedItems.Cast<Services>();

        public SelectServicesWindow(IEnumerable<Services> products)
        {
            Service = DBConnect.db.Services.Local.Except(products);

            InitializeComponent();
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }

        private void Button_Click(object sender, RoutedEventArgs e) =>
            Close();

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) =>
            DialogResult = true;
    }
}
