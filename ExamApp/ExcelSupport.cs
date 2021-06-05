using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;

namespace ExamApp
{
    class ExcelSupport
    {
        public List<string> ReadFile(string path)
        {
            Application xlApp;
            Workbook xlWorkBook;
            Worksheet xlWorkSheet;
            Range range;

            int rw = 0;
            int cl = 0;

            xlApp = new Application();
            xlWorkBook = xlApp.Workbooks.Open(path, 0, true, 5, "", "", true, XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            xlWorkSheet = (Worksheet)xlWorkBook.Worksheets.get_Item(1);

            range = xlWorkSheet.UsedRange;
            rw = range.Rows.Count;
            cl = range.Columns.Count;

            List<string> results = new List<string>();
            for (int rCnt = 1; rCnt <= rw; rCnt++)
            {
                string str = "";
                for (int cCnt = 1; cCnt <= cl; cCnt++)
                {
                    str += (string)(range.Cells[rCnt, cCnt] as Range).Value2 + "\t";
                }
                str = str.Remove(str.Length - 1, 1);
                results.Add(str);
            }
            return results;
        }
    }
}
