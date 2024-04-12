using System;
namespace FlavorFiesta.BusinessLogic
{
    public class Preferences
    {
        #region Fields
        private string _dietType;
        private string _cuisineType;
        private string _mealType;
        private int _caloriesRange;
        private int _proteinRange;
        private int _sugarRange;
        private int _servingsRange;
        private TimeSpan _prepTimeRange;
        private List<string> _dietaryRestrictions;
        #endregion

        #region Constructor
        public Preferences(string dietType, string cusineType, string mealType, int caloriesRange, int protenRange,
            int sugarRange, int serveingsRange, TimeSpan prepTimeRange, List<string> dietaryRestrictions)
        {
            DietType = dietType;
            CuisineType = cusineType;
            MealType = mealType;
            CaloriesRange = caloriesRange;
            ProteinRange = protenRange;
            SugarRange = sugarRange;
            ServingsRange = serveingsRange;
            PrepTimeRange = prepTimeRange;
            DietaryRestrictions = dietaryRestrictions;
        }
        #endregion

        #region Properties
        public string DietType
        {
            get { return _dietType; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Diet type cannot be null or whitespace.", nameof(DietType));
                }
                _dietType = value;
            }
        }

        public string CuisineType
        {
            get { return _cuisineType; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Cuisine type cannot be null or whitespace.", nameof(CuisineType));
                }
                _cuisineType = value;
            }
        }

        public string MealType
        {
            get { return _mealType; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Meal type cannot be null or whitespace.", nameof(MealType));
                }
                _mealType = value;
            }
        }

        public int CaloriesRange
        {
            get { return _caloriesRange; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Calories range cannot be negative.", nameof(CaloriesRange));
                }
                _caloriesRange = value;
            }
        }

        public int ProteinRange
        {
            get { return _proteinRange; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Protein range cannot be negative.", nameof(ProteinRange));
                }
                _proteinRange = value;
            }
        }

        public int SugarRange
        {
            get { return _sugarRange; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Sugar range cannot be negative.", nameof(SugarRange));
                }
                _sugarRange = value;
            }
        }


        public int ServingsRange
        {
            get { return _servingsRange; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Servings range cannot be negative.", nameof(ServingsRange));
                }
                _servingsRange = value;
            }
        }

        public TimeSpan PrepTimeRange
        {
            get { return _prepTimeRange; }
            set
            {
                if (value.TotalMinutes < 0)
                {
                    throw new ArgumentException("Preparation time cannot be negative.", nameof(PrepTimeRange));
                }
                _prepTimeRange = value;
            }
        }

        public List<string> DietaryRestrictions
        {
            get { return _dietaryRestrictions; }
            init
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(DietaryRestrictions), "Dietary restrictions list cannot be null.");
                }
                _dietaryRestrictions = value;
            }
        }
        #endregion

        #region Methods
        // Method to add a dietary restriction
        public void AddDietaryRestriction(string restriction)
        {
            if (string.IsNullOrWhiteSpace(restriction))
            {
                throw new ArgumentException("Restriction cannot be null or whitespace.", nameof(restriction));
            }
            _dietaryRestrictions.Add(restriction);
        }

        public void RemoveDietaryRestriction(string restriction)
        {
            _dietaryRestrictions.Remove(restriction);
        }

        // Helper method for validation
        private static string ValidateInput(string value, string propertyName)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException($"{propertyName} cannot be null or whitespace.", propertyName);
            }
            return value;
        }
        #endregion
    }

}

