using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_1
{
    internal class DairyProduct: Product
    {
        int expirationDate;//days
        public int ExpirationDate { get { return expirationDate; } }
        public DairyProduct(): base()
        {

        }

        public DairyProduct(string name, double price, double weight, int expirationDate): base(name, price, weight )
        {
            this.expirationDate = expirationDate;
        }

        public override bool Equals(object? obj)
        {
            return obj is DairyProduct products &&
                   base.Equals(obj) &&
                   expirationDate == products.expirationDate;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), ExpirationDate);
        }
        public override string ToString()
        {
            return base.ToString() + " " + this.expirationDate + " days";
        }
        public override void ChangePrice(double percent)
        {
            int expirationDiscount = 0;
            if (ExpirationDate < 7)
            {
                expirationDiscount = 10;
            }
            else
                expirationDiscount = 2;
            Price = Price * (1 - (percent + expirationDiscount) * 0.01);
        }
        public override void Read(string str)
        {
            try
            {
                string[] arr = str.Split(' ');
                if (!char.IsUpper(arr[0][0]))
                    arr[0] = char.ToUpper(arr[0][0]) + arr[0].Substring(1);
                Name = arr[0];
                Price = double.Parse(arr[1]);
                Weight = double.Parse(arr[2]);
                expirationDate = Int32.Parse(arr[3]);
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
    }
}
