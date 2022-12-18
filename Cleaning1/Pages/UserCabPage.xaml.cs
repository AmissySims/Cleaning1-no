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
    /// Логика взаимодействия для UserCabPage.xaml
    /// </summary>
    public partial class UserCabPage : Page
    {

        public User User { get; set; }
        public UserCabPage(User user = null)
        {
            User= user;
            
            InitializeComponent();
            if(Navigation.AuthUser.RoleId == 2 && Navigation.AuthUser.RoleId == 3)
            {

                RoleStack.Visibility = Visibility.Collapsed;
            }
        }
    }
}
