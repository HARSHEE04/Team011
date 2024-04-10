using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using FlavorFiesta.Data_Persistance;

namespace FlavorFiesta.BusinessLogic
{
    //The recipe manager class will manage the list of recipes, it will have a method that searches the collection of recipes based on the info recieved from the preferences class
    //Then, it will aid in displaying the chosen recipe by working with the code behind
    internal class RecipeManager
    {
        
        public List<Recipe> SearchRecipe(Preferences userPreferences,RecipeManagerDataPersistance csvAccess) //just used dependency relationship for loose coupling
        {
            List<Recipe> recipes = csvAccess.ReadRecipesFromCSV(); //now we have the list of recipes from the CSV stored into this local list

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





