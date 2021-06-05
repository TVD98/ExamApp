using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp
{
    class UIClient
    {
        public void DisplayQuestion(DisplayingQuestion displayingQuestion, int index)
        {
            Console.WriteLine(String.Format("Cau hoi {0}: {1}", index, displayingQuestion.ToString()));
        }

        public string EnteringString(String title)
        {
            Console.Write(String.Format("{0}: ", title));
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
    }
}
