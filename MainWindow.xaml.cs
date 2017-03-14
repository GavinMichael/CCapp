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
using System.IO;
using System.Net;
using System.Diagnostics;

namespace CCApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        /* Shit that isnt done yet
         * 
         * Updates not implemented
        */


        //this counts the entries for Label:counter
        int numCounter = 0;
        public MainWindow()
        {
            InitializeComponent();
        }
        
        //this takes the filepath as input pram and outputs the text into the main textbox
        public void TextHanlder(string _filePath)
        {
            //reads all the lines into a list
            List<string> content = File.ReadAllLines(_filePath).ToList();
            //loops through the list reading each line
            foreach (string line in content)
            {
                //adds the line read from the txt file
                mainTxtBox.AppendText(line);
                //adds  a new line to the text box
                mainTxtBox.AppendText("\n");
            }
        }

        /* this space is for updates when it will be implemented
        private void updatesBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WebClient web = new WebClient();
                System.IO.Stream stream = web.OpenRead("http://pastebin.com/raw/RXpKzYB4");
                using (System.IO.StreamReader reader = new System.IO.StreamReader(stream))
                {
                    string text = reader.ReadToEnd();
                    updateTxtBox.AppendText(text);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        */

        //Top Menu Breaks Button click event - Implemented
        #region
        private void breakBtn_Click(object sender, RoutedEventArgs e)
        {
            Window1 breakWindow = new Window1();
            breakWindow.Show();
        }

        //Top Menu Quit Button click event - Implemented
        private void mainQuitBtn_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        //Top Menu New Call Button click event - Implemented
        private void newCallBtn_Click(object sender, RoutedEventArgs e)
        {
            //This method does 3 things

            //Increments the counter
            #region

            numCounter++;
            counter.Content = $"Entries - {numCounter}";
            #endregion

            //Outputs text file
            #region

            //Takes all the text from the main text box and adds them to a list
            List<string> saveFile = new List<string>();
            saveFile.Add(mainTxtBox.Text);

            //string for the save file 
            string fileName = "SaveFile.txt";

            //writes all lines to the save file
            try
            {
                File.WriteAllLines(fileName, saveFile);
            }
            catch (Exception err)
            {

                MessageBox.Show(err.Message);
            }
            #endregion

            //Adds a new line with time
            #region

            //holds the line break
            string lineBreak = "----------------------------------";
            //Concatenate the line with current time and new line
            lineBreak = lineBreak + DateTime.Now.ToShortTimeString() + "\n";
            //Adds the string to the Main Text Box
            mainTxtBox.AppendText(lineBreak);

            #endregion
        }

        //Top Menu Shortcuts Button click event - Implemented
        private void shortcutsBtn_Click(object sender, RoutedEventArgs e)
        {
            Shortcuts shortCutWindow = new Shortcuts();
            shortCutWindow.Show();
        }

        //Top Menu Extensions Button click event - Implemented
        private void extentionsBtn_Click(object sender, RoutedEventArgs e)
        {
            //opens the extensions window
            Extensions extWindow = new Extensions();
            extWindow.Show();
        }
        #endregion

        //This where all the shortcut buttons live - Implemented
        #region

        //CRM
        private void shortcutsCrmBtn_Click(object sender, RoutedEventArgs e)
        {
                Process.Start("https://agthiagroup.crm4.dynamics.com/");
        }

        //CBD KB
        private void shortcutsCbdKbBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Process.Start("file://cs007/Operations/Shared%20Pool/CTS%20ANS%20Service/Filex%20-%20Answering%20Service/_Gavin%20Michael/_Knowledge%20Base%20Folder/Agthia%20KB%202.3%20-%20January%202017/index.html");
            }
            catch (Exception err)
            {
                MessageBox.Show("Unable to find the file");
            }
        }

        //ABD KB
        private void shortcutsAbdKbBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Process.Start("file://cs007/Operations/Shared%20Pool/CTS%20ANS%20Service/Filex%20-%20Answering%20Service/_Gavin%20Michael/ABD%20Knowledge%20Base/index.html");
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to find the file");
            }
        }
        //Power BI
        private void shortcutsPowerBiBtn_Click(object sender, RoutedEventArgs e)
        {
                Process.Start("https://app.powerbi.com/groups/64d2e7e0-34ae-44da-a09f-4b4d61c7acb6/reports/dcf81a5b-8061-4b92-b5b2-faebdf856045/ReportSection");
        }

        //Remotemail
        private void shortcutsRmtMailBtn_Click(object sender, RoutedEventArgs e)
        {
                Process.Start("https://remotemail.agthia.com/owa");
        }

        //Planned Leave
        private void shortcutsPlannedLeavesBtn_Click(object sender, RoutedEventArgs e)
        {
                Process.Start("https://docs.google.com/spreadsheets/d/1LMt-GJw2ISLF-glQlbL-fZweqG6axwX5MkrWm0eUhuM/edit#gid=557340792");
        }
        #endregion

        //Here are the template button click events
        #region

        //Delivery Issue Btn
        private void delIssueBtn_Click(object sender, RoutedEventArgs e)
        {
            string filePath = @"_sourceFiles\delivery.txt";
            TextHanlder(filePath);
        }

        //Change Details Btn
        private void changeDetailsBtn_Click(object sender, RoutedEventArgs e)
        {
            string filePath = @"_sourceFiles\changeDet.txt";
            TextHanlder(filePath);
        }

        //Cancellation Btn
        private void cancellationBtn_Click(object sender, RoutedEventArgs e)
        {
            string filePath = @"_sourceFiles\cancellation.txt";
            TextHanlder(filePath);
        }

        //Labelling Btn
        private void labellingBtn_Click(object sender, RoutedEventArgs e)
        {
            string filePath = @"_sourceFiles\labelling.txt";
            TextHanlder(filePath);
        }

        //Dispenser Complaints Btn
        private void dispComplaintBtn_Click(object sender, RoutedEventArgs e)
        {
            string filePath = @"_sourceFiles\dispcomplaint.txt";
            TextHanlder(filePath);
        }

        //Sponsorship Btn
        private void sponsorshipBtn_Click(object sender, RoutedEventArgs e)
        {
            string filePath = @"_sourceFiles\sponsorship.txt";
            TextHanlder(filePath);
        }

        //Export Btn
        private void exportBtn_Click(object sender, RoutedEventArgs e)
        {
            string filePath = @"_sourceFiles\export.txt";
            TextHanlder(filePath);
        }

        //PET Order Btn
        private void petOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            string filePath = @"_sourceFiles\petOrder.txt";
            TextHanlder(filePath);
        }

        //Update JP Btn
        private void updateJPBtn_Click(object sender, RoutedEventArgs e)
        {
            string filePath = @"_sourceFiles\updateJP.txt";
            TextHanlder(filePath);
        }
        #endregion
    }
}
