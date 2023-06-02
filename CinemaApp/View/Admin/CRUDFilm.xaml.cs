using CinemaApp.data.EntityS;
using CinemaApp.View.Admin.CRUDxaml;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.VariantTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CinemaApp.View.Admin
{
    /// <summary>
    /// Логика взаимодействия для CRUDFilm.xaml
    /// </summary>
    public partial class CRUDFilm : Window
    {
        CinemaEntities db = new CinemaEntities();
        public static DataGrid dataGrid;
        public CRUDFilm()
        {
            InitializeComponent();
            Load();
        }
        private void Load()
        {
            myDataGrid.ItemsSource = db.Get_All_Session.ToList();
            dataGrid = myDataGrid;
        }
        private void InsertBtn_Click(object sender, RoutedEventArgs e)
        {
            InsertPage Ipage = new InsertPage();
            Ipage.ShowDialog();

        }

        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            int Id = (myDataGrid.SelectedItem as Get_All_Session).Session_id_Session;
            UpdatePage Upage = new UpdatePage(Id);
            Upage.ShowDialog();

        }
        private void DataGridRow_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var row = sender as DataGridRow;
            var obj = row.DataContext as Get_All_Session;

        }

        private void newList_Click(object sender, RoutedEventArgs e)
        {
            Load();

        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
