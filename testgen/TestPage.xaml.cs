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

namespace testgen
{
    /// <summary>
    /// Логика взаимодействия для TestPage.xaml
    /// </summary>
    public partial class TestPage : Page
    {
        List<Question> questions = new List<Question>();
        public TestPage()
        {
            questions = Json.Deserialize<List<Question>>();
            check = 0;
            InitializeComponent();
            insert_data();
        }
        private int check = 0;
        private int score = 0;
        int[] answers = new int[100];

        private void button_press(object sender, RoutedEventArgs e)
        {
            if (sender == first_answer)
            {
                answers[check] = 0;
            }
            else if (sender == second_answer)
            {
                answers[check] = 1;
            }
            else if (sender == third_answer)
            {
                answers[check] = 2;
            }
            check++;
            if(check < questions.Count)
            {
                insert_data();
            }
            else
            {
            result();
            }
        }
        private void insert_data()
        {
            Name1.Text = questions[check].Name;
            Description.Text = questions[check].Description;
            first_answer.Content = questions[check].first_answer;
            second_answer.Content = questions[check].second_answer;
            third_answer.Content = questions[check].third_answer;
        }
        private void result()
        {
            check = 0;
            for(int i = 0; i < questions.Count; i++)
            {
                if ((int)questions[i].right_Answer == answers[i])
                {
                    score++;
                }
            }
            string result = ($"Результат {score} из {questions.Count}");
            Name1.Text = result;
            Description.Text = "";
            first_answer.Visibility = Visibility.Hidden;
            second_answer.Visibility = Visibility.Hidden;
            third_answer.Visibility = Visibility.Hidden;
        }
    }
}
