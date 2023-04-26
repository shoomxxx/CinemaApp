using System.Linq;
using System.Windows;
using System.Windows.Controls;
using CinemaApp.data.EntityS;
using CinemaApp.data.RepositoryFunc;

namespace CinemaApp.View.Default
{
    public partial class ListViewSessionPage : Page
    {
        static readonly SessionsRepository SessionsRepository = new SessionsRepository();

        private void Search_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            LCinemaView.ItemsSource = SessionsRepository.SearchSession(Search.Text);
        }

        public ListViewSessionPage()
        {
            InitializeComponent();
            SessionFilter.SelectedIndex = 0;
            var currentSessionList = SessionsRepository.ManySessions().OrderBy(x => x.Session_Date_Film).ToList();
            LCinemaView.ItemsSource = currentSessionList;
        }

        private void LCinemaView_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LCinemaView.SelectedItem is Get_All_Session session)
            {
                NavigationService?.Navigate(new DetailedSessionPage(session));
            }
            else
            {
                MessageBox.Show("Session not found");
            }
        }

        private void SessionFilter_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SessionFilter.SelectedIndex > 0)
            {
                LCinemaView.ItemsSource = SessionsRepository.SearchSession(Search.Text, SessionFilter.SelectedIndex);
            }
            else
            {
                LCinemaView.ItemsSource = SessionsRepository.SearchSession(Search.Text);
            }
        }
    }
}