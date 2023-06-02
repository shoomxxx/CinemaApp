using System.Windows;
using CinemaApp.data.EntityS;
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
            if (!string.IsNullOrEmpty(Name.Text) && !string.IsNullOrEmpty(Surname.Text) && !string.IsNullOrEmpty(Patronymic.Text) && !string.IsNullOrEmpty(Post.Text) && !string.IsNullOrEmpty(Number.Text) && !string.IsNullOrEmpty(Login.Text) && !string.IsNullOrEmpty(Password.Text))
            {
                CinemaEntities db = new CinemaEntities();
                var user = _userRepository.UserRegistration(Name.Text, Surname.Text, Patronymic.Text, Post.Text, Number.Text, DateOfBirth.SelectedDate.Value, Login.Text, Password.Text);
                if (user != null)
                {
                    MessageBox.Show("Успешно!");
                    NavigationService?.Navigate(new UserLogin(user.Login, user.Password));
                }
                else
                {
                    MessageBox.Show("креветки");
                }
                
               
                
            }
            else
            {
                MessageBox.Show("Places empty!");
            }
            
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