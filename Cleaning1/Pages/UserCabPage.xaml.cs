using Cleaning1.Components;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.IO;
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
    /// Логика взаимодействия для UserCabPage.xaml
    /// </summary>
    public partial class UserCabPage : Page
    {
        public User User { get; set; }
        
        public UserCabPage(User _user)
        {
            DBConnect.db.User.Load();
            User = _user ?? new User();
            InitializeComponent();
            
           
        }

        private void AddImageBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog()
            {
                Filter = "*.png|*.png|*.jpg|*.jpg|*.jpeg|*.jpeg",
            };
            if (openFile.ShowDialog().GetValueOrDefault())
            {
                User.Photo = File.ReadAllBytes(openFile.FileName);
                UserImage.Source = new BitmapImage(new Uri(openFile.FileName));
            }
        }
    }
}
