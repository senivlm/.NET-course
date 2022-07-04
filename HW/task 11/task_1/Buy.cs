using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_1
{
    internal class Buy
    {
        private Product product;
        private int number;
        private double sum;//гривні
        private double weight;//грами
        public Product Product 
        { 
            get
            { return product; }
        }
        public int Number 
        { 
            get { return number; }
        }
        public double Sum 
        {
            get { return sum; }
        }
        public double Weight 
        { 
            get { return weight; } 
        }
        public Buy()
        {
            product = new DairyProduct();
        }
        public Buy(Product _product, int _number = 1)
        {
            product = _product;
            number = _number;
            sum = product.Price * number;
            weight = product.Weight * number;
        }
        public override string ToString()
        {
            return product.ToShortString()+ " x " +number + "\t( " + weight + " g )\t= " + sum + " UAH " ;
        }

    }
}
