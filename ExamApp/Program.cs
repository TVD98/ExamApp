using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // UI for client
            UIClient uIClient = new UIClient();

            Exam exam = new Exam();
            exam.InitQuestions();

            // correct answers count
            int scores = 0;
            for (int i = 0; i < exam.Count; i++)
            {
                Question question = exam.GetQuestion(i);
                DisplayingQuestion displayingQuestion = new DisplayingQuestion(question);
                uIClient.DisplayQuestion(displayingQuestion, i + 1);
                int answer = uIClient.EnteringAnswer();

                // check answer
                if (displayingQuestion.CheckAnswer(answer))
                    scores++;
                // it's a wrong answer -> exit game
                else
                {
                    Console.WriteLine(String.Format("Dap an dung la: {0}", question.CorrectAnswer));
                    break;
                };
            }

            // show scores
            Console.WriteLine(String.Format("Ban tra loi dung {0} cau", scores));
        }
    }
}
