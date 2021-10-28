using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.Learn
{
    class DelegateModel
    {
        public delegate int Comparison<in T>(T left, T right);
    }
}
