﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CCApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        /* Shit that isnt done yet
         * 
         * Updates - Not Complete
         * Theme - Complete
        */


        //this counts the entries for Label:counter
        int numCounter = 0;


        //Entry point
        public MainWindow()
        {
            InitializeComponent();
            //ThemeHandler("retro");
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

        //Top Buttons
        #region

        //Break Button
        private void breakBtn_Click(object sender, RoutedEventArgs e)
        {
            Window1 breakWindow = new Window1();
            breakWindow.Show();
        }

        //Help Button
        private void helpBtn_Click(object sender, RoutedEventArgs e)
        {
            helpWindow hlpWindow = new helpWindow();
            hlpWindow.Show();
        }

        //Quit Button
        private void mainQuitBtn_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        //New Call
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
            string lineBreak = "----------------------------------------------------------- ";
            //Concatenate the line with current time and new line
            lineBreak = lineBreak + DateTime.Now.ToShortTimeString() + "\n";
            //Adds the string to the Main Text Box
            int selectionIndex = mainTxtBox.SelectionStart;
            mainTxtBox.Text = mainTxtBox.Text.Insert(selectionIndex, lineBreak);
            mainTxtBox.SelectionStart = selectionIndex + lineBreak.Length;

            #endregion
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

        //Price Inquiry
        private void shortcutsPriceInqBtn_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("https://goo.gl/forms/5laEXcIuAUk0IMo72");
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

        //AUH Muni New Customer
        private void auhMuniBtn_Click(object sender, RoutedEventArgs e)
        {
            string filePath = @"_sourceFiles\AUHMuni.txt";
            TextHanlder(filePath);
        }

        //Irtawi Card Complaint
        private void irtawiComplaintBtn_Click(object sender, RoutedEventArgs e)
        {
            string filePath = @"_sourceFiles\irtawiCardComplaint.txt";
            TextHanlder(filePath);
        }

        //SMS Notification Issue
        private void smsIssueBtn_Click(object sender, RoutedEventArgs e)
        {
            string filePath = @"_sourceFiles\smsNotificationsIssue.txt";
            TextHanlder(filePath);
        }
        #endregion

        //Theme functionality here

        private void ThemeHandler(object sender, RoutedEventArgs e)
        {
            //this captures the tag of the button clicked to evaluate later
            var entry = ((Button)sender).Tag;

            #region Theme Definitions
            //white & black 
            var white = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFF"));
            var black = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#000000"));

            #region Theme One
            var themeOneText = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFAFA"));
            var themeOneMainColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#0098eb"));
            var themeOneSubColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#0F59EB"));
            var themeOneNewCallColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#E62900"));
            var themeOneBorder = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#0FAEEB"));
            #endregion End of Theme One

            #region Theme Two
            var themeTwoText = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFAFA"));
            var themeTwoMainColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#EE47D5"));
            var themeTwoSubColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#EB00C8"));
            var themeTwoNewCallColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#6B005B"));
            var themeTwoBorder = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#EE81D5"));
            #endregion End of Theme Two

            #region Theme Three
            var themeThreeText = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFAFA"));
            var themeThreeMainColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#EB5307"));
            var themeThreeSubColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#B84105"));
            var themeThreeNewCallColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#B83F00"));
            var themeThreeBorder = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#EE9D74"));
            #endregion End of Theme Three

            #region Theme Four
            var themeFourText = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFAFA"));
            var themeFourMainColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#186B00"));
            var themeFourSubColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#2AB800"));
            var themeFourNewCallColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#2AB800"));
            var themeFourBorder = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#35EB00"));
            #endregion End of Theme Four

            #region Theme Default
            var themeDefaultText = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#000000"));
            var themeDefaultMainColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ffffff"));
            var themeDefaultSubColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#7f7f7f"));
            var themeDefaultNewCallColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#7f7f7f"));
            var themeDefaultBorder = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#b2b2b2"));
            #endregion End of Theme Four

            #region Theme Gavin
            var themeGavinText = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ffffff"));
            var themeGavinMainColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#000000"));
            var themeGavinSubColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#323232"));
            var themeGavinNewCallColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#323232"));
            var themeGavinBorder = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#262626"));
            #endregion End of Theme Gavin

            #endregion End of Theme Definitions

            switch (entry.ToString())
            {
                case "One":
                    ThemeChanger(themeOneMainColor, themeOneSubColor, themeOneText, themeOneBorder, themeOneNewCallColor, white, black);
                    break;
                case "Two":
                    ThemeChanger(themeTwoMainColor, themeTwoSubColor, themeTwoText, themeTwoBorder, themeTwoNewCallColor, white, black);
                    break;
                case "Three":
                    ThemeChanger(themeThreeMainColor, themeThreeSubColor, themeThreeText, themeThreeBorder, themeThreeNewCallColor, white, black);
                    break;
                case "Four":
                    ThemeChanger(themeFourMainColor, themeFourSubColor, themeFourText, themeFourBorder, themeFourNewCallColor, white, black);
                    break;
                case "Default":
                    ThemeChanger(themeDefaultMainColor, themeDefaultSubColor, themeDefaultText, themeDefaultBorder, themeDefaultNewCallColor, white, black);
                    break;
                case "Gavin":
                    ThemeChanger(themeGavinMainColor, themeGavinSubColor, themeGavinText, themeGavinBorder, themeGavinNewCallColor, white, black);
                    break;
                default:
                    break;

            }
        }

        //this method takes in the colors and changes the control property based on the parameter passed in
        private void ThemeChanger(SolidColorBrush mainColor, SolidColorBrush subColor, SolidColorBrush text, SolidColorBrush border, SolidColorBrush newCallColor, SolidColorBrush white,
            SolidColorBrush black)
        {

            #region Button List Definition
            //List of all the buttons
            List<Button> templateButtons = new List<Button> { auhMuniBtn, cancellationBtn, changeDetailsBtn, delIssueBtn, dispComplaintBtn,
                exportBtn, irtawiComplaintBtn, labellingBtn, petOrderBtn, smsIssueBtn, sponsorshipBtn, updateJPBtn };

            //List of ShortCut Buttons
            List<Button> shortcutButton = new List<Button> { shortcutsAbdKbBtn, shortcutsCbdKbBtn, shortcutsCrmBtn, shortcutsPlannedLeavesBtn, shortcutsPowerBiBtn,
                shortcutsPriceInqBtn, shortcutsRmtMailBtn };

            //List of Menu Buttons
            List<Button> menuButtons = new List<Button> { extentionsBtn, breakBtn, helpBtn, quitBtn };
            #endregion

            //set the value for Main Window
            Background = mainColor;

            //Menu Stackpanel
            menuStackPanel.Background = subColor;
            //Menu Buttons
            foreach (var button in menuButtons)
            {
                button.Background = subColor;
                button.BorderBrush = subColor; // border will always be the background color
                button.Foreground = text;
            }

            //New Call Button
            newCallBtn.Background = newCallColor;
            newCallBtn.Foreground = white;
            newCallBtn.BorderBrush = newCallColor;

            //Counter Label
            counter.Foreground = white;

            //Template Stackpanel
            templateBtnStackPanel.Background = mainColor;
            //Template Buttons
            foreach (var button in templateButtons)
            {
                button.Background = mainColor;
                button.BorderBrush = border;
                button.Foreground = text;
            }

            //Main Text Box
            mainTxtBox.Background = mainColor;
            mainTxtBox.BorderBrush = white;
            mainTxtBox.Foreground = text;

            //Shortcuts stackpanel
            shortcutStackPanel.Background = subColor;

            //Shortcut Buttons
            foreach (var button in shortcutButton)
            {
                button.Background = subColor;
                button.BorderBrush = subColor; // border will always be the background color
                button.Foreground = text;
            }
        }
    }

}
