﻿using System.Windows;

namespace CinemaApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
                MainFrame.Navigate(new View.Client.HomePage());
        }

    }
}
