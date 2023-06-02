using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using CinemaApp.data.EntityS;
using CinemaApp.data.RepositoryFunc;
using CinemaApp.middle;
using CinemaApp.View.Admin;
using CinemaApp.View.Admin.CRUDxaml;

namespace CinemaApp.View.Client
{
    public partial class HomePage : Page
    {
        public data.EntityS.Client _Client = new data.EntityS.Client();
        static readonly SessionsRepository SessionsRepository = new SessionsRepository();

        public HomePage()
        {
            InitializeComponent();

            DetailedSessionFrame.NavigationService?.Navigate(new Default.ListViewSessionPage());

            if (CurrentUser.Login != null && CurrentUser.Password != null)
            {
                var userProfile = new Button
                {
                    Content = CurrentUser.Login,
                    Foreground = Brushes.White,
                    Style = FindResource("MaterialDesignFlatAccentButton") as Style
                };
                PanelForButton.Children.Add(userProfile);
            }
            else
            {
                var userLogin = new Button
                {
                    Content = "Вход",
                    Foreground = Brushes.White,
                    Style = FindResource("MaterialDesignFlatAccentButton") as Style
                };
                userLogin.Click += User_Login_OnClick;
                var userReg = new Button
                {
                    Content = "Регистрация",
                    Foreground = Brushes.White,
                    Style = FindResource("MaterialDesignFlatAccentButton") as Style
                };
                userReg.Click += User_Registration_OnClick;
                PanelForButton.Children.Add(userLogin);
                PanelForButton.Children.Add(userReg);
            }
        }

        private void User_Registration_OnClick(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new UserRegistration());
        }

        private void User_Login_OnClick(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new UserLogin());
        }
    }
}