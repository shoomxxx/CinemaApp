using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using CinemaApp.data.EntityS;
using CinemaApp.View.Client;
using Microsoft.Xaml.Behaviors.Core;

namespace CinemaApp.View.Default
{
    class ButtonPlaces
    {
        public string Content { get; set; }
        public ICommand Command { get; set; }

        public ButtonPlaces(string content, ICommand command)
        {
            Content = content;
            Command = command;
        }
    }


    public partial class DetailedSessionPage : Page
    {
        public Get_All_Session AllSession { get; set; }
        public DetailedSessionPage(Get_All_Session session)
        {
            InitializeComponent();
            AllSession = session;
            PageOnLoad(session);
        }

        private void PageOnLoad(Get_All_Session session)
        {
            DataContext = session;
        }

        private void CloseButton_OnClick(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new ListViewSessionPage());
        }

        private void OrderPlace_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TicketBuy ticketBuy = new TicketBuy(AllSession);
                ticketBuy.Show();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void Behind_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new ListViewSessionPage());
        }
    }
}