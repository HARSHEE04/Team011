
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using FlavorFiesta.DataPersistance;


namespace FlavorFiesta.BusinessLogic
{
    /// <summary>
    /// The purpose of this recipe manager was manage the list of recipe which sill be recieved from the csv file. As per our project requirements, we needed to find two matching recipes from the list of recipes in the csv and present
    /// them to the user to allow them to choose one that suits them and matches the preferences they had outlined in the previous pages.
    /// </summary>
    //The recipe manager class will manage the list of recipes, it will have a method that searches the collection of recipes based on the info recieved from the preferences class
    //Then, it will aid in displaying the chosen recipe by working with the code behind



    internal class RecipeManager
    {
        /// <summary>
        /// The purpose of the SearchRecipe method is to allow the program to find two recipes that match the users preferences from the recipes we have in the CSV file. This method uses the ReadRecipesFromCSV method which is 
        /// present in the RecipeManagerDataPersistance class to read from the CSV file with the recipes. The SearchRecipe method will then use 
        /// </summary>
        /// <param name="userPreferences">This is an object of the Preferneces class and is supposed to hold the usersPreferences when implemented in the code behind.</param>
        /// <param name="csvAccess">This is an object of the RecipeManagerDataPersistance class and allows us to use the ReadRecipesFromCSV method which is present in that class.</param>
        /// <returns></returns>
        public Recipe SearchRecipe(Preferences userPreferences, RecipeManagerDataPersistance csvAccess) //just used dependency relationship for loose coupling
        {
            List<Recipe> recipes = csvAccess.ReadRecipesFromCSV(); //now we have the list of recipes from the CSV stored into this local list

           
            ///The methods used here are referenced below and explained in the project report in the learnings section
            
            Recipe matchingRecipeRequests = (from recipe in recipes
                                          where recipe.RecipePreferences.DietType == userPreferences.DietType &&
                                          recipe.RecipePreferences.CuisineType == userPreferences.CuisineType &&
                                          recipe.RecipePreferences.MealType == userPreferences.MealType &&
                                          recipe.RecipePreferences.CaloriesRange == userPreferences.CaloriesRange &&
                                          recipe.RecipePreferences.ProteinRange == userPreferences.ProteinRange &&
                                          recipe.RecipePreferences.SugarRange == userPreferences.SugarRange &&
                                          recipe.RecipePreferences.ServingsRange == userPreferences.ServingsRange &&
                                          recipe.RecipePreferences.PrepTimeRange == userPreferences.PrepTimeRange 
                                          //recipe.RecipePreferences.DietaryRestrictions.SequenceEqual(userPreferences.DietaryRestrictions)
                                          select recipe).FirstOrDefault(); //returns first recipe that matches or null if none are found

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





