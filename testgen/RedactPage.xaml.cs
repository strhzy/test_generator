using System.Windows;
using System.Windows.Controls;

namespace testgen
{
    public partial class RedactPage : Page
    {
        List<Question> questions = new List<Question>();
        public RedactPage()
        {
            InitializeComponent();
            questions = Json.Deserialize<List<Question>>() ?? new List<Question>();
            questGrid.ItemsSource = questions;
        }
        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            questGrid.ItemsSource = null;
            Question question = new Question(" "," "," "," "," ",Question.right_answer.Первый);
            questions.Add(question);
            questGrid.ItemsSource = questions;
            Json.Serialize(questions);
        }

        private void questGrid_CellEdit(object sender, DataGridCellEditEndingEventArgs e)
        {
            Json.Serialize(questions);
        }

        private void questGrid_CellEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            Json.Serialize(questions);
        }
    }
}
