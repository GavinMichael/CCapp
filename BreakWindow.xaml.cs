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

namespace CCApp
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void breakRefreshBtn_Click(object sender, RoutedEventArgs e)
        {
            //implement the rest of the agent's break labels to change when the button is pressed
            anasBreakTxtBox.Content = "Updated";
        }

        private void breakWindowCloseBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
