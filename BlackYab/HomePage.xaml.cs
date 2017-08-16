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

        GetFunctions get = new GetFunctions();
        AdminDisplay display = new AdminDisplay();

        public HomePage()
        {
            InitializeComponent();
            Update();
        }

        public void Update()
        {
            get.TournamentDetails(model);
            TournamentSummary();
            AdminViews();
            ReportViews();
        }

        private void buttonLogOff_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new BlackYab.MainWindow();
            this.Close();
            main.Show();
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
            var orgcom = new AddOrgcom();
            orgcom.ShowDialog();
        }

        private void buttonEditViewUpdate_Click(object sender, RoutedEventArgs e)
        {
            Update();
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

        private void ReportViews()
        {
            GeneralReport.DataContext = model.GeneralReport;
            SpeakersReport.DataContext = model.SpeakerReport;
            AdjReport.DataContext = model.AdjReport;
            TeamsReport.DataContext = model.TeamReport;
            RoundReport.DataContext = model.RoundReport;
            VenueReport.DataContext = model.VenueReport;
            InstitutionReport.DataContext = model.InstitutionReport;
            //AdminReport.DataContext = model.AdminReport;
        }

        private void btnPDFTeam_Click(object sender, RoutedEventArgs e)
        {
            var report = new ExportReport(model.TeamReport, getPath());
            ExportComplete();
        }

        private void btnPDFGeneral_Click(object sender, RoutedEventArgs e)
        {
        }

        private void btnAdjReport_Click(object sender, RoutedEventArgs e)
        {
            var report = new ExportReport(model.AdjReport, getPath());
            ExportComplete();
        }

        private void btnRounds_Click(object sender, RoutedEventArgs e)
        {
            var report = new ExportReport(model.RoundReport, getPath());
            ExportComplete();
        }

        private void btnVenues_Click(object sender, RoutedEventArgs e)
        {
            var report = new ExportReport(model.VenueReport, getPath());
            ExportComplete();

        }

        private void btnInstitution_Click(object sender, RoutedEventArgs e)
        {
            var report = new ExportReport(model.InstitutionReport, getPath());
            ExportComplete();
        }

        private string getPath()
        {
            return "exportFile";
        }

        private void ExportComplete()
        {
            MessageBox.Show("Export Complete");
        }
    }
}
