using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp
{
    class DisplayingQuestion
    {
        public Question Question { get; }
        public int[] AnswerIndexs {
            get
            {
                return answerIndexs;
            }
        }

        private int[] answerIndexs = new int[] { 0, 1, 2, 3 };
 
        public DisplayingQuestion(Question question)
        {
            Question = question;
            RandomAnswerIndexs();
        }

        private void RandomAnswerIndexs()
        {
            Randomizer.Randomize(answerIndexs);
        }

        public bool CheckAnswer(int answer)
        {
            return Question.CheckAnswer(answerIndexs[answer]);
        }

        public override string ToString()
        {
            string result = "";
            result += Question.Title + "\n";
            for(int i = 0; i < answerIndexs.Length; i++)
            {
                result += String.Format("\t{0}. {1}\n", Constraints.answerTitles[i], Question.Answers[answerIndexs[i]]);
            }
            return result;
        }
    }
}
