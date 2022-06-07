using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_1
{
    enum Grade
    {
        Premium,
        First,
        Second

    }
    internal class Meat: Product 
    {
        static public Dictionary<Grade,int> discounts ;//grade : percent of discount
        
        private Grade grade;
        public Grade Grade { get { return grade; } }
        static Meat()
        {
            discounts = new Dictionary<Grade, int>();
            discounts.Add(Grade.Premium, 4);
            discounts.Add(Grade.First, 6);
            discounts.Add(Grade.Second, 8);
        }
        public Meat(): base()
        {

            this.grade = new Grade();
        }
        
        public Meat(string _name, double _price, double _weight, Grade _grade ): base(_name, _price, _weight)
        {

            grade = _grade;
        }

        public override bool Equals(object? obj)
        {
            return obj is Meat meat &&
                   base.Equals(obj) &&
                   Name == meat.Name &&
                   Price == meat.Price &&
                   Weight == meat.Weight &&
                   Grade == meat.Grade;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), grade);
        }

        public override string ToString()
        {
            return base.ToString() + " " + grade + " grade";
        }

        public override void ChangePrice(double percent)
        {
            Price = Price * (1 - (percent + discounts[Grade]) * 0.01);

        }
        public override void Read(string str)
        {
            try
            {
                string[] arr = str.Split(' ');
                if (!char.IsUpper(arr[0][0]))
                    arr[0] = char.ToUpper(str[0]) + str.Substring(1);
                    
                Name = arr[0];
                Price = double.Parse(arr[1]);
                Weight = double.Parse(arr[2]);

                string grade_ = arr[3];
                if (grade_ == "Premium")
                    grade = Grade.Premium;
                else if (grade_ == "First")
                    grade = Grade.First;
                else if (grade_ == "Second")
                    grade = Grade.Second;
                else
                    throw new Exception("invalid grade");
            }
            catch (IndexOutOfRangeException ex)
            {
                throw new Exception("too few parameters");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ReadFromFile(StreamReader reader)
        {

        }
    }
}
