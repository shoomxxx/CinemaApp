using System;
using System.Data.Common;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using CinemaApp.data.EntityS;
using CinemaApp.data.RepositoryFunc;
using CinemaApp.View.Admin;

namespace CinemaApp.View.Default
{
    public partial class ListViewSessionPage : Page
    {
        private CRUD<Session, int> crud = new CRUD<Session, int>();
        static readonly SessionsRepository _sessionsRepository = new SessionsRepository();

        private void Search_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            LCinemaView.ItemsSource = SessionsRepository.SearchSession(Search.Text);
        }

        public ListViewSessionPage()
        {
            InitializeComponent();
            SessionFilter.SelectedIndex = 0;
            var currentSessionList = _sessionsRepository.ManySessions().OrderBy(x => x.Session_Date_Film).ToList();
            LCinemaView.ItemsSource = currentSessionList;
        }

        private void LCinemaView_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var s = LCinemaView.SelectedItem as Get_All_Session;

            if (CurrentUser.Id_Role== 2)
            {
                try
                {
                    
                    if (s != null)
                    {
                        Session ses = new Session();

                        ses.id_Session = s.Session_id_Session;
                        ses.Price_Film = s.Session_Price_Film;
                        ses.id_Hall = s.Session_id_Hall;
                        ses.id_Film = s.Session_id_Film;
                        ses.Date_Film = s.Session_Date_Film;
                        ses.Purchased_Tickets = s.Session_Purchased_Tickets;
                        ses.id_Cinema = s.Session_id_Cinema;

                        //var ses = _sessionsRepository.OneSession(s.Session_id_Session);

                        var result = CustomMessageBox.ShowCustomMessageBox("ADMIN PANEL", ses.id_Session.ToString(), false);
                        if (result == DialogResult.Yes)
                        {
                            CRUDFilm Ipage = new CRUDFilm();
                            Ipage.ShowDialog();

                        }
                        else if (result == DialogResult.No)
                        {
                            var response = _sessionsRepository.DeleteSession(ses);
                            if (response != null)
                            {
                                System.Windows.MessageBox.Show("Удален");
                                var currentSessionList = _sessionsRepository.ManySessions().OrderBy(x => x.Session_Date_Film).ToList();
                                LCinemaView.ItemsSource = currentSessionList;

                            }
                            else
                            {
                                System.Windows.MessageBox.Show("Не удален");
                            }
                        }
                        else if (result == DialogResult.Cancel)
                        {
                            if (LCinemaView.SelectedItem is Get_All_Session session)
                            {
                                NavigationService?.Navigate(new DetailedSessionPage(session));
                            }
                            else
                            {
                                System.Windows.MessageBox.Show("Session not found");
                            }
                        }
                    }

                }
                catch (Exception err)
                {
                    System.Windows.MessageBox.Show(err.Message);
                }
            }
            else
            {
                NavigationService?.Navigate(new DetailedSessionPage(s));
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
        Session session = new Session();
        private void DELETE_Click(object sender, RoutedEventArgs e)
        {
            var sel = LCinemaView.SelectedItem as Session;

            System.Windows.MessageBox.Show(session.id_Session.ToString());
            //crud.Delete(session);
        }

        private void REDACT_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ADD_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}