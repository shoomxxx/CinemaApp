using System;
using System.Linq;
using CinemaApp.data.EntityS;
using DocumentFormat.OpenXml.Bibliography;

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
                    CurrentUser.IdSession = Guid.NewGuid().ToString();
                    CurrentUser.Id_Role = user.id_Role;
                    return user;
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return null;
            }
        }

        public User UserRegistration(string clientName, string clientSurname, string clientPatronymic, string clientMail, string clientPhone, DateTime clientDate, string clientLogin, string clientPassword) // Регистрация
        {
            try
            {
                using (CinemaEntities db = new CinemaEntities())
                {
                    Client client = new Client();
                    {
                        client.Name = clientName;
                        client.Surname = clientSurname;
                        client.Patronymic = clientPatronymic;
                        client.mail = clientMail;
                        client.Phone_number = clientPhone;
                        client.Date_Of_Birth = clientDate;
                    }
                    db.Client.Add(client);
                    db.SaveChanges();

                    User user = new User();
                    {
                        user.id_Client = db.Client.FirstOrDefault(x => x.Name == client.Name && x.Surname == client.Surname && x.Date_Of_Birth == client.Date_Of_Birth && x.Phone_number == client.Phone_number).id_Client;
                        user.id_Role = 1;
                        user.Login = clientLogin;
                        user.Password = clientPassword;

                    }
                    db.User.Add(user);
                    db.SaveChanges();
                    
                    return user;
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