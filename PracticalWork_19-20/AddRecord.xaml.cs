using System;
using System.Text;
using System.Windows;

namespace PracticalWork_19_20
{
    public partial class AddRecord : Window
    {
        public AddRecord()
        {
            InitializeComponent();
        }
        ShopEntities db = ShopEntities.GetContext();

        private void Add_Click(object sender, RoutedEventArgs e)
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
            Product product = new Product();
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
                db.Products.Add(product);
                db.SaveChanges();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
