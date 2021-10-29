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
            Console.WriteLine("检索子元素------start");
            // 检索子元素
            IEnumerable<int> scoreQuery =
                   from score in scores
                   where score > 91
                   select score;

            foreach (var ele in scoreQuery)
            {
                Console.Write(ele + " ");
            }
            Console.WriteLine();
            Console.WriteLine("转换为新的对象------start");
            // 转换为新的对象
            IEnumerable<string> highScoresQuery =
                from score in scores
                where score > 80
                orderby score descending
                select $"The score is {score}";
            
            foreach (var ele in highScoresQuery)
            {
                Console.Write(ele + " ");
            }

            Console.WriteLine();
            Console.WriteLine("检索有关元数据的单独值");

            int highScoreCount =
                (from score in scores
                 where score > 80
                 select score
                 ).Count();

            Console.WriteLine("超过八十分的人数:{0}", highScoreCount);

            string[] groupingQuery = { "carrots", "cabbage", "broccoli", "beans", "barley" };
            IEnumerable<IGrouping<char, string>> queryFoodGroups =
                from item in groupingQuery
                group item by item[0];


            foreach (var item in queryFoodGroups)
            {
                Console.WriteLine($"count:{queryFoodGroups.Count()} key:{item.Key} value:{item.ElementAt(0)}");
                
            }
        }
    }
}
