using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

            for (int i = 0; i < values.Length; i++)
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
            if ((m1.height == m2.height) && (m1.width == m2.width))
            {
                for (int i = 0; i < (m1.width * m1.height); i++)
                {
                    m1.matrix[i] += m2.matrix[i];
                }
            }
            else
            {
                throw new MatrixMismatchException("Both operands must be of equal size.");
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
            else
            {
                throw new MatrixMismatchException("Both operands must be of equal size.");
            }

            return m1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rowNumber"></param>
        /// <returns></returns>
        public int[] GetRow(int rowNumber)
        {
            int[] values = new int[width];

            for (int i = 0; i < width; i++)
            {
                values[i] = matrix[GetPosition(rowNumber, i)];
            }

            return values;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="colNumber"></param>
        /// <returns></returns>
        public int[] GetColumn(int colNumber)
        {
            int[] values = new int[height];

            for (int i = 0; i < height; i++)
            {
                values[i] = matrix[GetPosition(i, colNumber)];
            }

            return values;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="m1"></param>
        /// <param name="m2"></param>
        /// <returns></returns>
        public static Matrix Multiply(Matrix m1, Matrix m2)
        {
            if (m1.width != m2.height)
            {
                throw new MatrixMismatchException("The first operand must have equal width to the second operands height.");
            }

            Matrix newMatrix = new Matrix(m1.height, m2.width);

            for (int row = 0; row < m1.height; row++)
            {
                for (int col = 0; col < m2.width; col++)
                {
                    int[] currentRow = m1.GetRow(row);
                    int[] currentCol = m2.GetColumn(col);
                    int value = 0;

                    for (int i = 0; i < currentRow.Length; i++)
                    {
                        value += currentRow[i] * currentCol[i];
                    }

                    newMatrix[row, col] = value;
                }
            }
            return newMatrix;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private int GetPosition(int x, int y)
        {
            return (x * width) + y;
        }

        /// <summary>
        /// 
        /// </summary>
        public int Size
        {
            get
            {
                return matrix.Length;
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

                if (m.Size != this.Size)
                {
                    return false;
                }

                for (int i = 0; i < this.Size; i++)
                {
                    if (this.matrix[i] != m.matrix[i])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static Matrix Transpose(Matrix m)
        {
            Matrix mTrans = new Matrix(m.width, m.height);

            for (int i = 0; i < m.height; i++)
            {

            }

            return mTrans;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static implicit operator Matrix(int[,] matrix)
        {
            int width = matrix.GetLength(0);
            int height = matrix.GetLength(1);

            int[] values = new int[width * height];

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    values[(x * width) + y] = matrix[x, y];
                }
            }
            return new Matrix(height, width, values);
        }

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

        public override string ToString()
        {
            string matrixPrint = "";

            for (int i = 0; i < matrix.Length; i++)
            {
                matrixPrint += matrix[i];
            }

            return Regex.Replace(matrixPrint, ".{" + width + "}", "$0\n");
        }


    }
}

