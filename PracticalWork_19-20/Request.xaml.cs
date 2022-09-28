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

namespace PracticalWork_19_20
{
    /// <summary>
    /// Логика взаимодействия для Request.xaml
    /// </summary>
    public partial class Request : Window
    {
        public Request()
        {
            InitializeComponent();
        }
        ShopEntities db = ShopEntities.GetContext();
        private void Sum_Click(object sender, RoutedEventArgs e)
        {
            int avarage = (int)db.Products.Sum(p => p.WareWe);
            sumText.Text = avarage.ToString();
        }

        private void MaxPrice(object sender, RoutedEventArgs e)
        {
            int max = (int)db.Products.Max(p => p.Price);
            priceText.Text = max.ToString();
        }

        private void MinWare(object sender, RoutedEventArgs e)
        {
            int min = (int)db.Products.Min(p => p.WareFr);
            wareMin.Text = min.ToString();
        }
    }
}
