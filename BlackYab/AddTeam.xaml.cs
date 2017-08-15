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
    /// Interaction logic for AddTeam.xaml
    /// </summary>
    public partial class AddTeam : Window
    {
        Model model = (Model)Application.Current.Properties["Model"];

        StoredProcedureFunctions input = new StoredProcedureFunctions();
        HomePage home = new HomePage();
        public AddTeam()
        {
            InitializeComponent();
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void buttonAddTeam_Click(object sender, RoutedEventArgs e)
        {
            var details = new List<string>();
            details.Add(txtTeamName.Text);
            details.Add(Convert.ToString(model.TournamentID));
            details.Add(Convert.ToString(Convert.ToString(checkBoxAddTeamCanBreak.IsChecked)[0]));
            details.Add(Convert.ToString(DateTime.Now));

            input.InputData(details, model, WordList.addTeam);
            this.Close();
            //home.Update();
            
        }
    }
}
