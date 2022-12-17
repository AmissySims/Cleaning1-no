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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Cleaning1.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegPage.xaml
    /// </summary>
    public partial class RegPage : Page
    {
        public RegPage()
        {
            InitializeComponent();
            
        }

        private void RegBtn_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTb.Text.Trim();
            string password = PasswordTb.Text.Trim();
            string fname = FNameTb.Text.Trim();
            string lname = LNameTb.Text.Trim();
            string patronymic = PatronTb.Text.Trim();
            string phone = PhoneTb.Text.Trim();
            string adress = AdressTb.Text.Trim();
            var check = DBConnect.db.User.Where(x => x.Login == login && x.Phone == phone).FirstOrDefault();

            if (check == null)
            {
                DBConnect.db.User.Add(new User
                {
                    Login = login,
                    Password = password,
                    FirstName = fname,
                    LastName = lname,
                    Patronymic = patronymic,
                    Adress = adress,
                    Phone = phone,
                    GenderId = GenderCb.SelectedIndex + 1,
                    RoleId = 2

                });

                MessageBox.Show("Успешно");
                DBConnect.db.SaveChanges();
                Navigation.BackPage();
            }
            else
                MessageBox.Show("Такой пользователь уже существует");
        }

        private void EntrBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigation.BackPage();
        }
    }
}
