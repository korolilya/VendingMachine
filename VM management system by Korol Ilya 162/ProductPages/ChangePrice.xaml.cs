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
    /// Логика взаимодействия для ChangePrice.xaml
    /// </summary>
    public partial class ChangePrice : Page
    {
        Repository _repository;
        Product _product;
        public ChangePrice(Repository repository, Product product)
        {
            InitializeComponent();
            _repository = repository;
            _product = product;
            textblockName.Text = product.Name;
        }

        private void buttonGoBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void buttonConfirm_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(textboxNewDate.Text) && !string.IsNullOrWhiteSpace(textboxNewPP.Text) && !string.IsNullOrWhiteSpace(textboxNewSP.Text))
                {
                    if (double.Parse(textboxNewPP.Text) > double.Parse(textboxNewSP.Text))
                        MessageBox.Show("Selling price must be more than purchase price");
                    _repository.EditPrice(_product, double.Parse(textboxNewSP.Text), double.Parse(textboxNewPP.Text), DateTime.Parse(textboxNewDate.Text));
                    NavigationService.GoBack();
                }
                else
                {
                    MessageBox.Show("Please fill this box!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
