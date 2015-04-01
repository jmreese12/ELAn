using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELAn
{
    /// <summary>
    /// 
    /// </summary>
    public struct Matrix
    {
        private int[] matrix;

        private int width;
        private int height;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public Matrix(int width, int height)
        {
            //uses single dimensional array to stride the array
            this.matrix = new int[width * height];

            //stores width and height of a matrix
            this.width = width;
            this.height = height;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        public Matrix(int width, int height, int[] values)
        {
            this.width = width;
            this.height = height;

            matrix = new int[height * width];

            for (int i = 0; i < values.Length - 1; i++)
            {
                matrix[i] = values[i];
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsSquare
        {
            get
            {
                return width == height;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int Width
        {
            get
            {
                return width;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int Height
        {
            get
            {
                return height;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="m1"></param>
        /// <param name="m2"></param>
        /// <returns></returns>
        public static Matrix Add(Matrix m1, Matrix m2)
        {
            if((m1.height == m2.height) && (m1.width == m2.width))
            {
                for (int i = 0; i < (m1.width*m1.height); i++)
                {
                    m1.matrix[i] += m2.matrix[i];
                }
            }

            return m1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="m1"></param>
        /// <param name="m2"></param>
        /// <returns></returns>
        public static Matrix Subtract(Matrix m1, Matrix m2)
        {
            if ((m1.height == m2.height) && (m1.width == m2.width))
            {
                for (int i = 0; i < (m1.width * m1.height); i++)
                {
                    m1.matrix[i] -= m2.matrix[i];
                }
            }

            return m1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="m1"></param>
        /// <param name="m2"></param>
        /// <returns></returns>
        public static Matrix Multiply(Matrix m1, Matrix m2)
        {
            return m1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private int GetPosition(int x, int y)
        {
            if (y == 0)
            {
                return (x * width) + y;
            }
            else
            {
                return (x * width) + (y + 1);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int this[int x, int y]
        {
            get
            {
                return matrix[GetPosition(x, y)];
            }

            set
            {
                matrix[GetPosition(x, y)] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is Matrix)
            {
                Matrix m = (Matrix)obj;
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        //public static implicit operator Matrix(int width, int height,int[] matrix)
        //{
        //    return new Matrix();
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static implicit operator int[](Matrix matrix)
        {
            return matrix;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="m1"></param>
        /// <param name="m2"></param>
        /// <returns></returns>
        public static Matrix operator +(Matrix m1, Matrix m2)
        {
            return Matrix.Add(m1, m2);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="m1"></param>
        /// <param name="m2"></param>
        /// <returns></returns>
        public static Matrix operator -(Matrix m1, Matrix m2)
        {
            return Matrix.Subtract(m1, m2);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="m1"></param>
        /// <param name="m2"></param>
        /// <returns></returns>
        public static Matrix operator *(Matrix m1, Matrix m2)
        {
            return Matrix.Multiply(m1, m2);
        }

    }
}

