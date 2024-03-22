
using DbCreator;
using Microsoft.EntityFrameworkCore;
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

namespace ShopAppWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string shopName;
        private ShopDb context;
        public MainWindow()
        {
            InitializeComponent();
            context = new ShopDb();
        }


        private void getShops(object sender, RoutedEventArgs e)
        {
            shopName = line.Text;
            if (String.IsNullOrEmpty(shopName))
            {
                grid_shops.ItemsSource = context.Shops.ToList();
            }
            else
            {
                grid_shops.ItemsSource = context.Shops.Where(s => s.Name == shopName).ToList();
            }
        }
        private void getProducts(object sender, RoutedEventArgs e)

        {
            shopName = line.Text;
            if (String.IsNullOrEmpty(shopName))
            {
                grid_prods.ItemsSource = context.Products.ToList();
            }
            else
            {
                grid_prods.ItemsSource = context.ProductShops.Where(ps=>ps.Shop.Name == shopName).Select(ps => ps.Product).ToList();
            }
        }
        private void getWorkers(object sender, RoutedEventArgs e)
        {
            shopName = line.Text;
            if (String.IsNullOrEmpty(shopName))
            {
                grid_work.ItemsSource = context.Workers.ToList();
            }
            else
            {
                grid_work.ItemsSource = context.Workers.Where(w => w.Shop.Name == shopName).ToList();
            }
        }
    }
}
