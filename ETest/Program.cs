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
        static void Main(string[] args)
        {
            Matrix m = new Matrix(2, 2);
            m[0, 0] = 1;
            m[1, 0] = 2;
            m[0, 1] = 3;
            m[1, 1] = 4;
            Matrix m2 = new Matrix(2, 3);
            m[0, 0] = 1;
            m[1, 0] = 2;
            m[0, 1] = 3;
            m[1, 1] = 4;


            m = m - m2;
            Console.WriteLine(m);
            Console.ReadKey();
        }
    }
}
