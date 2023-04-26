using System.Windows;
using System.Windows.Controls;
using CinemaApp.data.EntityS;

namespace CinemaApp.View.Default
{
    public partial class DetailedSessionPage : Page
    {
        public DetailedSessionPage(Get_All_Session session)
        {
            InitializeComponent();
            PageOnLoad(session);
        }

        private void PageOnLoad(Get_All_Session session)
        {
            SessionTitle.Text = session.Film_Description;
            IdSession.Text = session.Session_id_Session.ToString();
        }

        private void CloseButton_OnClick(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new View.Default.ListViewSessionPage());
        }
    }
}