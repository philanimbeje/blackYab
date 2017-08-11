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
    /// Interaction logic for AddDebator.xaml
    /// </summary>
    public partial class AddDebator : Window
    {
        Model model = (Model)Application.Current.Properties["Model"];

        StoredProcedureFunctions input = new StoredProcedureFunctions();
        GetFunctions get = new GetFunctions();

        public AddDebator()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var details = new List<string>();
            string name = txtBoxAddName.Text;
            string institution = comboBoxAddInstitution.Text;
            string team = comboBoxAddTeams.Text;
            string category= Convert.ToString(radioButtonAddEFL.IsChecked);
            string canbreak = Convert.ToString(checkBoxAddCanBreak.IsChecked);
            bool isSpeaker = Convert.ToBoolean(radioButtonAddSpeaker.IsChecked);
           
            //validation function

            if (isSpeaker)
            {
                details.Add(name);
                details.Add(institution);
                details.Add(category);
                details.Add(get.RequestInfo(model, WordList.getTeamID, team));
                details.Add(Convert.ToString(model.TournamentID));
                details.Add(Convert.ToString(DateTime.Now));

                input.InputData(details, model, WordList.addSpeaker);

            }
            else
            {
                details.Add(name);
                details.Add(institution);
                details.Add(Convert.ToString(model.TournamentID));
                details.Add(canbreak);

                input.InputData(details, model, WordList.addAdjudicator);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
