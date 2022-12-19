﻿using Cleaning1.Components;
using System;
using System.Collections.Generic;
using System.Fabric.Query;
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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            Navigation.main1= this;
            if(Navigation.AuthUser.RoleId == 2)
            {
                SupplyBtn.Visibility = Visibility.Collapsed;
                OrdersBtn.Visibility = Visibility.Collapsed;
                DetergentBtn.Visibility = Visibility.Collapsed;
                AddOrderBtn.Visibility = Visibility.Collapsed;
            }
            if (Navigation.AuthUser.RoleId == 3)
            {
                SupplyBtn.Visibility = Visibility.Collapsed;
                DetergentBtn.Visibility = Visibility.Collapsed;

            }
            if (Navigation.AuthUser.RoleId == 1)
            {
                MyOrdersBtn.Visibility = Visibility.Collapsed;
                

            }

        }

        private void ServiceBtn_Click(object sender, RoutedEventArgs e)
        {
            MainMainFrame.Navigate(new ServicesListPage());
        }

        private void CabBtn_Click(object sender, RoutedEventArgs e)
        {
            MainMainFrame.Navigate(new UserCabPage());
        }

        private void DetergentBtn_Click(object sender, RoutedEventArgs e)
        {
            MainMainFrame.Navigate(new DetergentsPage());
        }

        private void OrdersBtn_Click(object sender, RoutedEventArgs e)
        {
            MainMainFrame.Navigate(new AllOrdersPage());
        }

        private void SupplyBtn_Click(object sender, RoutedEventArgs e)
        {
            MainMainFrame.Navigate(new SupplyPage());
        }

        private void EntrBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigation.NextPage(new Nav(new AuthPage()));
        }

        private void MyOrdersBtn_Click(object sender, RoutedEventArgs e)
        {
            MainMainFrame.Navigate(new MyOrdersPage());
        }

       
    }
}
