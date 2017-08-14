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
    /// Interaction logic for AddOrgcom.xaml
    /// </summary>
    public partial class AddOrgcom : Window
    {
        Model model = (Model)Application.Current.Properties["Model"];

        StoredProcedureFunctions input = new StoredProcedureFunctions();
        public AddOrgcom()
        {
            InitializeComponent();
        }

        private void btnAddOrgCom_Click(object sender, RoutedEventArgs e)
        {
            var details = new List<string>();
            details.Add(txtAddOrgComUsername.Text);
            details.Add(pwdAddOrgCom.Password);
            details.Add(txtAddOrgComName.Text);
            details.Add(Convert.ToString(model.TournamentID));
            details.Add(comboBoxAddOrgComRole.Text);
            details.Add(Convert.ToString(DateTime.Now));
            details.Add(Convert.ToString(Convert.ToString(checkBoxOrgCom.IsChecked)[0]));

            input.InputData(details, model, WordList.addAdmin);
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
