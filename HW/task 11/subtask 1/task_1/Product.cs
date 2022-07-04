using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_1
{
    public class Product:IComparable
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

        virtual public void ChangePrice(double percent)
        {
            
            price = price * (1 - percent * 0.01);
        }

        virtual public void Read(string str)
        {
            string[] arr = str.Split(' ');
            if (!char.IsUpper(arr[0][0]))
                arr[0] = char.ToUpper(arr[0][0]) + arr[0].Substring(1);

            Name = arr[0];
            Price = double.Parse(arr[1]);
            Weight = double.Parse(arr[2]);
        }
        /**/

        public override string ToString()
        {
            return name + " - " + price + " UAH " + weight + " grams";
        }
        
      
        public string ToShortString()
        {
            return name + "\t-\t" + price + " UAH ";
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(name, price, weight);
        }

        public override bool Equals(object? obj)
        {
            return obj is Product product &&
                   name == product.name &&
                   price == product.price &&
                   weight == product.weight;
        }

        public int CompareTo(object? obj)
        {
            //if(this.Name == ((Product)obj).Name)
            //int res = -1;
            //if(obj == null)
            //{
            //    Console.WriteLine("NULL");
            //    return res;
            //}

            return (obj as Product)?.Name.CompareTo(this.Name)??-1;

            //return this.Name.CompareTo((obj as Product).Name);
        }
    }
}
