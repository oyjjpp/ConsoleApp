﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace ConsoleApp.Learn
{
    class Features
    {
        public void display()
        {
            Rectangle r = new Rectangle(4.5, 7.5);
            r.Display();

            Type type = typeof(Rectangle);
            // 遍历 Rectangle 类的特性

            foreach (Object attribute in type.GetCustomAttributes(false))
            {
                DeBugInfo info = (DeBugInfo)attribute;
                if (info != null)
                {
                    Console.WriteLine("Bug no: {0}", info.BugNo);
                    Console.WriteLine("Developer: {0}", info.Developer);
                    Console.WriteLine("Last Reviewed: {0}", info.LastReview);
                    Console.WriteLine("Remarks: {0}", info.Message);
                }
            }

            Console.WriteLine("");

            foreach (MethodInfo m in type.GetMethods())
            {
                foreach (Attribute a in m.GetCustomAttributes(true))
                {
                    DeBugInfo dbi = a as DeBugInfo;
                    if (null != dbi)
                    {
                        Console.WriteLine("Bug no: {0}, for Method: {1}", dbi.BugNo, m.Name);
                        Console.WriteLine("Develop: {0}", dbi.Developer);
                        Console.WriteLine("Last Reviewd:{0}", dbi.LastReview);
                        Console.WriteLine("Reamrks: {0}", dbi.Message);
                    }
                }
            }
            Console.WriteLine("Hello World!");
        }
    }

    [AttributeUsage(AttributeTargets.Class |
   AttributeTargets.Constructor |
   AttributeTargets.Field |
   AttributeTargets.Method |
   AttributeTargets.Property,
   AllowMultiple = true)]
    public class DeBugInfo : System.Attribute
    {
        private int bugNo;
        private string developer;
        private string lastReview;
        public string message;

        public DeBugInfo(int bg, string dev, string d)
        {
            this.bugNo = bg;
            this.developer = dev;
            this.lastReview = d;
        }

        public int BugNo
        {
            get
            {
                return bugNo;
            }
        }
        public string Developer
        {
            get
            {
                return developer;
            }
        }
        public string LastReview
        {
            get
            {
                return lastReview;
            }
        }
        public string Message
        {
            get
            {
                return message;
            }
            set
            {
                message = value;
            }
        }
    }

    [DeBugInfo(45, "Zara Ali", "12/8/2012", Message = "Return type mismatch")]
    [DeBugInfo(49, "Nuha Ali", "10/10/2012", Message = "Unused variable")]
    class Rectangle
    {
        // 成员变量
        protected double length;
        protected double width;
        public Rectangle(double l, double w)
        {
            length = l;
            width = w;
        }
        [DeBugInfo(55, "Zara Ali", "19/10/2012", Message = "Return type mismatch")]
        public double GetArea()
        {
            return length * width;
        }
        [DeBugInfo(56, "Zara Ali", "19/10/2012")]
        public void Display()
        {
            Console.WriteLine("Length: {0}", length);
            Console.WriteLine("Width: {0}", width);
            Console.WriteLine("Area: {0}", GetArea());
        }
    }
}
