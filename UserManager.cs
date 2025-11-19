using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using System.Linq;

namespace TP_Project
{
    public static class UserManager
    {
        private static string usersFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "UsersData.json");

        public static void SaveUsers(ObservableCollection<User> users)
        {
            try
            {
                string json = JsonSerializer.Serialize(users);
                File.WriteAllText(usersFilePath, json);
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка сохранения пользователей: {ex.Message}");
            }
        }

        public static ObservableCollection<User> LoadUsers()
        {
            try
            {
                if (!File.Exists(usersFilePath))
                    return new ObservableCollection<User>();

                string json = File.ReadAllText(usersFilePath);

                if (string.IsNullOrEmpty(json))
                    return new ObservableCollection<User>();

                return JsonSerializer.Deserialize<ObservableCollection<User>>(json) ?? new ObservableCollection<User>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка загрузки пользователей: {ex.Message}");
            }
        }

        public static void RegisterUser(string username, string password)
        {
            try
            {
                var users = LoadUsers();

                // Проверяем, нет ли уже пользователя с таким именем
                if (users.Any(u => u.Username == username))
                {
                    throw new Exception("Пользователь с таким именем уже существует");
                }

                users.Add(new User { Username = username, Password = password });
                SaveUsers(users);
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка регистрации: {ex.Message}");
            }
        }

        public static bool AuthenticateUser(string username, string password)
        {
            try
            {
                var users = LoadUsers();
                var user = users.FirstOrDefault(u => u.Username == username);

                return user != null && user.Password == password;
            }
            catch
            {
                return false;
            }
        }
    }
}