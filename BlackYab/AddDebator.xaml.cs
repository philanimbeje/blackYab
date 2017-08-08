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
        string[] institutions;
        string[] teams;

        InputFunctions input = new InputFunctions();

        public AddDebator()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var details = new List<string>();

            string name = txtBoxAddName.Text;
            details.Add(name);
            string institution = comboBoxAddInstitution.Text;
            string team = comboBoxAddTeams.Text;
            string canbreak = Convert.ToString(checkBoxAddCanBreak.IsChecked);
            string isSpeaker = Convert.ToString(radioButtonAddSpeaker.IsChecked);
            string debatorType = "";

            if (isSpeaker=="true")
            {
                debatorType = "addSpeaker";
                input.data(details, model, "addSpeaker");

            }
            if(isSpeaker=="false")
            {
                debatorType = "addAdjudicator";
                input.data(details, model, "addAdjudicator");
            }

            //validation function
            //input function call
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
