﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using FlavorFiesta.DataPersistance;

//THIS FILE WAS MADE AND EDITED BY HARSHETA SHARMA
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
        public Recipe SearchRecipe(Preferences userPreferences, RecipeManagerDataPersistance csvAccess)
        {
            List<Recipe> recipes = csvAccess.ReadRecipesFromCSV();

            
            Preferences normalizedPreferences = NormalizePreferences(userPreferences);
            foreach (Recipe recipe in recipes)
            {
                
                Preferences normalizedRecipePreferences = NormalizePreferences(recipe.RecipePreferences);

                if (ArePreferencesEqual(normalizedRecipePreferences, normalizedPreferences))
                {
                    
                    return recipe;
                }
            }
            return null;
        }

        /// <summary>
        /// This method is used to ensure that te string properities which are present in the Preferences class are processed in a way that is consistent so they can be used for comparision. It uses the Trim()? and the ToLower() method
        /// which are explained in my report- HARSHETA SHARMA
        /// Source for TRIM()? : https://learn.microsoft.com/en-us/dotnet/api/system.string.trim?view=net-8.0
        /// SOURCE FOR TOLOWER() : https://learn.microsoft.com/en-us/dotnet/api/system.string.tolower?view=net-8.0
        /// </summary>
        /// <param name="preferences"> This takes in a Preferences class object to normalize it which means put it in a format that is consistent so we can use it for comparision</param>
        /// <returns></returns>
        private Preferences NormalizePreferences(Preferences preferences)
        {
            return new Preferences(
                preferences.DietType?.Trim()?.ToLower(),
                preferences.CuisineType?.Trim()?.ToLower(),
                preferences.MealType?.Trim()?.ToLower(),
                preferences.CaloriesRange?.Trim()?.ToLower(),
                preferences.ProteinRange?.Trim()?.ToLower(),
                preferences.SugarRange?.Trim()?.ToLower(),
                preferences.ServingsRange?.Trim()?.ToLower(),
                preferences.PrepTimeRange?.Trim()?.ToLower()
           
            );
        }

        /// <summary>
        /// This method compares two instances of the preferences class to see if they are equal which is why it takes in two preferences objects for comparison
        /// </summary>
        /// <param name="preferences1">This is our case is the recipe preferences from the text file, object of preferences class</param>
        /// <param name="preferences2"> this is in our case is the user preferences, object of preferences class</param>
        /// <returns></returns>
        private bool ArePreferencesEqual(Preferences preferences1, Preferences preferences2)
        {
            return preferences1.DietType == preferences2.DietType &&
                   preferences1.CuisineType == preferences2.CuisineType &&
                   preferences1.MealType == preferences2.MealType &&
                   preferences1.CaloriesRange == preferences2.CaloriesRange &&
                   preferences1.ProteinRange == preferences2.ProteinRange &&
                   preferences1.SugarRange == preferences2.SugarRange &&
                   preferences1.ServingsRange == preferences2.ServingsRange &&
                   preferences1.PrepTimeRange == preferences2.PrepTimeRange;
            
        }
    }
}







