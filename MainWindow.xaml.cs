using System.Windows;
using System.Windows.Input;

namespace Time_Calculator
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
        public void calculateBtn_Click(object sender, RoutedEventArgs e)
        {
            TimeCalculator();
        }
        private void OnPreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                calculateBtn_Click(sender, e);
                e.Handled = true; // Optional: prevent other controls from handling the event
                dayTxtBox2nd.Focus();
            }
            if (e.Key == Key.Delete)
            {
                resetBtn_Click(sender, e);
                e.Handled = true; // Optional: prevent other controls from handling the event
            }
        }
        public void TimeCalculator()
        {
            if (dayTxtBox.Text == "")
            {
                dayTxtBox.Text = "00";
            }
            if (hourTxtBox.Text == "")
            {
                hourTxtBox.Text = "00";
            }
            if (minTxtBox.Text == "")
            {
                minTxtBox.Text = "00";
            }
            if (secTxtBox.Text == "")
            {
                secTxtBox.Text = "00";
            }

            if (dayTxtBox2nd.Text == "")
            {
                dayTxtBox2nd.Text = "";
            }
            if (hourTxtBox2nd.Text == "")
            {
                hourTxtBox2nd.Text = "";
            }
            if (minTxtBox2nd.Text == "")
            {
                minTxtBox2nd.Text = "";
            }
            if (secTxtBox2nd.Text == "")
            {
                secTxtBox2nd.Text = "";
            }

            int days1st;
            int hours1st;
            int mins1st;
            int secs1st;
            int days2nd;
            int hours2nd;
            int mins2nd;
            int secs2nd;

            int days = 0;
            int hours = 0;
            int mins = 0;
            int secs = 0;

            if (int.TryParse(dayTxtBox.Text, out days1st) && int.TryParse(dayTxtBox2nd.Text, out days2nd))
            {
                days = days1st + days2nd;
            }
            if (int.TryParse(hourTxtBox.Text, out hours1st) && int.TryParse(hourTxtBox2nd.Text, out hours2nd))
            {
                hours = hours1st + hours2nd;
            }
            if (int.TryParse(minTxtBox.Text, out mins1st) && int.TryParse(minTxtBox2nd.Text, out mins2nd))
            {
                mins = mins1st + mins2nd;
            }
            if (int.TryParse(secTxtBox.Text, out secs1st) && int.TryParse(secTxtBox2nd.Text, out secs2nd))
            {
                secs = secs1st + secs2nd;
            }

            if (days == 0 && hours == 0 && mins == 0 && secs == 0) { }
            else
            {
                mins = mins + secs / 60;
                hours = hours + mins / 60;
                days = days + hours / 24;

                secs = secs % 60;
                mins = mins % 60;
                hours = hours % 24;

                dayTxtBox.Text = days.ToString("D2");
                hourTxtBox.Text = hours.ToString("D2");
                minTxtBox.Text = mins.ToString("D2");
                secTxtBox.Text = secs.ToString("D2");

                dayTxtBox2nd.Text = "";
                hourTxtBox2nd.Text = "";
                minTxtBox2nd.Text = "";
                secTxtBox2nd.Text = "";
            }
        }

        private void resetBtn_Click(object sender, RoutedEventArgs e)
        {
            dayTxtBox.Text = "";
            hourTxtBox.Text = "";
            minTxtBox.Text = "";
            secTxtBox.Text = "";
            dayTxtBox2nd.Text = "";
            hourTxtBox2nd.Text = "";
            minTxtBox2nd.Text = "";
            secTxtBox2nd.Text = "";
        }
    }
}
