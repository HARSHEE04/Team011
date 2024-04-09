using System;
namespace FlavorFiesta.BusinessLogic
{
    internal class Nutrition
    {
        #region Fields
        private int _calories;
        private int _protein;
        private int _sugar;
        #endregion

        #region Properties
        public int Calories
        {
            get { return _calories; }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Calories cannot be negative");
                }
                _calories = value;
            }
        }

        public int Protein
        {
            get { return _protein; }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Protein cannot be negative");
                }
                _protein = value;
            }
        }

        public int Sugar
        {
            get { return _sugar; }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Sugar cannot be negative");
                }
                _sugar = value;
            }
        }
        #endregion

        #region Constructor
        public Nutrition(int calories, int protein, int sugar)
        {
            Calories = calories;
            Protein = protein;
            Sugar = sugar;
        }
        #endregion
    }
}

