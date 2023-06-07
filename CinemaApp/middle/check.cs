using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;
using CinemaApp.data.EntityS;
using CinemaApp.View.Client;

namespace CinemaApp.middle
{
    public class Check
    {
        private static readonly Client Client = new Client();

        public static void CheckClient(List<Ticket> tickets, Film filmName)
        {
            using (var db = new CinemaEntities())
            {
            }


            Client.Name = CurrentUser.Name;
            Client.Surname = CurrentUser.Surname;
            Client.Patronymic = CurrentUser.Patronymic;
            Client.mail = CurrentUser.Mail;
            Client.Phone_number = CurrentUser.PhoneNumber;
            //data = CurrentUser.DateOfBirth.ToString(); 

            var ticket = new Ticket();

            var helper = new Helper(@"C:\Users\Shoom\Desktop\Шумилин ПКС-303\КП\WPF\Cinema\CinemaApp\Check.doc");

            var fio = Client.Name + " " + Client.Surname + " " + Client.Patronymic;
            string forCheck = "";
            decimal sum = 0;
            string date = "2023.01.05 12:00:00";
            

            foreach (var item in tickets)
            {
                forCheck += $"Ряд:{item.Row}\n" +
                    $"Место:{item.Place}\n\n";
                sum += item.Price_Ticket;

                var items = new Dictionary<string, string>
            {
                { "<FIO>", fio },
                { "<MAIL>", Client.mail },
                { "<PhoneNumber>", Client.Phone_number },
                { "<NameFilm>", filmName.Name_Film},
                { "<Place>", item.Place.ToString()},
                { "<Row>", item.Row.ToString()},
                { "<Price>", item.Price_Ticket.ToString()},
                    { "<Date>", date}
            };
                MessageBox.Show(helper.Process(items)
                   ? "Файл успешно экспортирован в Word"
                   : "Возникли проблемы с экспортом файла");
            }

        }
    }
}