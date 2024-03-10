using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testgen
{
    internal class Question
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string first_answer { get; set; }
        public string second_answer { get; set; }
        public string third_answer { get; set; }
        public right_answer right_Answer { get; set; }
        public enum right_answer
        {
            Первый,
            Второй,
            Третий
        }
        public Question(string name, string description, string first_answer, string second_answer, string third_answer, right_answer right_Answer)
        {
            Name = name;
            Description = description;
            this.first_answer = first_answer;
            this.second_answer = second_answer;
            this.third_answer = third_answer;
            this.right_Answer = right_Answer;
        }
    }
}
