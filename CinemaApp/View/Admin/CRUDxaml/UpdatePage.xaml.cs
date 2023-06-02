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
    /// Логика взаимодействия для UpdatePage.xaml
    /// </summary>
    public partial class UpdatePage : Window
    {
        CinemaEntities _db = new CinemaEntities();
        int Id;
        CRUD<Get_All_Session, int> cRUD;
        public UpdatePage(int memberId)
        {
            InitializeComponent();
            Id = memberId;
            Get_All_Session updateMember = (from m in _db.Get_All_Session
                                            where m.Session_id_Session == Id
                                            select m).Single();
            DataContext = updateMember;
        }

        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            cRUD = new CRUD<Get_All_Session, int>();
            cRUD.update(DataContext as Get_All_Session);
            this.Close();
        }
    }
}
