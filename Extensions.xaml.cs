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
using System.IO;

namespace CCApp
{
    /// <summary>
    /// Interaction logic for Extensions.xaml
    /// </summary>
    public partial class Extensions : Window
    {
        //on startup the txt file with the extention will be defined here
        string agentExtFile = @"_sourceFiles\agentExt.txt";

        //and the HR team ext file here
        string hrExtFile = @"_sourceFiles\HRExt.txt";

        public Extensions()
        {
            InitializeComponent();

            //Loads the text files into the textboxs
            LoadExtentions();
        }

        private void extCloseBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void LoadExtentions()
        {
            //For the Agents
            #region
            //Read the lines of the txt files
            //output them into the text box area

            //Reading the text from the txt file
            //and storing them in a list
            var agentExtList = File.ReadAllLines(agentExtFile).ToList();

            //loops through the list and outputs the text into the textbox
            foreach (string line in agentExtList)
            {
                teamExtensionsTxtBox.AppendText(line + "\n");
            }
            #endregion


            //For the HR team
            #region
            //Reading the text from the txt file
            //and storing them in a list
            var hrExtList = File.ReadAllLines(hrExtFile).ToList();

            //loops through the list and outputs the text into the textbox
            foreach (string line in hrExtList)
            {
                hrExtensionsTxtBox.AppendText(line + "\n");
            }
            #endregion
        }
    }
}
