using System;
using System.Windows;
using WpfApp1;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CreateUser_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Password;

            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                try
                {
                    User newUser = new User
                    {
                        UserName = username,
                        Salt = DatabaseHelper.GenerateSalt(),
                        PasswordHash = DatabaseHelper.GenerateHash(password, DatabaseHelper.GenerateSalt())
                    };

                    DatabaseHelper.CreateUser(newUser);
                }
                catch
                {
                    MessageBox.Show("Данный ник уже занят");
                }
            }
            else
            {
                MessageBox.Show("Проверьте введенный логин и пароль.");
            }
        }

        private void Authorize_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Password;

            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                try
                {
                    bool isAuthenticated = DatabaseHelper.CheckUserAuthentication(username, password);

                    if (isAuthenticated)
                    {
                        AuthorizationWindow newWindow = new AuthorizationWindow();
                        newWindow.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Авторизация не удалась. Пожалуйста, проверьте свои учетные данные.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Произошла ошибка: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите имя пользователя и пароль.");
            }
        }
    }
}
