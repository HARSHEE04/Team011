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

        public List<Recipe> SearchRecipe(Preferences userPreferences)
        {
            List<Recipe> recipes = ReadRecipesFromCSV(); //now we have the list of recipes from the CSV stored into this local list

            //now we use the LINQ Query Syntax to filter through the recipes

            //see if you can do recipe.RecipePreferences==userPreferences?? not valid tho because you need to compare contents which is why we need properties
            var matchingRecipeRequests = (from recipe in recipes
                                          where recipe.RecipePreferences.DietType == userPreferences.DietType &&
                                          recipe.RecipePreferences.CuisineType == userPreferences.CuisineType &&
                                          recipe.RecipePreferences.MealType == userPreferences.MealType &&
                                          recipe.RecipePreferences.CaloriesRange == userPreferences.CaloriesRange &&
                                          recipe.RecipePreferences.ProteinRange == userPreferences.ProteinRange &&
                                          recipe.RecipePreferences.SugarRange == userPreferences.SugarRange &&
                                          recipe.RecipePreferences.ServingsRange == userPreferences.ServingsRange &&
                                          recipe.RecipePreferences.PrepTimeRange == userPreferences.PrepTimeRange &&
                                          recipe.RecipePreferences.DietaryRestrictions.SequenceEqual(userPreferences.DietaryRestrictions) select recipe).Take(2).ToList();

            return matchingRecipeRequests;
            // EXPLAIN SEQUENCEEQUAL AND ToList, take 

            //sequence equal https://www.codingame.com/playgrounds/213/using-c-linq---a-practical-overview/sequenceequal
            //ToList: https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.tolist?view=net-8.0&redirectedfrom=MSDN#System_Linq_Enumerable_ToList__1_System_Collections_Generic_IEnumerable___0__
            //TO LIST USAGE GUIDE: https://www.codingame.com/playgrounds/213/using-c-linq---a-practical-overview/tolist-and-toarray,
            //TRY FROM WHERE SELECT SYNTAX https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/select-clause
            //HAVE TO USE LINQ QUERY SYNATX : https://learn.microsoft.com/en-us/dotnet/csharp/linq/get-started/write-linq-queries

            //figure out way to only get two recipes from all the matches, try TAKE() METHOD: https://www.tutorialspoint.com/chash-queryable-take-method
        }
    }
   
  


}





