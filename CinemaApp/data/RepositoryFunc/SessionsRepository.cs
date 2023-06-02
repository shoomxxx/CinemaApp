using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CinemaApp.data.EntityS;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Wordprocessing;

namespace CinemaApp.data.RepositoryFunc
{
    public class SessionsRepository
    {
        private Get_All_Session _allSession = new Get_All_Session();

        public List<Get_All_Session> ManySessions() //Показать все сеансы
        {
            try
            {
                using (CinemaEntities db = new CinemaEntities())
                {
                    return db.Get_All_Session.Where(x => x.Session_is_Deleted == true).ToList();
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return null;
            }
        }

        public Get_All_Session OneSession(int id) //Подробная информация о отдельном сеансе
        {
            try
            {
                using (CinemaEntities db = new CinemaEntities())
                {
                    return db.Get_All_Session.FirstOrDefault(x => x.Session_id_Session == id);
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return null;
            }
        }

        public Session FiltrationSession() //Фильтрация сеансов
        {
            try
            {
                using (CinemaEntities db = new CinemaEntities())
                {
                    return db.Session.FirstOrDefault();
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return null;
            }
        }

        public Session DeleteSession(Session entity) //Удаление сеансов
        {
            try
            {
                using (CinemaEntities db = new CinemaEntities())
                {
                    var s1 = db.Session.FirstOrDefault(x => x.id_Session == entity.id_Session);
                    s1.is_Deleted = false;
                    db.SaveChanges();
                    return s1;
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return null;
            }
        }

        /*        public Film AddSession(Film film) //Добавление сеансов
                {

                }
        */
        public void EditSession(Get_All_Session film) //Редактирование сеансов
        {
            try
            {
                using (CinemaEntities db = new CinemaEntities())
                {
                    var EDIT = db.Film.Where(x => x.id_Film == film.Session_id_Film).FirstOrDefault();

                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return;
            }

        }

        public static List<Get_All_Session> SearchSession(string x, int idSort = -1)
        {
            try
            {
                using (CinemaEntities db = new CinemaEntities())
                {
                    switch (idSort)
                    {
                        case 1:
                            return db.Get_All_Session.Where(session => session.Film_Name_Film.Contains(x))
                                .OrderBy(session => session.Film_Name_Film).ToList();
                        default:
                            return db.Get_All_Session.Where(session => session.Film_Name_Film.Contains(x))
                                .OrderBy(session => session.Session_Date_Film).ToList();
                    }
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return null;
            }
        }
    }
}