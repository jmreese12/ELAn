using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELAn
{
    public class Matrix
    {
        private int[,] matrix;

        private int width;
        private int height;

        public Matrix(int width, int height)
        {
            this.matrix = new int[width,height];

            this.width = width;
            this.height = height;
        }

        public Matrix(int[,] matrix)
        {
            this.matrix = matrix;

            this.width = matrix.GetLength(0);
            this.height = matrix.GetLength(1);
        }

        public bool IsSquare
        {
            get
            {
                return width == height;
            }
        }

        public int Width
        {
            get
            {
                return width;
            }
        }

        public int Height
        {
            get
            {
                return height;
            }
        }

        public static Matrix Add(Matrix m1, Matrix m2)
        {
            if ((m1.width == m2.width) && (m1.height == m2.height))
            {
                for (int x = 0; x < m1.width; x++)
                {
                    for (int y = 0; y < m1.height; y++)
                    {
                        m1.matrix[x,y] += m2.matrix[x,y];
                    }
                }

                return m1;
            }

            return null;
        }

        public override bool Equals(object obj)
        {
            if (obj is Matrix)
            {
                Matrix m = (Matrix)obj;

                m.matrix.
            }

            return false;
        }

        public int this[int x, int y]
        {
            get
            {
                return this[x, y];
            }
            set
            {
                this[x, y] = value;
            }
        }

        public static implicit operator Matrix(int[,] matrix)
        {
            return new Matrix(matrix);
        }

        public static implicit operator int[,](Matrix matrix)
        {
            return matrix;
        }

        public static Matrix operator +(Matrix m1, Matrix m2)
        {
            return Matrix.Add(m1, m2);  
        }

    }
}
