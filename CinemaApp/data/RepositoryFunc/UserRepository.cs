using System;
using System.Linq;
using CinemaApp.data.EntityS;

namespace CinemaApp.data.RepositoryFunc
{
    public class UserRepository
    {
        public User UserCheck(string login, string password) //Проверка пользователя на существование
        {
            try
            {
                using (CinemaEntities db = new CinemaEntities())
                {
                    var user = db.User.FirstOrDefault(x => x.Login.Contains(login) && x.Password == password);
                    var client = db.Client.FirstOrDefault(x => x.id_Client == user.id_Client);
                    if (user == null || client == null) return null;
                    CurrentUser.IdUser = user.id_User;
                    CurrentUser.Login = user.Login;
                    CurrentUser.Password = user.Password;
                    CurrentUser.Mail = client.mail;
                    CurrentUser.Name = client.Name;
                    CurrentUser.Surname = client.Surname;
                    CurrentUser.Patronymic = client.Patronymic;
                    CurrentUser.DateOfBirth = client.Date_Of_Birth;
                    CurrentUser.PhoneNumber = client.Phone_number;
                    return user;
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return null;
            }
        }

        public User UserRegistration() // Регистрация
        {
            try
            {
                using (CinemaEntities db = new CinemaEntities())
                {
                    return db.User.FirstOrDefault();
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return null;
            }
        }

        //Регистрация - Авторизация
        //Удаление аккаунта(?)
    }
}