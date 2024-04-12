
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlavorFiesta.BusinessLogic;

namespace FlavorFiesta.DataPersistance
{
    internal class RecipeManagerDataPersistance
    {
        string _filePath;

        

        ///read recipes from csv file and make it into a list
        public List<Recipe> ReadRecipesFromCSV() //could have put this into a method
        {
            //_filePath= ""
            List<Recipe> list = new List<Recipe>();

            try
            {
                string[] recipeObjects = File.ReadAllLines(_filePath);//used file path because that is the location, each line will have a recipe object

                foreach (string line in recipeObjects)
                {
                    string[] parts = line.Split(',');

                    //extracting needed information from the recipe 
                    string name = parts[0];
                    string recipeImage = parts[1];
                    string recipeURL = parts[2];


                    //now create the preferences object for this specific recipe 
                    BusinessLogic.Preferences preferences = new BusinessLogic.Preferences(

                        //the info and its corresponding property which will be used in Recipe class object made below
                        parts[3], // dietType, vegan etc
                        parts[4], // cuisineType
                        parts[5], // mealType, lunch etc
                        parts[6], // caloriesRange
                        parts[7], // proteinRange
                        parts[8], // sugarRange
                        parts[9], // servingsRange
                        parts[10], // prepTimeRange
                        new List<string>(parts[11].Split(';')) // dietaryRestrictions
                    );

                    //new recipe object made
                    Recipe recipe = new Recipe(name, recipeImage, recipeURL, preferences);
                    //add this recipe to the list of recipes
                    list.Add(recipe);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading recipes: " + ex.Message);
            }

            return list;
        }

    }
}
