using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Windows;
using System.Windows.Input;

namespace CinemaApp.View.Admin
{

    /// <summary>
    /// Логика взаимодействия для CustomMessageBox.xaml
    /// </summary>
    public partial class CustomMessageBox : Window
    {
        enum CheckQuestion
        {
            Yes,
            No,
            Cancel,
            None
        };
        Nullable<CheckQuestion> customDialogResult = CheckQuestion.None;
        public CustomMessageBox(string caption, string message, bool dialog)
        {
            InitializeComponent();
            tbMessageBoxCaption.Text = caption;
            tbMessageBoxMessage.Text = message;
            if (!dialog)
            {
                //btnMessageBoxClose.Visibility = Visibility.Visible;
                btnMessageBoxNo.Visibility = Visibility.Visible;
                btnMessageBoxYes.Visibility = Visibility.Visible;
            }
        }

        private void btnMessageBoxNo_Click(object sender, RoutedEventArgs e)
        {
            customDialogResult = CheckQuestion.No;
            this.Close();
        }

        private void imgMessageBoxCancel_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void btnMessageBoxYes_Click(object sender, RoutedEventArgs e)
        {
            customDialogResult = CheckQuestion.Yes;
            this.Close();
        }

        private void btnMessageBoxClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        internal static System.Windows.Forms.DialogResult ShowCustomMessageBox(string message, string caption = "Default caption", bool dialog = true)
        {
            CustomMessageBox mb = new CustomMessageBox(caption, message, dialog);
            mb.Topmost = true;
            mb.ShowDialog();


            switch (mb.customDialogResult)
            {
                case CheckQuestion.Yes:
                    return System.Windows.Forms.DialogResult.Yes;
                case CheckQuestion.No:
                    return System.Windows.Forms.DialogResult.No;
                case CheckQuestion.Cancel:
                    return System.Windows.Forms.DialogResult.Cancel;
                default:
                    return System.Windows.Forms.DialogResult.None;
                case null:
                    return System.Windows.Forms.DialogResult.None;
            }

            /*if (mb.DialogResult == null)
                return System.Windows.Forms.DialogResult.None;
            else if (mb.DialogResult == true)
                return System.Windows.Forms.DialogResult.Yes;
            else
                return System.Windows.Forms.DialogResult.No;*/
        }

        private void btnMessageBoxCancel_Click(object sender, RoutedEventArgs e)
        {
            customDialogResult = CheckQuestion.Cancel;
            this.Close();
        }
    }
}
