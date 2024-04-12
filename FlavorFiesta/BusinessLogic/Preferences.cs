﻿using System;
namespace FlavorFiesta.BusinessLogic
{
    public class Preferences
    {
        #region Fields
        private string _dietType;
        private string _cuisineType;
        private string _mealType;
        private string _caloriesRange;
        private string _proteinRange;
        private string _sugarRange;
        private string _servingsRange;
        private string _prepTimeRange;
        private List<string> _dietaryRestrictions;
        #endregion

        #region Constructor
        public Preferences(string dietType, string cusineType, string mealType, string caloriesRange, string protenRange,
            string sugarRange, string serveingsRange, string prepTimeRange, List<string> dietaryRestrictions)
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

        public string CaloriesRange
        {
            get { return _caloriesRange; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Calories range cannot be negative.", nameof(CaloriesRange));
                }
                _caloriesRange = value;
            }
        }

        public string ProteinRange
        {
            get { return _proteinRange; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Protein range cannot be negative.", nameof(ProteinRange));
                }
                _proteinRange = value;
            }
        }

        public string SugarRange
        {
            get { return _sugarRange; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Sugar range cannot be negative.", nameof(SugarRange));
                }
                _sugarRange = value;
            }
        }


        public string ServingsRange
        {
            get { return _servingsRange; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Servings range cannot be negative.", nameof(ServingsRange));
                }
                _servingsRange = value;
            }
        }

        public string PrepTimeRange
        {
            get { return _prepTimeRange; }
            set
            {
                if(string.IsNullOrWhiteSpace(value))
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
        public bool IsPreferencesValid()
        {
            bool isValidDietType = !string.IsNullOrWhiteSpace(DietType);
            bool isValidCuisineType = !string.IsNullOrWhiteSpace(CuisineType);
            bool isValidMealType = !string.IsNullOrWhiteSpace(MealType);

            // Validate numeric ranges; adjust according to your application's logic
            bool isValidCaloriesRange = CaloriesRange >= 1000 && CaloriesRange <= 3000;
            bool isValidProteinRange = ProteinRange >= 10 && ProteinRange <= 150;
            bool isValidSugarRange = SugarRange >= 0 && SugarRange <= 50;
            bool isValidServingsRange = ServingsRange >= 1 && ServingsRange <= 10;

            // Validate prep time; ensure it's within a reasonable limit
            bool isValidPrepTime = PrepTimeRange.TotalMinutes >= 15 && PrepTimeRange.TotalMinutes <= 120;

            // Check if there's at least one dietary restriction
            bool hasDietaryRestrictions = DietaryRestrictions != null && DietaryRestrictions.Any();

            // Combine all validations to determine if preferences are fully valid
            return isValidDietType &&
                   isValidCuisineType &&
                   isValidMealType &&
                   isValidCaloriesRange &&
                   isValidProteinRange &&
                   isValidSugarRange &&
                   isValidServingsRange &&
                   isValidPrepTime &&
                   hasDietaryRestrictions;
        }
        #endregion
    }

}

