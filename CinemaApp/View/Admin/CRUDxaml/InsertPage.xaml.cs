using CinemaApp.data.EntityS;
using CinemaApp.data.RepositoryFunc;
using DocumentFormat.OpenXml.Spreadsheet;
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
using System.Windows.Shapes;

namespace CinemaApp.View.Admin.CRUDxaml
{
    /// <summary>
    /// Логика взаимодействия для InsertPage.xaml
    /// </summary>
    public partial class InsertPage : Window
    {
        CinemaEntities _db = new CinemaEntities();


        CRUD<Get_All_Session, int> cRUD;

        public InsertPage()
        {
            InitializeComponent();
        }

        private void insertBtn_Click(object sender, RoutedEventArgs e)
        {
            cRUD = new CRUD<Get_All_Session, int>();
            cRUD.add(DataContext as Get_All_Session);

            this.Hide();
        }
    }
}

