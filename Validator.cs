using System;
using System.Collections.Generic;

namespace PizzaCalories
{
    public static class Validator
    {
        public static void ThrowIfNumberIsNotInRange(int min, int max, int number, string exMessage) 
        {
            if (number < min || number > max)
            {
                throw new ArgumentException(exMessage);  
            }        
        }

        public static void ThrowIfValueIsNotAllowed(HashSet<string> allowedValues, 
            string value, 
            string exMessage) 
        {
            if (!allowedValues.Contains(value))
            {
                throw new ArgumentException(exMessage);
            }
        }
    }
}
