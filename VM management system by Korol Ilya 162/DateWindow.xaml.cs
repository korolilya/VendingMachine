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

namespace VM_management_system_by_Korol_Ilya_162
{
    /// <summary>
    /// Логика взаимодействия для DateWindow.xaml
    /// </summary>
    public partial class DateWindow : Window
    {
       
        public DateWindow()
        {
            InitializeComponent();
        }

        private int _year;
        private int _month;

        public int Year
        {
            get
            {
                return _year;
            }
        }

        public int Month
        {
            get
            {
                return _month;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string yearString = textboxYear.Text, monthString = textboxMonth.Text;

            if (!string.IsNullOrWhiteSpace(monthString) && !string.IsNullOrWhiteSpace(yearString))
            {
                int year, month;
                if (int.TryParse(yearString, out year) && int.TryParse(monthString, out month))
                {
                    if (year <= DateTime.Today.Year && month > 0 && month <= 12)
                    {
                        _year = year;
                        _month = month;
                        DialogResult = true;
                    }
                }
            }
            else
            {
                MessageBox.Show("Wrong month/year");
            }

        }
    }
}
