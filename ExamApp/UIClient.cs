using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp
{
    class UIClient
    {
        private readonly int startCursorTop = 4;
        private readonly int defaultCursorLeft = 0;

        public void DisplayQuestion(DisplayingQuestion displayingQuestion, int index)
        {
            ClearDisplayingQuestion();
            WriteLine(String.Format("Cau hoi {0}: {1}", index, displayingQuestion.ToString()), false,
                defaultCursorLeft, startCursorTop);
        }

        private void ClearDisplayingQuestion()
        {
            String space = "                                                                                                                               \n" +
                "                                                                                                                                          \n" +
                "                                                                                                                                          \n" +
                "                                                                                                                                          \n" +
                "                                                                                                                                          \n" +
                "                                                                                                                                          \n";
            WriteLine(space, false, defaultCursorLeft, startCursorTop);
        }

        public string EnteringString(String title)
        {
            Write(String.Format("{0}:  ", title), false);
            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
            return Console.ReadLine();
        }

        public int EnteringAnswer()
        {
            string result;
            do
            {
                result = EnteringString("Nhap dap an");
            } while (!Constraints.answerDictionary.ContainsKey(result));
            return Constraints.answerDictionary[result];
        }
        
        public void WriteLine(String text, bool restore = false, int x = 0, int y = -1)
        {
            int currentCursorLeft = Console.CursorLeft;
            int currentCursorTop = Console.CursorTop;

            if (y == -1)
                y = Console.CursorTop;
            Console.SetCursorPosition(x, y);
            Console.WriteLine(text);

            if (restore)
            {
                Console.SetCursorPosition(currentCursorLeft, currentCursorTop);
            }
        }

        public void Write(String text, bool restore = false, int x = 0, int y = -1)
        {
            int currentCursorLeft = Console.CursorLeft;
            int currentCursorTop = Console.CursorTop;

            if (y == -1)
                y = Console.CursorTop;
            Console.SetCursorPosition(x, y);
            Console.Write(text);

            // restore cursor
            if (restore)
            {
                Console.SetCursorPosition(currentCursorLeft, currentCursorTop);
            }
        }
    }
}
