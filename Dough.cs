using System;

namespace PizzaCalories
{
    public class Dough
    {
        private const int MinWeight = 1;
        private const int MaxWeight = 200;
        private const string InvalidDoughExceptMessage = "Invalid type of dough.";

        private string flourType;
        private string bakingTechnique;
        private int weight;

        public Dough(string flourType, string bakingTechnique, int weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }
        public string FlourType
        {
            get => this.flourType;
            private set
            {
                var valueAsLower = value.ToLower();

                if (valueAsLower != "white" && valueAsLower != "wholegrain")
                {
                    throw new ArgumentException(InvalidDoughExceptMessage);
                }

                this.flourType = value;
            }
        }
        public string BakingTechnique
        {
            get => this.bakingTechnique;
            private set
            {
                var valueAsLower = value.ToLower();

                if (valueAsLower != "crispy" &&
                    valueAsLower != "chewy" &&
                    valueAsLower != "homemade")
                {
                    throw new ArgumentException(InvalidDoughExceptMessage);
                }

                this.bakingTechnique = value;
            }
        }
        public int Weight
        {
            get => this.weight;
            private set
            {
                    Validator.ThrowIfNumberIsNotInRange(MinWeight, MaxWeight, value,
                    $"Dough weight should be in the range [{MinWeight}..{MaxWeight}].");

                this.weight = value;
            }
        }

        public double GetCalories()
        {
            var flourTypeModifier = GetFlourTypeModifier();
            var bakingTechniqueModifier = GetBakingTechniqueModifier();
            return this.Weight * 2 * flourTypeModifier * bakingTechniqueModifier;
        }

        private double GetBakingTechniqueModifier()
        {
            var bakingTechniqueToLower = this.BakingTechnique.ToLower();

            if (bakingTechniqueToLower == "crispy")
            {
                return 0.9;
            }

            if (bakingTechniqueToLower == "chewy")
            {
                return 1.1;
            }

            return 1.0;
        }

        private double GetFlourTypeModifier()
        {
            var flouerTypeLower = this.FlourType.ToLower();

            if (flouerTypeLower == "white")
            {
                return 1.5;
            }

            return 1;           
        }
    }
}
