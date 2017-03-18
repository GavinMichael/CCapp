using System.Windows;
using System.Windows.Media;

namespace CCApp
{
    /// <summary>
    /// Interaction logic for helpWindow.xaml
    /// </summary>
    public partial class helpWindow : Window
    {
        public helpWindow()
        {
            InitializeComponent();

        }

        private void helpWindowClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
