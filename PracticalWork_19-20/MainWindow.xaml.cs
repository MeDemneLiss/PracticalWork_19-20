using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PracticalWork_19_20
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        ShopEntities db = ShopEntities.GetContext();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Autoriz autoriz = new Autoriz
            {
                Owner = TableWindow
            };
            autoriz.ShowDialog();
            if (Data.Login == false)
            {
                Close();
            }
            string right;
            if (Data.Right == "А")
            {
                right = "Администратор";
            }
            else
            {
                right = "Пользователь";
                buttonDel.IsEnabled = false;
                menuDel.IsEnabled = false;
            }
            TableWindow.Title = TableWindow.Title + " " + Data.FIO + " " + Data.Name + " (" + right + ")";
            db.Products.Load();
            DataGrid.ItemsSource = db.Products.Local.ToBindingList();
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AddRecord addRecord = new AddRecord();
            addRecord.ShowDialog();
            DataGrid.Focus();
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            int indexRow = DataGrid.SelectedIndex;
            if (indexRow != -1)
            {
                Product row = (Product)DataGrid.Items[indexRow];
                Transfer.Id = row.Id;
                EditRecord editRecord = new EditRecord();
                editRecord.ShowDialog();
                DataGrid.Items.Refresh();
                DataGrid.Focus();
            }
            else
            {
                MessageBox.Show("Сначало выберете строку", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result;
            result = MessageBox.Show("Удалить запись?", "Удаление записи", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    Product row = (Product)DataGrid.SelectedItems[0];
                    db.Products.Remove(row);
                    db.SaveChanges();
                }
                catch (ArgumentOutOfRangeException)
                {
                    MessageBox.Show("Выберите запись", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        private void Info_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Самсаков А.А. В1\nПрактическая работа №19 - 20 \nРазработать интерфейс для доступа и управления однотабличной базой данных «Сведения об учете произведенных изделий за каждый день недели». Учет изделий, собранных в цехе за неделю. База данных должна содержать следующую\r\nинформацию: фамилию, имя, отчество сборщика, количество изготовленных изделий за\r\nкаждый день недели раздельно, название цеха, а также тип изделия и его стоимость.\r\n + добавить форму для авторизации", "Информация о программе", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void UpdatePrace_Click(object sender, RoutedEventArgs e)
        {
            if (nameManufacturerT.Text == string.Empty)
            {
                MessageBox.Show("Введите ФИО изготовителя", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            string name = nameManufacturerT.Text.ToLower();
            var product = db.Products.Where(p => p.NameManufacturer.ToLower() == name).FirstOrDefault();
            if (product == null)
            {
                MessageBox.Show("Данная продукция отсутствует", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!int.TryParse(finalPrice.Text, out int price) || price <= 0)
            {
                MessageBox.Show("Цена введена неверно", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            product.Price = price;
            db.SaveChanges();
            DataGrid.Items.Refresh();
            DataGrid.Focus();
            nameManufacturerT.Clear();
            finalPrice.Clear();
        }

        private void UpdateWare_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(idT.Text, out int id) || id < 0)
            {
                MessageBox.Show("Введите код продукции", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            var product = db.Products.Where(p => p.Id == id).FirstOrDefault();
            if (product == null)
            {
                MessageBox.Show("Данная продукция отсутствует", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!int.TryParse(wareText.Text, out int ware) || ware < 0)
            {
                MessageBox.Show("Количество ввдено неверно", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            product.WareTu = ware;
            db.SaveChanges();
            DataGrid.Items.Refresh();
            DataGrid.Focus();
            idT.Clear();
            wareText.Clear();
        }

        private void Delete_Name(object sender, RoutedEventArgs e)
        {
            if (nameDel.Text == string.Empty)
            {
                MessageBox.Show("Введите ФИО изготовителя", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            string nameManufacturer = nameDel.Text.ToLower();
            var product = db.Products.Where(p => p.NameManufacturer.ToLower() == nameManufacturer).FirstOrDefault();
            if (product == null)
            {
                MessageBox.Show("Данная продукция отсутствует", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            db.Products.Remove(product);
            db.SaveChanges();
            DataGrid.Items.Refresh();
            DataGrid.Focus();
            nameDel.Clear();
        }

        private void Show_Click(object sender, RoutedEventArgs e)
        {
            Request request = new Request();
            request.ShowDialog();
        }


    }
}
