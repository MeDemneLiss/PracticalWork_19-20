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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PracticalWork_19_20
{
    /// <summary>
    /// Логика взаимодействия для Autoriz.xaml
    /// </summary>
    public partial class Autoriz : Window
    {
        public Autoriz()
        {
            InitializeComponent();
        }
        ShopEntities db = ShopEntities.GetContext();
        private void Window_Activated(object sender, EventArgs e)
        {
            txtLogin.Focus();
            Data.Login = false;
        }

        private void Enter(object sender, RoutedEventArgs e)
        {
            if (txtLogin.Text == string.Empty || txtPas.Password == string.Empty)
            {
                MessageBox.Show("Логин или пароль были не введены", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var user = db.Authorizations.Where(p => p.Логин.ToLower() == txtLogin.Text.ToLower()).FirstOrDefault();
            if (user == null)
            {
                MessageBox.Show("Пользователь не найден", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                txtLogin.Focus();
                return;
            }
            if (user.Пароль != txtPas.Password)
            {
                MessageBox.Show("Пароль неверен", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            Data.Login = true;
            Data.FIO = user.Фамилия;
            Data.Name = user.Имя;
            Data.Right = user.Доступ;
            Close();
        }

        private void Esc(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

