using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{

    class Program
    {
        static void Main(string[] args)
        {
            Matrix matr = new Matrix(3, 6);
            matr.MainDiag(true);
            matr.Print();
        }
    }
}