using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp
{
    class Exam
    {
        public int Count
        {
            get
            {
                return questions.Count;
            }
        }
        public Question GetQuestion(int index)
        {
            return questions[questionIndexs[index]];
        }

        private int[] questionIndexs;
        private List<Question> questions = new List<Question>();
        public Exam()
        {

        }

        public void InitQuestions()
        {
            ExcelSupport excelSupport = new ExcelSupport();
            List<string> results = excelSupport.ReadFile(Constraints.questionsPath);
            foreach (string item in results)
            {
                string[] parameters = item.Split('\t');
                if (parameters.Length == 5)
                {
                    Question question = new Question(parameters[0], parameters[1], parameters[2],
                        parameters[3], parameters[4]);
                    questions.Add(question);
                }
            }

            // random question indexs
            RandomQuestionIndexs(questions.Count);
        }

        public void RandomQuestionIndexs(int count)
        {
            questionIndexs = new int[count];
            for(int i = 0; i < count; i++)
            {
                questionIndexs[i] = i;
            }
            Randomizer.Randomize(questionIndexs);
        }
    }
}
