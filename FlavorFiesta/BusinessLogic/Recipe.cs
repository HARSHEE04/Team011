using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlavorFiesta.BusinessLogic
{
    //this is the recipe class
    internal class Recipe
    {
        //Field Variables for Recipe Class
        private static int lastId = 0;
        private int id; // the id of the recipe will be used in for the recipe searching process and displaying process in the Recipe Manager class
        private string _name;
        private string _recipeImage;
        private string _recipeURL;
        //Nutrition class is part of this; ensure to show composition relationship here

        //Properties
        public int ID
        {
            get { return id; }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("The name of the recipe cannot be blank");
                }
                _name = value;
            }
        }

        public string RecipeImage
        {
            get { return _recipeImage; }
            init { _recipeImage = value; }
        }

        public string RecipeURL
        {
            get { return _recipeURL; }
            init
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("The recipe's URL cannot be blank");
                }
                _recipeURL = value;
            }
        }

        public Recipe(string name, string recipeImage, string recipeURL)
        {
            id = ++lastId; // the ++ is an increment operator and it increments the variable by 1 and returns the incremented value
            Name = name;
            RecipeImage = recipeImage;
            RecipeURL = recipeURL;

        }

    }
}
