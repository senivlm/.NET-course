using System;
using System.Collections;
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
            //matr.MainDiag(true);
            matr.Print();
            foreach (var item in matr)
            {
                Console.WriteLine(item);
            }
           
        }
    }
    
    
}