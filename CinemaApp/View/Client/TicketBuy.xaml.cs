using System;
using CinemaApp.data.EntityS;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using CinemaApp.data.RepositoryFunc;
using CinemaApp.middle;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;

namespace CinemaApp.View.Client
{
    public class Place
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Brush Color { get; set; }
        public bool Visible { get; set; }
    }


    public class RowsPlaces
    {
        public int Row { get; set; }
        public int Place { get; set; }

        public override string ToString()
        {
            return $"Ряд {Row} Место {Place}";
        }

        public RowsPlaces(int row, int place)
        {
            Row = row;
            Place = place;
        }
    }

    public partial class TicketBuy : Window
    {
        private int id { get; set; }
        private List<CinemaPlace> cinemaPlace = new List<CinemaPlace>();

        public void drawButtons(int id)
        {
            var hallRows = 50;
            var hallPlaces = 10;
            var buff = new List<Place>();
            Hall hall;
            var list = new List<Ticket>();
            using (var db = new CinemaEntities())
            {
                list = db.Ticket.Where(x => x.id_Session == id).ToList();
                cinemaPlace = db.CinemaPlace.Where(x => x.id_Session == id).ToList();
                var obj = cinemaPlace.FirstOrDefault(y => true);
                hall = (Hall)db.Hall.FirstOrDefault(x => x.id_Hall == obj.id_Hall);
            }

            if (hall != null)
            {
                hallRows = hall.Row;
                hallPlaces = hall.Number_Seats;
            }

            var line = hallRows; // рядов
            var height = hallPlaces; // мест в ряду

            stack.Orientation = Orientation.Vertical;

            for (int i = 0; i < line; i++)
            {
                var panel = new StackPanel
                {
                    Orientation = Orientation.Horizontal
                };
                for (var j = 0; j < height; j++)
                {
                    var button = new Button
                    {
                        Name = $"Btn{i}{j}",
                        Margin = new Thickness(2),
                        Width = 100,
                        FontSize = 9,
                        Content = new RowsPlaces(i, j),
                    };
                    var newI = i;
                    var newJ = j;
                    button.Click += (sender, eventArgs) =>
                    {
                        BasketRepository.AddToTicket(new RowsPlaces(newI, newJ), id);
                        BacketView.ItemsSource = BasketRepository._tickets.ToList();
                    };
                    foreach (var item in list.Where(item => i == item.Row && j == item.Place))
                    {
                        button.Background = Brushes.Gray;
                        button.IsEnabled = false;
                    }

                    panel.Children.Add(button);
                }

                stack.Children.Add(panel);
            }
        }

        public TicketBuy(Get_All_Session id)
        {
            InitializeComponent();
            this.id = id.Session_id_Session;
            drawButtons(id.Session_id_Session);
            session = id;
        }

        private void ButtonAdd_OnClick(object sender, RoutedEventArgs e)
        {
            if (BasketRepository.AddToBacket())
            {
                MessageBox.Show("Заказ оформлен");
                BasketRepository.ClearBacket();
                BacketView.ItemsSource = BasketRepository._tickets;
                stack.Children.Clear();
                drawButtons(id);
            }
            else
            {
                MessageBox.Show("Зарегестрируйтесь!");
            }
        }

        private void ButtonClear_OnClick(object sender, RoutedEventArgs e)
        {
            BasketRepository.ClearBacket();
            BacketView.ItemsSource = BasketRepository._tickets;
        }
        public Get_All_Session session { get; set; }
        private void BetaCheck_OnClick(object sender, RoutedEventArgs e)
        {
            Film film = new Film();
            film.Name_Film = session.Film_Name_Film;
            film.Description = session.Film_Description;
            Check.CheckClient(BasketRepository._tickets, film);
        }
    }
}