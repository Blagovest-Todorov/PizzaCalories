using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaCalories
{
    public class Pizza
    {
        private const int MaxToppingCount = 10;
        private const int MinToppingCount = 0;

        private const int NameMinLength = 1;
        private const int NameMaxLength = 15;

        private string name;
        private readonly Dough dough;       

        private readonly List<Topping> toppings;

        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.dough = dough;
            this.toppings = new List<Topping>();
        }
        public string Name 
        {
            get => this.name;
            private set 
            {
                if (value.Length < NameMinLength || value.Length > NameMaxLength)
                {
                    throw new ArgumentNullException(
                        $"Pizza name should be between {NameMinLength} and {NameMaxLength} symbols.");
                }

                this.name = value;
            }        
        }

        public void AddTopping(Topping topping)
        {
            if (this.toppings.Count == MaxToppingCount) //  ? > 10
            {
                throw new InvalidOperationException($"Number of toppings should be in range " +
                    $"[{MinToppingCount}..{MaxToppingCount}].");
            }

            this.toppings.Add(topping);
        }

        public double GetCalories() 
        {
            return this.dough.GetCalories() + this.toppings.Sum(top => top.GetCalories());
        }
    }
}
