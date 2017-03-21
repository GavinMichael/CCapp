using System.Windows;

namespace CCApp
{
    /// <summary>
    /// Interaction logic for helpWindow.xaml
    /// </summary>
    public partial class helpWindow : Window
    {
        /// <summary>
        /// Text on this window is defined in the text box itself
        /// </summary>
        public helpWindow()
        {
            InitializeComponent();

        }

        //Close Button
        private void helpWindowClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
