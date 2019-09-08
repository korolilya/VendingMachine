using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Logic;

namespace VM_management_system_by_Korol_Ilya_162
{
    /// <summary>
    /// Логика взаимодействия для CRUD_Products.xaml
    /// </summary>
    public partial class CRUD_Products : Page
    {
        Repository _repository;

        public CRUD_Products(Repository repository)
        {
            InitializeComponent();
            _repository = repository;
            listBoxProducts.ItemsSource = _repository.Products;
            _repository.ProductsChanged += p => RefreshItems();
        }

        private void buttonAddProducts_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new NewProduct(_repository));
        }

        private void RefreshItems()
        {
            listBoxProducts.ItemsSource = _repository.Products;
        }

        private void buttonRemoveProducts_Click(object sender, RoutedEventArgs e)
        {
            var product = listBoxProducts.SelectedItem as Product;
            if (product != null)
            {
                try
                {
                    _repository.DeleteProduct(product);
                    RefreshItems();
                }
                catch (Exception ex)
                {
                   MessageBox.Show(ex.ToString());
                }
                
            }

        }

        private void buttonEditProducts_Click(object sender, RoutedEventArgs e)
        {
            var product = listBoxProducts.SelectedItem as Product;
            if (product != null)
                NavigationService.Navigate(new EditProduct(_repository, product));
        }

      
        private void buttonEditPrice_Click(object sender, RoutedEventArgs e)
        {
            var product = listBoxProducts.SelectedItem as Product;
            if (product != null)
                NavigationService.Navigate(new ChangePrice(_repository, product));
        }

        private void buttonGoBack_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
