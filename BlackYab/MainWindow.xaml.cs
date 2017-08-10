using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BlackYab
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ErrorResponse errorResponse = new ErrorResponse();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUserNameLogin.Text;
            string password = passwordBoxLogin.Password;

            var loginDetails = new List<string>();

            loginDetails.Add(username);
            loginDetails.Add(password);

            DataAuthenticator authenticator = new DataAuthenticator("Login", loginDetails);
            errorResponse = authenticator.error;

            if (errorResponse.AccessBool==true)
            {
                HomePage home = new BlackYab.HomePage();
                this.Close();
                home.Show();
            }
            else
            {
                MessageBox.Show(errorResponse.ErrorMessage+"\nPlease try again");
            }
        }

        private void buttonRegister_Click(object sender, RoutedEventArgs e)
        {
            string username= txtRegUsername.Text;
            string name= txtRegName.Text;
            string password = passwordBoxReg.Password;
            string t_name = txtRegTName.Text;
            string rounds = txtRegRounds.Text;
            string break_round = txtRegBreakRound.Text;
            string start_date = RegStartDate.Text;
            string end_date = RegEndDate.Text;

            var registrationDetails = new List<string>();

            registrationDetails.Add(username);
            registrationDetails.Add(name);
            registrationDetails.Add(password);
            registrationDetails.Add(t_name);
            registrationDetails.Add(rounds);
            registrationDetails.Add(break_round);
            registrationDetails.Add(start_date);
            registrationDetails.Add(end_date);

            DataAuthenticator authenticator = new DataAuthenticator("Register", registrationDetails);
            errorResponse = authenticator.error;

            if (errorResponse.AccessBool == true)
            {
               
            }
            else
            {
                MessageBox.Show(errorResponse.ErrorMessage + "\nPlease try again");
            }
        }
    }
}
