using ConsoleApp.Learn;
using System;
using System.Reflection;

namespace ConsoleApp
{
   
    class Programcl
    {
        static void Main(string[] args)
        {
            LinqModel.display();
        }

        static object GetObject() { return null; }
        static void SetObject(object obj) { }

        static string GetString() { return ""; }
        static void SetString(string str) { }

        static void display()
        {
            Func<object> del = GetString;
            Action<string> del2 = SetObject;

        }
    }
}
