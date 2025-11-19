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

namespace TP_Project
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();

            // Установка фокуса на поле логина при загрузке
            Loaded += (s, e) => UsernameBox.Focus();

            // Обработка нажатия Enter в поле пароля
            PasswordBox.KeyDown += (s, e) =>
            {
                if (e.Key == Key.Enter)
                {
                    LoginButton_Click(s, e);
                }
            };
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameBox.Text.Trim();
            string password = PasswordBox.Password;

            // Проверка на заполненность полей
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Заполните все поля.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            
            if (AuthenticateUser(username, password))
            {
               
                MessageBox.Show($"Вход выполнен успешно!\nДобро пожаловать, {username}!",
                              "Успех", MessageBoxButton.OK, MessageBoxImage.Information);

             
                HomePage mainPage = new HomePage();
                NavigationService.Navigate(mainPage);
            }
            else
            {
                MessageBox.Show("Неверное имя пользователя или пароль.",
                              "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            // Переход на страницу регистрации
            Register registerPage = new Register();
            NavigationService.Navigate(registerPage);
        }

        private bool AuthenticateUser(string username, string password)
        {
            // Заглушка для демонстрации
            // В реальном приложении здесь будет проверка в базе данных
            // или вызов сервиса аутентификации

            // Пример простой проверки (замените на реальную логику)
            return username == "admin" && password == "12345";

           
        }

      
    }
}