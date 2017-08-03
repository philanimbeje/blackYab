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

        public HomePage()
        {
            InitializeComponent();
            
            labelTName.Content = model.TournamentName;
            labelRound.Content = model.CurrentRound;
            labelLoggedIn.Content = model.AdminName;
            labelCompetitors.Content = model.TotalAdjudicators + model.TotalSpeakers;
            labelSpeakers.Content = model.TotalSpeakers;
            labelSpeakersInTeams.Content = -1;
            labelTeams.Content = model.TotalTeams;
            labelIncompleteTeams.Content = -1;
            labelAdjudicators.Content = model.TotalAdjudicators;

            dataGridVTeam.DataContext = model.TeamTable.DefaultView;
            dataGridVAdjudicators.DataContext = model.AdjTable.DefaultView;
            dataGridVInstitution.DataContext = model.InstitutionTable.DefaultView;
            dataGridVOrgcom.DataContext = model.OrgcomTable.DefaultView;
            dataGridVRooms.DataContext = model.VenueTable.DefaultView;
            dataGridVSpeakers.DataContext = model.SpeakerTable.DefaultView;
        }

        private void buttonLogOff_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new BlackYab.MainWindow();
            this.Close();
            main.Show();
        }
    }
}
