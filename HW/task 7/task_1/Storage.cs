using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_1
{
    internal class Storage
    {
        private List<Product> products;

        public List<Product> Products { get { return products; } }
        public Product this[int ind]
        {
            get
            {
                return products[ind];
            }
            set
            {
                products[ind] = value;
            }
        }
        public Storage()
        {
            products = new List<Product>();
        }
        public Storage(List<Product> _products)
        {
            products = new List<Product>();
            this.products = _products;
        }
        public void AddProduct(Product product)
        {
            products.Add(product);
        }
       
        public void ChangePrices(int percent)
        {
            foreach (Product item in products)
            {
                item.ChangePrice(percent);
            }
        }
        public Storage SelectMeat()
        {
            var allMeat = products.Where(i => i.GetType().Equals(typeof(Meat))).ToList();
            return new Storage(allMeat);
        }

        
    }
}
