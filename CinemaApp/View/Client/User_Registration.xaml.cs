using System.Windows;
using CinemaApp.data.RepositoryFunc;

namespace CinemaApp.View.Client
{
    public partial class UserRegistration
    {
        private readonly UserRepository _userRepository = new UserRepository();

        public UserRegistration()
        {
            InitializeComponent();
        }

        private void UserMainPG_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new HomePage());
        }

        private void Home_OnClick(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new HomePage());
        }

        private void IfUserLogin_OnClick(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new UserLogin());
        }
    }
}