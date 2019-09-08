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
    /// Логика взаимодействия для EditProduct.xaml
    /// </summary>
    public partial class EditProduct : Page
    {
        Repository _repository;
        Product _product;
        public EditProduct(Repository repository, Product product)
        {
            InitializeComponent();
            _repository = repository;
            _product = product;
            textboxNewName.Text = _product.Name;
        }

        private void buttonConfirm_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(textboxNewName.Text))
                {
                    _repository.EditProduct(_product, textboxNewName.Text);
                    NavigationService.GoBack();
                }
                else
                {
                    MessageBox.Show("Please fill this box!");
                    textboxNewName.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void buttonGoBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
