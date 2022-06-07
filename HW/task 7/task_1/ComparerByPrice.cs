using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_1
{
    internal class ComparerByPrice : IComparer<Product>
    {
        /*   public int Compare(object? x, object? y)
           {
               return ((Product)x).Name.CompareTo(((Product)y).Name);//додати коректну роботу з null 
           }*/
       
        public int Compare(Product? x, Product? y)
        {
            return x.Name.CompareTo(y.Name);   
        }
    }
}
