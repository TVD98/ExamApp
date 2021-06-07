using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace ExamApp
{
    class Program
    {
        // parameters
        private static int scores = 0;
        private static Question question;
        private static UIClient uIClient;
        static void Main(string[] args)
        {

            // UI for client
            uIClient = new UIClient();

            Exam exam = new Exam();
            exam.InitQuestions();

            // countdown
            Countdown countdown = new Countdown(5);
            countdown.Show();
            countdown.CountdownFinished += ExamFinished;

            // correct answers count
            for (int i = 0; i < exam.Count; i++)
            {
                // display question
                question = exam.GetQuestion(i);
                DisplayingQuestion displayingQuestion = new DisplayingQuestion(question);
                uIClient.DisplayQuestion(displayingQuestion, i + 1);

                // start count down
                countdown.Start();

                int answer = uIClient.EnteringAnswer();

                // check answer
                if (displayingQuestion.CheckAnswer(answer))
                    scores++;
                // it's a wrong answer -> exit game
                else break;

            }

            if (scores == exam.Count)
            {
                ShowExamResult(true);
                return;
            }
            ShowExamResult(false);
        }

        private static void ShowExamResult(bool correctAnswer)
        {
            if (!correctAnswer)
            {
                uIClient.WriteLine(String.Format("Dap an dung la: {0}", question.CorrectAnswer));
            }
            // show scores
            uIClient.WriteLine(String.Format("Ban tra loi dung {0} cau", scores));
        }

        private static void ExamFinished()
        {
            // Timeout => exit console
            ShowExamResult(false);
            Environment.Exit(0);
        }
    }
}
