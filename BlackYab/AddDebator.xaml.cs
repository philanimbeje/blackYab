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

        InputFunctions input = new InputFunctions();
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
            string isSpeaker = Convert.ToString(radioButtonAddSpeaker.IsChecked);
           
            //validation function

            if (isSpeaker=="true")
            {
                details.Add(name);
                details.Add(institution);
                details.Add(category);
                details.Add(get.RequestInfo(model, "getTeamID", team));
                details.Add(Convert.ToString(model.TournamentID));
                details.Add(Convert.ToString(DateTime.Now));

                input.data(details, model, "addSpeaker");

            }
            if(isSpeaker=="false")
            {
                details.Add(name);
                details.Add(institution);
                details.Add(Convert.ToString(model.TournamentID));
                details.Add(canbreak);

                input.data(details, model, "addAdjudicator");
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
