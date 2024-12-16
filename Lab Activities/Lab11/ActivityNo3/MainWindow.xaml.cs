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

namespace LabNo10_ActivityNo3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Combo1_SelectChange(object sender, SelectionChangedEventArgs e)
        {
            if (comboBox1.SelectedItem is ComboBoxItem selectedItem)
            {
                textBox1.Text = selectedItem.Content.ToString();
            }
            else
            {
                textBox1.Text = string.Empty; 
            }
        }
        private void Combo2_SelectChange(object sender, SelectionChangedEventArgs e)
        {
            if (comboBox2.SelectedItem is ComboBoxItem selectedItem)
            {
                textBox2.Text = selectedItem.Content.ToString();
            }
            else
            {
                textBox2.Text = string.Empty; 
            }
        }
    }
}
