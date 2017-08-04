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

            Authenticator authenticator = new Authenticator();
            errorResponse = authenticator.LoginAuthenticator(username, password);

            if (errorResponse.AccessBool==true)
            {
                HomePage home = new BlackYab.HomePage();
                this.Close();
                home.Show();
            }
            else
            {
                MessageBox.Show(errorResponse.ErrorType+"\nPlease try again");
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

            Authenticator authenticator = new Authenticator();

            /*string register_tournament = authenticator.RegAuthenticator(username, name, password, t_name, rounds, break_round, start_date, end_date);
            bool error_response = authenticator.ErrorResponse(register_tournament);
            if (error_response == true)
            {
                
            }
            else
            {
                MessageBox.Show("Tournament was not registered\n"+ register_tournament + "\nPlease try again");
            }*/

        }
    }
}
