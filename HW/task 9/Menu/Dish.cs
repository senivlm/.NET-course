using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu
{
    internal class Dish
    {
        string name;
        private Dictionary<string, double> ingridients;
        string Name { get { return name; } }
        public double this[string key]
        {
            get
            {
                return ingridients[key];
            }
        }
        public int Length => ingridients.Count;
        public IEnumerable<string> Keys => ingridients.Keys;

        public Dish()
        {
            name = "";
            ingridients = new();
        }
        public Dish(string _name)
        {
            name = _name;
            ingridients = new();
        }
        public Dish(string _name, Dictionary<string, double> _ingridients) : this()
        {
            name = _name;
            ingridients = _ingridients;
        }
        public void AddIngredient(string ing, double price)
        {
            ingridients[ing] = price;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(name + "\n");
            foreach (var (key,val) in this.ingridients)
            {
                sb.Append(key + " " + val + "\n");
            }
            return sb.ToString();
        }
    }
}
