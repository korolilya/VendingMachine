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
    /// Логика взаимодействия для NewProduct.xaml
    /// </summary>
    public partial class NewProduct : Page
    {
        Repository _repository;

        public NewProduct(Repository repository)
        {
            InitializeComponent();
            _repository = repository;
        }

        private void CreateProd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (double.Parse(textboxNewPP.Text) > double.Parse(textboxNewSP.Text))
                {
                    MessageBox.Show("Selling price must be more than purchase price");
                }
                else
                {
                Product product = new Product();
                _repository.AddProduct(product, textboxNewCode.Text, textboxNewName.Text, double.Parse(textboxNewPP.Text), double.Parse(textboxNewSP.Text));
                NavigationService.GoBack();
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
