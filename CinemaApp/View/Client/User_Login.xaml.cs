using System.Windows;
using CinemaApp.data.RepositoryFunc;

namespace CinemaApp.View.Client
{
    public partial class UserLogin
    {
        private readonly UserRepository _userRepository = new UserRepository();

        public UserLogin()
        {
            InitializeComponent();
        }

        private void User_Reg_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new UserRegistration());
        }

        private void UserMainPG_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(Login.Text) && !string.IsNullOrEmpty(Password.Text))
            {
                var user = _userRepository.UserCheck(Login.Text, Password.Text);
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