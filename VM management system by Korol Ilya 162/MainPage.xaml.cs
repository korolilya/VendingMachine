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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        Repository _repository = new Repository();
        public MainPage()
        {
            InitializeComponent();

        }

        private void buttonTerminals_Click(object sender, RoutedEventArgs e)
        {            
            NavigationService.Navigate(new CRUD_Terminals(_repository));
        }

        private void buttonProducts_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CRUD_Products(_repository));
        }

        private void buttonStatistics_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TerminalsStat(_repository));
        }
    }
}
