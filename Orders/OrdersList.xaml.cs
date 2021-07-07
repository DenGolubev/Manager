﻿using System;
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
using System.Windows.Shapes;

namespace Manager.Orders
{
    /// <summary>
    /// Логика взаимодействия для OrdersList.xaml
    /// </summary>
    public partial class OrdersList : Window
    {
        ApplicationContext db;

        public OrdersList()
        {
            InitializeComponent();
        }

        private void gridOrders_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //using (db = new ApplicationContext())
            //{
            //    db.Orders.Load();
            //    gridOrders.ItemsSource =db.Orders.Local.ToBindingList();
            //}
        }

        private void buttonExit_Click(object sender, RoutedEventArgs e)
        {
            UserCabinet userCabinet = new UserCabinet();
            userCabinet.Show();
            Hide();
        }

        private void buttonOrderDelete_Click(object sender, RoutedEventArgs e)
        {
            using (db = new ApplicationContext())
            {
                if (gridOrders.SelectedItems.Count > 0)
                {
                    for (int i = 0; i < gridOrders.SelectedItems.Count; i++)
                    {
                        Order customer = gridOrders.SelectedItems[i] as Order;
                        Order info = db.Orders.Where(t => t.id == customer.id).FirstOrDefault();
                        if (info != null)
                        {
                            db.Orders.Remove(info);
                        }
                    }
                }
                db.SaveChanges();
                db.Orders.Load();
                gridOrders.ItemsSource = db.Customers.Local.ToBindingList();
            }
        }
    }
}
