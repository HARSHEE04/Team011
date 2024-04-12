using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlavorFiesta.BusinessLogic
{
    //This class was developed by Harsheta Sharma
    //this is the recipe class which holds all the recipe objects. This class has an association relationship with the preferences class.

    /// <summary>
    /// This recipe class was created to be able to hold the recipe objects so when we get the recipes from the csv file, we are able to make an object from it. The object will have properties as seen below which 
    /// allows us to use data binding, perform validation checks and acesss field variable values of each object    /// </summary>
    public class Recipe
    {
       
        //Field Variables for Recipe Class
        private string _name;
        private string _recipeImage;
        private string _recipeURL;
        private Preferences _recipePreferences;

        #region Properties
        //Properties

        public Preferences  RecipePreferences
        { get { return _recipePreferences; }
          set { _recipePreferences = value; }
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

        public string RecipeImage  // no validation required for this property since if the image is not found, system throws an error
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
        #endregion

        #region Constructor
        public Recipe(string name, string recipeImage, string recipeURL, Preferences preferences)
        {
           
            Name = name;
            RecipeImage = recipeImage;
            RecipeURL = recipeURL;
            RecipePreferences = preferences;


        }
        #endregion
    }
}
