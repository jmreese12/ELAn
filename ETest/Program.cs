using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ELAn;

namespace ETest
{
    class Program
    {
        //testing this jawn
        static void Main(string[] args)
        {
            Matrix m1 = new int[,] 
            { 
             { 0, 1 },
             { 2, 3 } 
            };

            Matrix m2 = new int[,] 
            { 
             { 0, 3 },
             { 4, 5 } 
            };

            m1.GetRow(1);
            Console.WriteLine((m1+m2));
            Console.ReadKey();
        }
    }
}
