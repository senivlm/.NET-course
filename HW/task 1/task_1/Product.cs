using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_1
{
    internal class Product
    {
        private string name;
        private double price;
        private double weight;
        public string Name 
        { 
            get
            {
                return name;
            }
            set
            {
                name = value;
            } 
        }
        public double Price 
        {
            get 
            { 
                return price;
            }
            set { 

                if (value < 0)
                    price = 0;
                else
                    price = value;
            
            } 
        }   

        public double Weight 
        {
            get
            {
                return weight;
            }
            set
            {
                if (value < 0)
                    weight = 0;
                else if (value > 0)
                    weight = value;
            }
        }
        public Product()
        {
            Name = " - ";
            Price = 0;
            Weight = 0;
        }
        public Product(string name, double price, double weight)
        {
            Name = name; Price = price; Weight = weight;    
        }

        

        public override string ToString()
        {
            return name + " - " + price + " UAH " + weight + " grams";
        }
        
      
        public string ToShortString()
        {
            return name + "\t-\t" + price + " UAH ";
        }

    }
}
