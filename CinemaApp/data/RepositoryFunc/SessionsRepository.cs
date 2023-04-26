using System;
using System.Collections.Generic;
using System.Linq;
using CinemaApp.data.EntityS;

namespace CinemaApp.data.RepositoryFunc
{ 
    public class SessionsRepository
    {
        public List<Get_All_Session> ManySessions() //Показать все сеансы
        {
            try
            {
                using (CinemaEntities db = new CinemaEntities())
                {
                    return db.Get_All_Session.ToList();
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
                    db.Session.Remove(entity);
                    db.SaveChangesAsync();
                    return null;
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return null;
            }
        }

        public Session AddSession(Session entity) //Добавление сеансов
        {
            try
            {
                using (CinemaEntities db = new CinemaEntities())
                {
                    db.Session.Add(entity);
                    db.SaveChangesAsync();
                    return null;
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return null;
            }
        }

        public Session EditSession() //Редактирование сеансов
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

        public static List<Get_All_Session> SearchSession(string x, int idSort = -1)
        {
            try
            {
                using (CinemaEntities db = new CinemaEntities())
                {
                    switch (idSort)
                    {
                        case 1:
                            return db.Get_All_Session.Where(session => session.Film_Name_Film.Contains(x)).OrderBy(session => session.Film_Name_Film).ToList();
                        default: return db.Get_All_Session.Where(session => session.Film_Name_Film.Contains(x)).OrderBy(session => session.Session_Date_Film).ToList();
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