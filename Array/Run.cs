using System;
using System.Collections.Generic;
using System.Text;

namespace Array
{
    public class Run
    {
        static void Main(string[] args)
        {
            var dynamicArr = new DynamicArray2();

            Console.WriteLine(dynamicArr.Count);

            dynamicArr.Add(1);
            dynamicArr.Add(2);
            dynamicArr.Add(3);

            Console.WriteLine(dynamicArr.Count);
            Console.WriteLine(dynamicArr.Get(0));
        }
    }
}
