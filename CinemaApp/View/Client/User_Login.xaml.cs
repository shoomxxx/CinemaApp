using System.Windows;
using CinemaApp.data.RepositoryFunc;
using CinemaApp.View.Admin;

namespace CinemaApp.View.Client
{
    public partial class UserLogin
    {
        private readonly UserRepository _userRepository = new UserRepository();

        public UserLogin(string Login = null, string Password = null )
        {
            InitializeComponent();
            this.Login.Text= Login;
            this.Password.Password= Password; 
        }

        private void User_Reg_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new UserRegistration());
        }
        private void Home_OnClick(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new HomePage());
        }
        private void UserMainPG_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(Login.Text) && !string.IsNullOrEmpty(Password.Password))
            {
                var user = _userRepository.UserCheck(Login.Text, Password.Password);
                if (user != null)
                {
                    NavigationService?.Navigate(new HomePage());
                }
                else
                {
                    MessageBox.Show("User not found!");
                }
            }
            else
            {
                MessageBox.Show("Places empty!");
            }
        }
    }
}