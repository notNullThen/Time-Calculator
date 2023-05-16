using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Time_Calc_TXT
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // Add a handler for PreviewKeyDown event
            this.AddHandler(Keyboard.PreviewKeyDownEvent, new KeyEventHandler(OnPreviewKeyDown));
        }
        private void OnPreviewKeyDown(object sender, KeyEventArgs e)
        {
            string time1stTxt = time1stTxtBox.Text;
            string time1stNums = "";

            string time2ndTxt = time2ndTxtBox.Text;
            string time2ndNums = "";

            for (int i = 0; i < time1stTxt.Length; i++)
            {
                if (time1stTxt[i] != ':')
                {
                    time1stNums += time1stTxt[i];
                }
            }
            for (int i = 0; i < time2ndTxt.Length; i++)
            {
                if (time2ndTxt[i] != ':')
                {
                    time2ndNums += time2ndTxt[i];
                }
            }

            if (e.Key == Key.Enter)
            {
                calculateBtn_Click(sender, e);
                e.Handled = true; // Optional: prevent other controls from handling the event
            }
            if (e.Key == Key.Delete)
            {
                resetBtn_Click(sender, e);
                e.Handled = true; // Optional: prevent other controls from handling the event
            }

            // Backspace button
            if (e.Key == Key.Back && time2ndTxtBox.Text.Length > 0)
            {
                time2ndTxtBox.Text = time2ndTxtBox.Text.Remove(time2ndTxtBox.Text.Length - 1);
                e.Handled = true;
            }
            else if (e.Key == Key.Back && time1stTxtBox.Text.Length > 0 && time1stNums.Length < 9)
            {
                time1stTxtBox.Text = time1stTxtBox.Text.Remove(time1stTxtBox.Text.Length - 1);
                e.Handled = true;
            }

            if (time1stNums.Length < 8)
            {
                if (time1stNums.Length % 2 == 0 && e.Key != Key.Back && time1stNums.Length > 0)
                {
                    time1stTxtBox.Text += ":";
                }

                if (e.Key == Key.Enter)
                {
                    calculateBtn_Click(sender, e);
                    e.Handled = true; // Optional: prevent other controls from handling the event
                }
                if (e.Key == Key.Delete)
                {
                    resetBtn_Click(sender, e);
                    e.Handled = true; // Optional: prevent other controls from handling the event
                }

                if (e.Key == Key.NumPad0 || e.Key == Key.D0)
                {
                    time1stTxtBox.Text += "0";
                    e.Handled = true;
                }
                else if (e.Key == Key.NumPad1 || e.Key == Key.D1)
                {
                    time1stTxtBox.Text += "1";
                    e.Handled = true;
                }
                else if (e.Key == Key.NumPad2 || e.Key == Key.D2)
                {
                    time1stTxtBox.Text += "2";
                    e.Handled = true;
                }
                else if (e.Key == Key.NumPad3 || e.Key == Key.D3)
                {
                    time1stTxtBox.Text += "3";
                    e.Handled = true;
                }
                else if (e.Key == Key.NumPad4 || e.Key == Key.D4)
                {
                    time1stTxtBox.Text += "4";
                    e.Handled = true;
                }
                else if (e.Key == Key.NumPad5 || e.Key == Key.D5)
                {
                    time1stTxtBox.Text += "5";
                    e.Handled = true;
                }
                else if (e.Key == Key.NumPad6 || e.Key == Key.D6)
                {
                    time1stTxtBox.Text += "6";
                    e.Handled = true;
                }
                else if (e.Key == Key.NumPad7 || e.Key == Key.D7)
                {
                    time1stTxtBox.Text += "7";
                    e.Handled = true;
                }
                else if (e.Key == Key.NumPad8 || e.Key == Key.D8)
                {
                    time1stTxtBox.Text += "8";
                    e.Handled = true;
                }
                else if (e.Key == Key.NumPad9 || e.Key == Key.D9)
                {
                    time1stTxtBox.Text += "9";
                    e.Handled = true;
                }
            }
            else if (time1stNums.Length >= 7 && time2ndNums.Length < 8)
            {
                if (time2ndNums.Length % 2 == 0 && time2ndNums.Length > 0)
                {
                    time2ndTxtBox.Text += ":";
                }

                if (e.Key == Key.NumPad0 || e.Key == Key.D0)
                {
                    time2ndTxtBox.Text += "0";
                    e.Handled = true;
                }
                else if (e.Key == Key.NumPad1 || e.Key == Key.D1)
                {
                    time2ndTxtBox.Text += "1";
                    e.Handled = true;
                }
                else if (e.Key == Key.NumPad2 || e.Key == Key.D2)
                {
                    time2ndTxtBox.Text += "2";
                    e.Handled = true;
                }
                else if (e.Key == Key.NumPad3 || e.Key == Key.D3)
                {
                    time2ndTxtBox.Text += "3";
                    e.Handled = true;
                }
                else if (e.Key == Key.NumPad4 || e.Key == Key.D4)
                {
                    time2ndTxtBox.Text += "4";
                    e.Handled = true;
                }
                else if (e.Key == Key.NumPad5 || e.Key == Key.D5)
                {
                    time2ndTxtBox.Text += "5";
                    e.Handled = true;
                }
                else if (e.Key == Key.NumPad6 || e.Key == Key.D6)
                {
                    time2ndTxtBox.Text += "6";
                    e.Handled = true;
                }
                else if (e.Key == Key.NumPad7 || e.Key == Key.D7)
                {
                    time2ndTxtBox.Text += "7";
                    e.Handled = true;
                }
                else if (e.Key == Key.NumPad8 || e.Key == Key.D8)
                {
                    time2ndTxtBox.Text += "8";
                    e.Handled = true;
                }
                else if (e.Key == Key.NumPad9 || e.Key == Key.D9)
                {
                    time2ndTxtBox.Text += "9";
                    e.Handled = true;
                }
            }
        }
        public void CalculateTime()
        {
            string time1st = time1stTxtBox.Text;
            string time2nd = time2ndTxtBox.Text;

            string[] time1stParsed = time1st.Split(':');
            string[] time2ndParsed = time2nd.Split(':');

            long[] time1stIntArray = new long[time1stParsed.Length];

            for (long i = 0; i < time1stParsed.Length; i++)
            {
                if (long.TryParse(time1stParsed[i], out long num))
                {
                    time1stIntArray[i] = num;
                }
            }

            long[] time2ndIntArray = new long[time2ndParsed.Length];

            for (long i = 0; i < time2ndParsed.Length; i++)
            {
                if (long.TryParse(time2ndParsed[i], out long num))
                {
                    time2ndIntArray[i] = num;
                }
            }

            long days1st = 0;
            long hours1st = 0;
            long mins1st = 0;
            long secs1st = 0;
            long days2nd = 0;
            long hours2nd = 0;
            long mins2nd = 0;
            long secs2nd = 0;

            if (time1stIntArray.Length > 0)
            {
                days1st = time1stIntArray[0];
            }
            if (time1stIntArray.Length > 1)
            {
                hours1st = time1stIntArray[1];
            }
            if (time1stIntArray.Length > 2)
            {
                mins1st = time1stIntArray[2];
            }
            if (time1stIntArray.Length > 3)
            {
                secs1st = time1stIntArray[3];
            }

            if (time2ndIntArray.Length > 0)
            {
                days2nd = time2ndIntArray[0];
            }
            if (time2ndIntArray.Length > 1)
            {
                hours2nd = time2ndIntArray[1];
            }
            if (time2ndIntArray.Length > 2)
            {
                mins2nd = time2ndIntArray[2];
            }
            if (time2ndIntArray.Length > 3)
            {
                secs2nd = time2ndIntArray[3];
            }

            long days = days1st + days2nd;
            long hours = hours1st + hours2nd;
            long mins = mins1st + mins2nd;
            long secs = secs1st + secs2nd;

            mins = mins + secs / 60;
            hours = hours + mins / 60;
            days = days + hours / 24;

            secs = secs % 60;
            mins = mins % 60;
            hours = hours % 24;

            string daysStr = days.ToString("D2");
            string hoursStr = hours.ToString("D2");
            string minsStr = mins.ToString("D2");
            string secsStr = secs.ToString("D2");

            string[] timeResArray = new string[4];
            timeResArray[0] = daysStr;
            timeResArray[1] = hoursStr;
            timeResArray[2] = minsStr;
            timeResArray[3] = secsStr;

            time1stTxtBox.Text = string.Join(":", timeResArray);
            time2ndTxtBox.Text = "";
        }
        private void ParseNumber(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[0-9:]");
            e.Handled = !regex.IsMatch(e.Text);
        }
        public void calculateBtn_Click(object sender, RoutedEventArgs e)
        {
            CalculateTime();
        }
        private void resetBtn_Click(object sender, RoutedEventArgs e)
        {
            time1stTxtBox.Text = "";
            time2ndTxtBox.Text = "";
        }
    }
}
