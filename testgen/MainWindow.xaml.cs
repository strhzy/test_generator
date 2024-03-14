using System.Windows;

namespace testgen
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }
        SecondWindow secwin = new SecondWindow();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (password.Text == "пароль")
            {
                secwin.redact.IsEnabled = true;
                secwin.Show();
                Close();
            }
            else
            {
                adminbox.Text = "Неправильный пароль";
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            List<Question> res = Json.Deserialize<List<Question>>();
            if (res.Count != 0)
            {
                secwin.PageFrame.Content = new TestPage();
                secwin.redact.IsEnabled = false;
                secwin.Show();
                Close();
            }
            else
            {
                secwin.PageFrame.Content = new EmptyPage();
                secwin.redact.IsEnabled = false;
                secwin.Show();
                Close();
            }
        }
    }
}