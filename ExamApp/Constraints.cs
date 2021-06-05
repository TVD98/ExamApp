using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp
{
    class Constraints
    {
        public static readonly string[] answerTitles = new string[] { "A", "B", "C", "D" };
        public static readonly Dictionary<String, int> answerDictionary = new Dictionary<String, int>
        {
            {"A", 0 }, {"B", 1 }, {"C", 2 }, {"D", 3 }, {"a", 0 }, {"b", 1 }, {"c", 2 }, {"d", 3 }
        };
        public static readonly string questionsPath = @"C:\Users\GMT\source\repos\ExamApp\ExamApp\questions.xlsx";
    }
}
