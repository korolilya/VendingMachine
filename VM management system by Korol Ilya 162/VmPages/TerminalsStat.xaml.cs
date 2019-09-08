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
    /// Логика взаимодействия для TerminalsStat.xaml
    /// </summary>
    public partial class TerminalsStat : Page
    {
        Repository _repository;
       // DateWindow dw = new DateWindow();
        public TerminalsStat(Repository repository)
        {
            InitializeComponent();
            _repository = repository;
        }

        private void EmptyTerminal_Click(object sender, RoutedEventArgs e)
        {
            listboxStat.ItemsSource = null;
            listboxStat.ItemsSource = _repository.EmptyTerminal;


        }


        private void TotalProfit_Click(object sender, RoutedEventArgs e)
        {
            DateWindow dw = new DateWindow();
            try
            {
                if (dw.ShowDialog() == true)
                {
                    listboxStat.ItemsSource = null;
                    listboxStat.ItemsSource = _repository.ProfitableTerminal(dw.Year, dw.Month);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void UnpopularProd_Click(object sender, RoutedEventArgs e)
        {
            DateWindow dw = new DateWindow();
            if (dw.ShowDialog() == true)
            {
                listboxStat.ItemsSource = null;
                listboxStat.ItemsSource = _repository.UnpopularProducts(dw.Year, dw.Month);
            }
        }
        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
