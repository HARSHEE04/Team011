using FlavorFiesta.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlavorFiesta.Data_Persistance
{
    internal class RecipeManagerDataPersistance
    {
        string _filePath;


        ///read recipes from csv file and make it into a list
        public List<Recipe> ReadRecipesFromCSV()
        {
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
                    Preferences preferences = new Preferences(

                        //the info and its corresponding property which will be used in Recipe class object made below
                        parts[3], // dietType
                        parts[4], // cuisineType
                        parts[5], // mealType
                        int.Parse(parts[6]), // caloriesRange
                        int.Parse(parts[7]), // proteinRange
                        int.Parse(parts[8]), // sugarRange
                        int.Parse(parts[9]), // servingsRange
                        TimeSpan.Parse(parts[10]), // prepTimeRange
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
