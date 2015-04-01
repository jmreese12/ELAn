using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELAn
{
    public class MatrixMismatchException : Exception
    {
       public MatrixMismatchException(string message) : base(message)
       {

       }
    }
}
