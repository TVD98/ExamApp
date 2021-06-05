using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp
{
    class Question
    {
        public string Title { get; }
        public List<string> Answers { get; }

        public Question(string title, string correctAnswer, string otherAnswer1,
            string otherAnswer2, string otherAnswer3)
        {
            Title = title;
            Answers = new List<string>(new string[] { correctAnswer, otherAnswer1, otherAnswer2, otherAnswer3 });
        }

        public string CorrectAnswer
        {
            get
            {
                return Answers[0];
            }
        }

        public bool CheckAnswer(int answer)
        {
            if (answer == 0)
            {
                return true;
            }
            return false;
        }
    }
}
