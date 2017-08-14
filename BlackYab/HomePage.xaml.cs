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
using System.Windows.Shapes;

namespace BlackYab
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Window
    {

        Model model = (Model)Application.Current.Properties["Model"];

        AdminDisplay display = new AdminDisplay();
        public HomePage()
        {
            InitializeComponent();
            TournamentSummary();
            AdminViews();
        }

        private void buttonLogOff_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new BlackYab.MainWindow();
            this.Close();
            main.Show();
        }

        private void AdminViews()
        {
            dataGridVTeam.DataContext = model.TeamTable.DefaultView;
            dataGridVAdjudicators.DataContext = model.AdjTable.DefaultView;
            dataGridVInstitution.DataContext = model.InstitutionTable.DefaultView;
            dataGridVOrgcom.DataContext = model.OrgcomTable.DefaultView;
            dataGridVRooms.DataContext = model.VenueTable.DefaultView;
            dataGridVSpeakers.DataContext = model.SpeakerTable.DefaultView;
        }

        private void TournamentSummary()
        {
            labelTName.Content = model.TournamentName;
            labelRound.Content = model.CurrentRound;
            labelLoggedIn.Content = model.AdminName;
            labelCompetitors.Content = model.TotalAdjudicators + model.TotalSpeakers;
            labelSpeakers.Content = model.TotalSpeakers;
            labelSpeakersInTeams.Content = -1;
            labelTeams.Content = model.TotalTeams;
            labelIncompleteTeams.Content = -1;
            labelAdjudicators.Content = model.TotalAdjudicators;
        }

        private void buttonEditDebator_Click(object sender, RoutedEventArgs e)
        {
            var debator = new AddDebator();
            debator.ShowDialog();
        }

        private void buttonEditTeam_Click(object sender, RoutedEventArgs e)
        {
            var team = new BlackYab.AddTeam();
            team.ShowDialog();
        }

        private void buttonEditInstitution_Click(object sender, RoutedEventArgs e)
        {
            var institution = new AddInstitution();
            institution.ShowDialog();
        }

        private void buttonEditVenues_Click(object sender, RoutedEventArgs e)
        {
            var venues = new AddVenues();
            venues.ShowDialog();
        }

        private void buttonEditOrgCom_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
