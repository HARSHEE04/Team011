using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FlavorFiesta.BusinessLogic
{
    //The recipe manager class will manage the list of recipes, it will have a method that searches the collection of recipes based on the info recieved from the preferences class
    //Then, it will aid in displaying the chosen recipe by working with the code behind
    internal class RecipeManager
    {
        string _filePath;
        private Preferences _userPreferences;
        private Recipe _recipe;


        ///read recipes from csv file and make it into a list
        public List<Recipe> ReadRecipes()
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


///convert the things read from csv to individual preference properties get DIETTYPE= parts[1]
///make a method to get preferences object with specific selected preferences
///make a recipe search metod that compares the preference property to the recipe properties in the csv
///return two recipes that match this.
//nutrition class has the info about the meal type, diet type, cusine type, calories, protein, sugar, sering, prep time and dietary restirctions
//The recipe class needs to have a composition relationship with the nutrition class to get the values of these 
//then recipe manager class needs to check if the recipes property== preferencees.property, if it does, then return those recipes.

//TRY FROM WHERE SELECT SYNTAX https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/select-clause

//figure out way to only get two recipes from all the matches, try TAKE() METHOD: https://www.tutorialspoint.com/chash-queryable-take-method

//can use list to hold all recipe objects,can idenitfy the recipes using ID property

//ASK IF WE NEED TO USE ABSTARCT CLASS AND INTERFACES?
//dfsdsdfs


