using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using CinemaApp.data.EntityS;
using CinemaApp.data.RepositoryFunc;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.ExtendedProperties;
using DocumentFormat.OpenXml.Vml.Spreadsheet;

namespace CinemaApp.View.Admin
{
    public partial class FilmAdd : Page
    {
        public Film Selected_Film = new Film();


        public CRUD<Film, int> crudFilm = new CRUD<Film, int>();
        public CRUD<Hall, int> crudHall = new CRUD<Hall, int>();

        public List<Film> films = new List<Film>();
        public List<Hall> halls = new List<Hall>();

        public FilmAdd(Session session)
        {
            InitializeComponent();
            DataContext = session;
            films = crudFilm.GetMany().ToList();
            filmComboBox.ItemsSource = films;

            halls = crudHall.GetMany().ToList();
            hallComboBox.ItemsSource = halls;

            Selected_Film = films.FirstOrDefault(x => x.id_Film == session.id_Film);
            filmComboBox.SelectedItem = Selected_Film;
            stackFilms.DataContext = Selected_Film;
        }

        private void SaveButton_OnClick(object sender, RoutedEventArgs e)
        {

        }

        private void filmComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Selected_Film = filmComboBox.SelectedItem as Film;
            stackFilms.DataContext = Selected_Film;
        }

        private void hallComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var sel = hallComboBox.SelectedItem as Hall;
        }
    }

}