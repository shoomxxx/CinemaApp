using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CinemaApp.data.EntityS;
using CinemaApp.View.Client;
using Microsoft.Office.Interop.Word;

namespace CinemaApp.data.RepositoryFunc
{
    public static class BasketRepository
    {
        public static List<Ticket> _tickets = new List<Ticket>();

        public static void ClearBacket()
        {
            _tickets.Clear();
        }
        public static void AddToTicket(RowsPlaces x, int y)
        {
            using (var db = new CinemaEntities())
            {
                var price = db.Session.FirstOrDefault(b => b.id_Session == y);
                if (price == null) return;
                var rowsplaces = new Ticket
                {
                    Price_Ticket = price.Price_Film,
                    id_Session = y,
                   // Session1 = CurrentUser.IdSession,
                    Name = CurrentUser.Name,
                    Surname = CurrentUser.Surname,
                    Row = x.Row,
                    Place = x.Place
                };
                _tickets.Add(rowsplaces);
            }
        }

        public static List<Order> AllBasket()
        {
            try
            {
                using (CinemaEntities db = new CinemaEntities())
                {
                    return db.Order.Where(x => x.id_Session == CurrentUser.IdSession).ToList();
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return null;
            }
        }

        public static bool AddToBacket()
        {
            try
            {
                using (var db = new CinemaEntities())
                {
                    db.Ticket.AddRange(_tickets);
                    db.SaveChanges();
                    _tickets.Clear();
                }
            }
            catch (Exception err)
    {
                Console.WriteLine(err.Message);
                return false;
            }

            return true;
        }

        
    }
}