using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
    /// Логика взаимодействия для EditRecord.xaml
    /// </summary>
    public partial class EditRecord : Window
    {
        public EditRecord()
        {
            InitializeComponent();
        }
        ShopEntities db = ShopEntities.GetContext();
        Product product;


        private void Change_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (nameManufacturer.Text == string.Empty)
            {
                errors.AppendLine("Заполните ФИО изготовителя");
            }
            if (!int.TryParse(priceText.Text, out int price) || price <= 0)
            {
                errors.AppendLine("Данные цены введены неверно");
            }
            if (gild.Text == string.Empty)
            {
                errors.AppendLine("Заполните название цеха");
            }
            if (productType.Text == string.Empty)
            {
                errors.AppendLine("Заполните тип изделия");
            }
            if (!int.TryParse(moText.Text, out int mo) || mo <= 0)
            {
                errors.AppendLine("Заполните кол-во произведенных изделий за понедельник");
            }
            if (!int.TryParse(tuText.Text, out int tu) || tu <= 0)
            {
                errors.AppendLine("Заполните кол-во произведенных изделий за вторник");
            }
            if (!int.TryParse(weText.Text, out int we) || we <= 0)
            {
                errors.AppendLine("Заполните кол-во произведенных изделий за среду");
            }
            if (!int.TryParse(thText.Text, out int th) || th <= 0)
            {
                errors.AppendLine("Заполните кол-во произведенных изделий за четверг");
            }
            if (!int.TryParse(frText.Text, out int fr) || fr <= 0)
            {
                errors.AppendLine("Заполните кол-во произведенных изделий за пятницу");
            }
            if (!int.TryParse(suText.Text, out int su) || su <= 0)
            {
                errors.AppendLine("Заполните кол-во произведенных изделий за субботу");
            }
            if (!int.TryParse(saText.Text, out int sa) || sa <= 0)
            {
                errors.AppendLine("Заполните кол-во произведенных изделий за воскресенье");
            }
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            product.NameManufacturer = nameManufacturer.Text;
            product.Price = price;
            product.Gild = gild.Text;
            product.ProductType = productType.Text;
            product.WareMo = mo;
            product.WareTu = tu;
            product.WareWe = we;
            product.WareTh = th;
            product.WareFr = fr;
            product.WareSu = su;
            product.WareSa = sa;
            try
            {
                db.SaveChanges();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            product = db.Products.Find(Transfer.Id);
            nameManufacturer.Text = product.NameManufacturer;
            priceText.Text = Convert.ToString(product.Price);
            productType.Text = product.ProductType;
            moText.Text = Convert.ToString(product.WareMo);
            tuText.Text = Convert.ToString(product.WareTu);
            weText.Text = Convert.ToString(product.WareWe);
            thText.Text = Convert.ToString(product.WareTh);
            frText.Text = Convert.ToString(product.WareFr);
            suText.Text = Convert.ToString(product.WareSu);
            saText.Text = Convert.ToString(product.WareSa);
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
