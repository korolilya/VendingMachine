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
using Logic;

namespace VM_management_system_by_Korol_Ilya_162
{
    /// <summary>
    /// Логика взаимодействия для CRUD_Terminals.xaml
    /// </summary>
    public partial class CRUD_Terminals : Page
    {
        Repository _repository;


        public CRUD_Terminals(Repository repository)
        {
            InitializeComponent();
            _repository = repository;
            listBoxTerminals.ItemsSource = _repository.VMachines;
            listboxTerminalInfo.ItemsSource = null;
            _repository.VMChanged += p => RefreshItems();
        }

        private void buttonEditTerminals_Click(object sender, RoutedEventArgs e)
        {
            var vmachine = listBoxTerminals.SelectedItem as VMachine;
            if (vmachine != null)
                NavigationService.Navigate(new EditTerminal(_repository, vmachine));
        }
        private void RefreshItems()
        {
            listBoxTerminals.ItemsSource = _repository.VMachines;
        }

        private void listBoxTerminals_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                listboxTerminalInfo.ItemsSource = null;
                listboxMoneyInfo.ItemsSource = null;
                var terminal = listBoxTerminals.SelectedItem as VMachine;
                if (terminal != null)
                {
                    listboxTerminalInfo.ItemsSource = terminal.Products;
                    listboxMoneyInfo.ItemsSource = terminal.Money;
                }
            }
            catch { MessageBox.Show("Sorry, this terminal is empty."); };
        }
        
        private void buttonAddTerminals_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddTerminal(_repository));
        }


        private void buttonGoBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
