using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu
{
    internal class Menu
    {
        private List<Dish> dishes;
        public Dish this[int index]
        {
            get => dishes[index];
        }
        public int Length => dishes.Count;
        public Menu()
        {
            dishes = new List<Dish>();
        }
        public Menu(List<Dish> dishes) : this()
        {
            dishes = dishes;
        }
        public void AddDish(Dish dish)
        {
            dishes.Add(dish);
        }
        public override string ToString()
        {
            StringBuilder sb = new();
            foreach (Dish dish in dishes)
                sb.Append(dish.ToString() + "\n");
            return sb.ToString();
        }
    }
}
