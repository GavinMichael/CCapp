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
    /// This window has not been completed
    /// </summary>
    public partial class Window1 : Window
    {
        //this list holds all the lables in this window so that we can loop through each label and update it when the refresh button is pressed.
        public List<Label> allLabels = new List<Label>();

        public Window1()
        {
            InitializeComponent();

            //here we add all the labels into the List
            allLabels.Add(anasBreakTxtBox);
            allLabels.Add(abdallahBreakTxtBox);
            allLabels.Add(gasiraBreakTxtBox);
            allLabels.Add(katBreakTxtBox);
            allLabels.Add(hafeezBreakTxtBox);
            allLabels.Add(heidiBreakTxtBox);
            allLabels.Add(saraBreakTxtBox);
            allLabels.Add(yaminiBreakTxtBox);
            allLabels.Add(remilieBreakTxtBox);
            allLabels.Add(markBreakTxtBox);
            allLabels.Add(mahmoudBreakTxtBox);
            allLabels.Add(rainnaBreakTxtBox);
            allLabels.Add(alaaBreakTxtBox);

        }


        private void breakRefreshBtn_Click(object sender, RoutedEventArgs e)
        {
            //changes the text for all labels to the received value
            foreach (var _label in allLabels)
            {
                _label.Content = "Updated";
            }
        }

        //Close Button
        private void breakWindowCloseBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
