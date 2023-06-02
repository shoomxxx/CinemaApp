using CinemaApp.data.EntityS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.data.RepositoryFunc
{
    public class CRUD<TEntity, TCode> where TEntity : class
    {
        CinemaEntities db = new CinemaEntities();
        public Get_All_Session add(Get_All_Session get_All_Session)
        {
            Film film = new Film()
            {
                Name_Film = get_All_Session.Film_Name_Film,
                Actors = get_All_Session.Film_Actors,
                Description = get_All_Session.Film_Description,
                Genre = get_All_Session.Film_Genre,
                Image = get_All_Session.Film_Image,
                Duration = get_All_Session.Film_Duration,
            };
            db.Film.Add(film);
            db.SaveChanges();
            Session session = new Session()
            {
                Price_Film = get_All_Session.Session_Price_Film,
                //Inf_Cinema = get_All_Session.,
                id_Cinema = get_All_Session.Session_id_Cinema,
                //id_Session = get_All_Session.Session_id_Session,
                Date_Film = get_All_Session.Session_Date_Film,
                id_Film = get_All_Session.Session_id_Film,
                id_Hall = get_All_Session.Session_id_Hall
            };
            db.Session.Add(session);
            db.SaveChanges();
            return get_All_Session;
        }

        public Get_All_Session update(Get_All_Session get_All_Session)
        {
            Film film = db.Film.FirstOrDefault(x => x.id_Film == get_All_Session.Session_id_Film);
            film.Name_Film = get_All_Session.Film_Name_Film;
            film.Actors = get_All_Session.Film_Actors;
            film.Description = get_All_Session.Film_Description;
            film.Genre = get_All_Session.Film_Genre;
            film.Image = get_All_Session.Film_Image;
            film.Duration = get_All_Session.Film_Duration;

            db.SaveChanges();

            Session session = db.Session.FirstOrDefault(x => x.id_Session == get_All_Session.Session_id_Session);

            session.id_Cinema = get_All_Session.Session_id_Cinema;
            session.id_Session = get_All_Session.Session_id_Session;
            session.Date_Film = get_All_Session.Session_Date_Film;
            session.id_Film = get_All_Session.Session_id_Film;
            session.id_Hall = get_All_Session.Session_id_Hall;
            db.SaveChanges();
            return get_All_Session;
        }
        /// <summary>
        /// Удаление объекта из базы данных SpaceTravel
        /// </summary>
        /// <param name="model">Модель которая должна быть удалена</param>
        /// <returns>Возвращает переданную модель если она удалена, null - была ошибка</returns>
        public virtual TEntity Delete(TEntity model)
        {
            try
            {
                if (model == null) return null;
                using (CinemaEntities db = new CinemaEntities())
                {
                    db.Set<TEntity>().Remove(model);
                    db.SaveChanges();
                    return model;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.Message);
                return null;
            }

        }

        /// <summary>
        /// Достать список объектов из базы данных SpaceTravel
        /// </summary>
        /// <returns>Возвращает список</returns>
        public virtual IEnumerable<TEntity> GetMany()
        {
            try
            {
                using (CinemaEntities db = new CinemaEntities())
                {
                    return db.Set<TEntity>().ToList();
                }
            }
            catch
            {
                return Enumerable.Empty<TEntity>();
            }
        }

        /// <summary>
        /// Достает 1 элемент из базы данных SpaceTravel
        /// </summary>
        /// <param name="item">Свойство модели по которому будет происходить поиск</param>
        /// <returns>Возвращает объект если все успешно, null - была ошибка</returns>
        public virtual TEntity GetOne(TCode item)
        {
            try
            {
                if (item == null) return null;
                using (CinemaEntities db = new CinemaEntities())
                {
                    return db.Set<TEntity>().Find(item);
                }
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Вставка в базу данных SpaceTravel
        /// </summary>
        /// <param name="model">Объект для вставки</param>
        /// <returns>Возвращает null, если объект успешно вставлен, иначе ошибка</returns>
        public virtual string Insert(TEntity model)
        {
            try
            {
                if (model == null) return null;
                using (CinemaEntities db = new CinemaEntities())
                {
                    db.Set<TEntity>().Add(model);
                    db.SaveChanges();
                    return null;
                }

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        /// <summary>
        /// Обновление объекта базы данных SpaceTravel
        /// </summary>
        /// <param name="model">Объект который будет обновлен</param>
        /// <returns>Возвращает null, если объект успешно вставлен, иначе ошибка</returns>
        /*public virtual string Update(TEntity model)
        {
            try
            {
                if (model == null) return null;
                using (CinemaEntities db = new CinemaEntities())
                {
                    db.Set<TEntity>().Add(model);
                    db.SaveChanges();
                    return null;
                }

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }*/
    }
}
