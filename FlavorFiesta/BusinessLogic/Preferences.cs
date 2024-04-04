using System;
namespace FlavorFiesta.BusinessLogic
{
    public class Preferences
    {

        // Fields (Attributes)
        private string dietType;
        private string cuisineType;
        private string mealType;
        private string caloriesRange;
        private string proteinRange;
        private string sugarRange;
        private string servingsRange;
        private string prepTimeRange;
        private List<string> dietaryRestrictions = new List<string>();
        public List<string> DietaryRestrictions { get; private set; } // Read-only property

        // Constructor
        public Preferences()
        {
            // Initialize the list to prevent a null reference
            DietaryRestrictions = new List<string>();
        }

        // Methods to set the preferences
        public void SetDietType(string type)
        {
            dietType = type;
        }

        public void SetCuisineType(string type)
        {
            cuisineType = type;
        }

        public void SetMealType(string type)
        {
            mealType = type;
        }

        public void SetCaloriesRange(string range)
        {
            caloriesRange = range;
        }

        public void SetProteinRange(string range)
        {
            proteinRange = range;
        }

        public void SetSugarRange(string range)
        {
            sugarRange = range;
        }

        public void SetServingsRange(string range)
        {
            servingsRange = range;
        }

        public void SetPrepTimeRange(string range)
        {
            prepTimeRange = range;
        }

        public string GetDietType() => dietType;
        public string GetCuisineType() => cuisineType;
        public string GetMealType() => mealType;
        public string GetCaloriesRange() => caloriesRange;
        public string GetProteinRange() => proteinRange;
        public string GetSugarRange() => sugarRange;
        public string GetServingsRange() => servingsRange;
        public string GetPrepTimeRange() => prepTimeRange;
        public List<string> GetDietaryRestrictions() => dietaryRestrictions;
    
        // Method to add a dietary restriction to the list
        public void AddDietaryRestriction(string restriction)
        {
            if (restriction == null)
            {
                throw new ArgumentNullException(nameof(restriction), "Restriction cannot be null");
            }

            DietaryRestrictions.Add(restriction);
        }
    }
}

