using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.Learn
{
    public class GenericInfo<T>
    {
        public void add(T input)
        {
            Console.WriteLine(input.ToString());
            Console.WriteLine(input.GetType());
        }
    }

    class GenericModel
    {
        public void display()
        {
            GenericInfo<int> info1 = new GenericInfo<int>();
            info1.add(1);

            GenericInfo<string> info2 = new GenericInfo<string>();
            info2.add("a");
        }
    }
}
