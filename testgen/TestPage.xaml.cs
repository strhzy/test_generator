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
        internal enum Buttons
        {
            first_answer,
            second_answer,
            third_answer
        }
        List<Question> questions = new List<Question>();
        public TestPage()
        {
            questions = Json.Deserialize<List<Question>>();
            
            InitializeComponent();
            insert_data();
        }
        private int check = 0;
        private int score = 0;
        int[] answers = new int[100];

        private void button_press(object sender, RoutedEventArgs e)
        {
            foreach (Question question in questions)
            {
                if(check < questions.Count)
                {
                    Name1.Text = question.Name;
                    Description.Text = check.ToString();
                    first_answer.Content = question.first_answer;
                    second_answer.Content = question.second_answer;
                    third_answer.Content = question.third_answer;
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
                }
                else
                {
                    result();
                }
            }
        }
        private void insert_data()
        {
            Name1.Text = questions[check].Name;
            Description.Text = check.ToString();
            first_answer.Content = questions[check].first_answer;
            second_answer.Content = questions[check].second_answer;
            third_answer.Content = questions[check].third_answer;
        }
        private void result()
        {
            for(int i = 0; i < questions.Count; i++)
            {
                if ((int)questions[i].right_Answer == answers[i])
                {
                    score++;
                }
            }
            string result = ($"Результат {score} из {questions.Count}");
            Name1.Text = "";
            Description.Text = result;
            first_answer.Visibility = Visibility.Hidden;
            second_answer.Visibility = Visibility.Hidden;
            third_answer.Visibility = Visibility.Hidden;
        }
    }
}
