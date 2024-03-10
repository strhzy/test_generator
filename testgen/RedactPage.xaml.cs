using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.DirectoryServices.ActiveDirectory;
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
    public partial class RedactPage : Page
    {
        ObservableCollection<Question> questions = new ObservableCollection<Question>();
        public RedactPage()
        {
            InitializeComponent();
            questions = Json.Deserialize<ObservableCollection<Question>>();
            questGrid.ItemsSource = questions;
        }
        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            questGrid.ItemsSource = null;
            Question quest = new Question("","","","","",Question.right_answer.Первый);
            questions.Add(quest);
            questGrid.ItemsSource = questions;
            Json.Serialize(questions);
        }

        private void questGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            Json.Serialize(questions);
        }
    }
}
