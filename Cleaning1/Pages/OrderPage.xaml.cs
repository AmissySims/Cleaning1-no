using Cleaning1.Components;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    /// Логика взаимодействия для OrderPage.xaml
    /// </summary>
    public partial class OrderPage : Page, INotifyPropertyChanged
    {
        public Order Order { get; set; }
        public ObservableCollection<OrderStatus> OrderStatus { get; set; }
        public ObservableCollection<User> Users { get; set; }
        public ObservableCollection<Services> Services { get; set; }
        public IEnumerable<User> Customer = DBConnect.db.User.Local.Where(x => x.RoleId == 2);
        public IEnumerable<User> Executors = DBConnect.db.User.Local.Where(x => x.RoleId == 3);
        public IEnumerable<OrderService> OrderServices { get; set; }


        public OrderPage(Order order)
        {
            InitializeOrderPage();
            InitializeOrder(order);
            InitializeComponent();
            
        }

        private void InitializeOrderPage()
        {
            throw new NotImplementedException();
        }

        private void InitializeOrder(Order order = null)
        {
            Order = order ?? new Order()
            {
                User = Navigation.AuthUser.RoleId == 2 ? Navigation.AuthUser : null,
                User1 = Navigation.AuthUser.RoleId == 3 ? Navigation.AuthUser : null,
                CompletionDate= DateTime.Now,
                OrderStatusId = 1
            };
        }

        public OrderPage(IEnumerable<Services> addedServices)
        {
            InitializeComponent();
            InitializeOrder();
            foreach(var service in addedServices)
                DBConnect.db.OrderService.Local.Add(new OrderService()
                {
                    Order = Order,
                    Services= service,
                    QuanityThings = 1,
                    Cost = service.Cost
                }

        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
