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
    public partial class Login : Window
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

            // Здесь должна быть реальная логика аутентификации
            if (AuthenticateUser(username, password))
            {
                // Сохранение данных если выбрано "Запомнить меня"
                if (RememberMeCheckBox.IsChecked == true)
                {
                    SaveCredentials(username);
                }
                else
                {
                    ClearCredentials();
                }

                MessageBox.Show($"Вход выполнен успешно!\nДобро пожаловать, {username}!",
                              "Успех", MessageBoxButton.OK, MessageBoxImage.Information);

                // Здесь можно перейти на главную форму приложения
                // MainWindow mainWindow = new MainWindow();
                // mainWindow.Show();
                // this.Close();
            }
            else
            {
                MessageBox.Show("Неверное имя пользователя или пароль.",
                              "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            // Открытие формы регистрации
            Register registerWindow = new Register();
            registerWindow.Show();
            this.Close();
        }

        private bool AuthenticateUser(string username, string password)
        {
            // Заглушка для демонстрации
            // В реальном приложении здесь будет проверка в базе данных
            // или вызов сервиса аутентификации

            // Пример простой проверки (замените на реальную логику)
            return username == "admin" && password == "12345";

            // Для реального приложения может выглядеть так:
            // using (var context = new AppDbContext())
            // {
            //     var user = context.Users.FirstOrDefault(u => u.Username == username);
            //     if (user != null && VerifyPassword(password, user.PasswordHash))
            //     {
            //         return true;
            //     }
            // }
            // return false;
        }

        private void SaveCredentials(string username)
        {
            // Временное решение - используем обычные переменные
            // В реальном приложении замените на настройки
            Application.Current.Properties["Username"] = username;
            Application.Current.Properties["RememberMe"] = true;
        }

        private void ClearCredentials()
        {
            Application.Current.Properties["Username"] = string.Empty;
            Application.Current.Properties["RememberMe"] = false;
        }

        private void LoadCredentials()
        {
            if (Application.Current.Properties.Contains("RememberMe") &&
                (bool)Application.Current.Properties["RememberMe"] &&
                Application.Current.Properties.Contains("Username"))
            {
                string savedUsername = Application.Current.Properties["Username"] as string;
                if (!string.IsNullOrEmpty(savedUsername))
                {
                    UsernameBox.Text = savedUsername;
                    RememberMeCheckBox.IsChecked = true;
                    PasswordBox.Focus();
                }
            }
        }

        protected override void OnContentRendered(EventArgs e)
        {
            base.OnContentRendered(e);
            LoadCredentials();
        }
    }
}