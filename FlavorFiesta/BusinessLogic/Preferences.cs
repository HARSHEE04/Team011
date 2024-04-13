using System;
namespace FlavorFiesta.BusinessLogic
{
    /// <summary>
    /// Represents user preferences for dietary and culinary choices.
    /// </summary>
    /// Making A commit git reset to git rid of errors
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
        //private List<string> _dietaryRestrictions = new List<string>();
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="Preferences"/> class.
        /// </summary>
        /// <param name="dietType">The type of diet.</param>
        /// <param name="cusineType">The type of cuisine.</param>
        /// <param name="mealType">The type of meal.</param>
        /// <param name="caloriesRange">The range of calories.</param>
        /// <param name="protenRange">The range of protein.</param>
        /// <param name="sugarRange">The range of sugar.</param>
        /// <param name="serveingsRange">The range of servings.</param>
        /// <param name="prepTimeRange">The range of preparation time.</param>
        ///// <param name="dietaryRestrictions">The dietary restrictions.</param>
        public Preferences(string dietType, string cusineType, string mealType, string caloriesRange, string protenRange,
            string sugarRange, string serveingsRange, string prepTimeRange)                                              //(List<string> dietaryRestrictions)
        {
            //explained why i used a method here in report - Maryam
            DietType = ValidateInput(dietType, nameof(DietType)); 
            CuisineType = ValidateInput(cusineType, nameof(CuisineType));
            MealType = ValidateInput(mealType, nameof(MealType));
            CaloriesRange = ValidateInput(caloriesRange, nameof(CaloriesRange));
            ProteinRange = ValidateInput(protenRange, nameof(ProteinRange));
            SugarRange = ValidateInput(sugarRange, nameof(SugarRange));
            ServingsRange = ValidateInput(serveingsRange, nameof(ServingsRange));
            PrepTimeRange = ValidateInput(prepTimeRange, nameof(PrepTimeRange));
            //DietaryRestrictions = dietaryRestrictions ?? throw new ArgumentNullException(nameof(dietaryRestrictions));
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

        //public List<string> DietaryRestrictions
        //{
        //    get { return _dietaryRestrictions; }
        //    init
        //    {
        //        if (value == null)
        //        {
        //            throw new ArgumentNullException(nameof(DietaryRestrictions), "Dietary restrictions list cannot be null.");
        //        }
        //        _dietaryRestrictions = value;
        //    }
        //}
        #endregion

        #region Methods
        /// <summary>
        ///// Adds a dietary restriction.
        ///// </summary>
        ///// <param name="restriction">The dietary restriction to add.</param>
        //public void AddDietaryRestriction(string restriction) // Method to add a dietary restriction
        //{
        //    if (string.IsNullOrWhiteSpace(restriction))
        //    {
        //        throw new ArgumentException("Restriction cannot be null or whitespace.", nameof(restriction));
        //    }
        //    _dietaryRestrictions.Add(restriction);
        //}

        //public void RemoveDietaryRestriction(string restriction)
        //{
        //    _dietaryRestrictions.Remove(restriction);
        //}

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

