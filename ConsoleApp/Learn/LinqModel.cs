using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ConsoleApp.Learn
{
    class LinqModel
    {
        public static void display()
        {
            int[] scores = new int[] { 97, 91, 90, 95 };
            // 检索子元素
            IEnumerable<int> scoreQuery =
                   from score in scores
                   where score > 91
                   select score;

            foreach (var ele in scoreQuery)
            {
                Console.Write(ele + " ");
            }
        }
    }
}
