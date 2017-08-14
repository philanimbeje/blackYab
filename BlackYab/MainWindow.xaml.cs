using System.Collections.Generic;
using System.Windows;

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
            var loginDetails = new List<string>();

            loginDetails.Add(txtUserNameLogin.Text);
            loginDetails.Add(passwordBoxLogin.Password);
 
            Application.Current.Properties["LoginDetails"] = loginDetails;

            DataAuthenticator authenticator = new DataAuthenticator(WordList.Login, loginDetails);

            if (authenticator.Error.canAccess)
            {
                HomePage home = new BlackYab.HomePage();
                this.Close();
                home.Show(); 
            }
            else
            {
                MessageBox.Show(authenticator.Error.ErrorMessage+"\nPlease try again");
            }
        }

        private void buttonRegister_Click(object sender, RoutedEventArgs e)
        {
            var registrationDetails = new List<string>();
            registrationDetails.Add(txtRegUsername.Text);
            registrationDetails.Add(txtRegName.Text);
            registrationDetails.Add(passwordBoxReg.Password);
            registrationDetails.Add(txtRegTName.Text);
            registrationDetails.Add(txtRegRounds.Text);
            registrationDetails.Add(txtRegBreakRound.Text);
            registrationDetails.Add(RegStartDate.Text);
            registrationDetails.Add(RegEndDate.Text);

            DataAuthenticator authenticator = new DataAuthenticator(WordList.Register, registrationDetails);
            
            if (authenticator.Error.canAccess) 
            {
            }
            else
            {
                MessageBox.Show(authenticator.Error.ErrorMessage + "\nPlease try again");
            }
        }
    }
}
