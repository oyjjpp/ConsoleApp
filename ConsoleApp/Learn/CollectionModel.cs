using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp.Learn
{
    class CollectionModel
    {
        public class Galaxy
        {
            public string Name { get; set; }
            public int MegaLightYears { get; set; }
        }

        public class Element
        { 
            public string Symbol { get; set; }
            public string Name { get; set; }
            public int AtomicNumber { get; set; }
        }

        public static void ListDisplay()
        {
            var strData = new List<string>();
            strData.Add("C#");
            strData.Add("JAVA");
            strData.Add("Golang");

            foreach (var data in strData)
            {
                Console.Write(data + " ");
            }

            Console.WriteLine("已经完成初始化");
            var strDataV2 = new List<string> { "chinese", "english", "german" };

            strDataV2.Remove("german");

            for (var index = 0; index < strDataV2.Count; index++)
            {
                Console.Write(strDataV2[index] + " ");
            }

            Console.WriteLine();
            var numers = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            for (var i = numers.Count - 1; i >= 0; i--)
            {
                if (numers[i] % 2 == 1)
                {
                    numers.RemoveAt(i);
                }
            }

            numers.ForEach(
                numer => Console.Write(numer + " ")
            );

            Console.WriteLine("对象----------");
            var theGalaxies = new List<Galaxy>
            {
                new Galaxy{ Name="Tadpole", MegaLightYears=400},
                new Galaxy{ Name="Pinwheel", MegaLightYears=25},
            };

            theGalaxies.ForEach(
                info => Console.Write(info.Name + info.MegaLightYears + " ")
            );
        }

        public static void MapDisplay()
        {
            var info = new Dictionary<string, int>
            {
                { "Tom",1},
                { "Jack",2}
            };
            Console.WriteLine(info["Tom"]);
        }

        public static List<Element> BuildList()
        {
            return new List<Element>
            {
                {new Element(){Symbol="K",Name="Potassium",AtomicNumber=19}},
                {new Element(){Symbol="Ca",Name="Calcium",AtomicNumber=20}},
                {new Element(){Symbol="Sc",Name="Scanduim",AtomicNumber=21}},
                {new Element(){Symbol="Ti",Name="PotTitanium",AtomicNumber=22}}
            };
        }

        public static void ShowLINQ()
        {
            var elements = BuildList();
            var subset = from ele in elements
                         where ele.AtomicNumber <= 21
                         orderby ele.Name
                         select ele;

            foreach (Element ele in subset)
            {
                Console.WriteLine(ele.Name + " " + ele.AtomicNumber);
            }
        }

        public static void ListCars()
        {
            var cars = new List<Car>
            {
                { new Car(){ Name="car1", Color="blue",Speed=20} },
                { new Car(){ Name="car2", Color="red",Speed=50} },
                { new Car(){ Name="car3", Color="green",Speed=10} },
                { new Car(){ Name="car4", Color="blue",Speed=50} },
                { new Car(){ Name="car5", Color="blue",Speed=30} },
                { new Car(){ Name="car6", Color="red",Speed=60} },
                { new Car(){ Name="car7", Color="green",Speed=50} },
            };

            cars.Sort();

            foreach (Car data in cars)
            {
                Console.Write(data.Color.PadRight(5) + " ");
                Console.Write(data.Speed.ToString() + " ");
                Console.Write(data.Name);
                Console.WriteLine();
            }
        }

        public class Car : IComparable<Car>
        {
            public string Name { get; set; }
            public int Speed { get; set; }
            public string Color { get; set; }

            public int CompareTo(Car other)
            {
                var compare = string.Compare(this.Color, other.Color, true);
                if (compare == 0)
                {
                    compare = this.Speed.CompareTo(other.Speed);
                    compare = -compare;
                }
                return compare;
            }
        }
    }

}
