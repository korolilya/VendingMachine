using Logic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VM_management_system_by_Korol_Ilya_162
{
    /// <summary>
    /// Логика взаимодействия для EditTerminal.xaml
    /// </summary>
    public partial class EditTerminal : Page
    {
        Repository _repository;
        VMachine _vmachine;
        public EditTerminal(Repository repository, VMachine vMachine)
        {
            InitializeComponent();
            _repository = repository;
            _vmachine = vMachine;
            textboxEdited.Text = _vmachine.Location;
        }

        private void confirm_Click(object sender, RoutedEventArgs e)
        {

            if (!string.IsNullOrWhiteSpace(textboxEdited.Text))
            {
                _repository.EditTerminal(_vmachine, textboxEdited.Text);
                NavigationService.GoBack();
            }
            else
            {
                MessageBox.Show("Please fill all boxes!");
            }
        }

        private void buttonGoBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
