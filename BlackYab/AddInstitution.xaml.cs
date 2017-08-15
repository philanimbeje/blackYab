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
    /// Interaction logic for AddInstitution.xaml
    /// </summary>
    public partial class AddInstitution : Window
    {
        Model model = (Model)Application.Current.Properties["Model"];

        StoredProcedureFunctions input = new StoredProcedureFunctions();
        public AddInstitution()
        {
            InitializeComponent();
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void buttonAddInstitution_Click(object sender, RoutedEventArgs e)
        {
            var details = new List<string>();
            details.Add(txtAddInstitutionName.Text);
            details.Add(Convert.ToString(checkBoxAddLocalInstitution.IsChecked.ToString()[0]));
            input.InputData(details, model, WordList.addInstitution);
            this.Close();
        }
    }
}
