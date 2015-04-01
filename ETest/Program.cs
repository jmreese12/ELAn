using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ELAn;
using LogExec;

namespace ETest
{
    class Program
    {
        static Matrix CreateRandomMatrix(int width, int height, int maxValue)
        {
            int size = width * height;
            int[] values = new int[size];

            Random r = new Random(DateTime.Now.Second);

            for (int i = 0; i < size; i++)
            {
                values[i] = r.Next(maxValue);
            }

            return new Matrix(width, height, values);
        }

        //testing this jawn
        static void Main(string[] args)
        {
            
            Matrix m1 = CreateRandomMatrix(100, 100, 9);

            Matrix m2 = CreateRandomMatrix(100, 100, 9);

            using(new ExecutionTimeLogger("Multiplication"))
            {
                Matrix.Multiply(m1, m2); 
            }
           
            //Console.WriteLine((m1*m2));
            Console.ReadKey();
        }
    }
}
