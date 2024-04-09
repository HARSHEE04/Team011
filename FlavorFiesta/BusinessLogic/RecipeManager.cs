using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlavorFiesta.BusinessLogic
{
    //The recipe manager class will manage the list of recipes, it will have a method that searches the collection of recipes based on the info recieved from the preferences class
    //Then, it will aid in displaying the chosen recipe by working with the code behind
    internal class RecipeManager
    {
        //nutrition class has the info about the meal type, diet type, cusine type, calories, protein, suagr, sering, prep time and dietary restirctions
        //The recipe class needs to have a composition relationship with the nutrition class to get the values of these 
        //then recipe manager class needs to check if the recipes property== preferencees.property, if it does, then return those recipes.

        //TRY FROM WHERE SELECT SYNTAX https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/select-clause

        //figure out way to only get two recipes from all the matches, try TAKE() METHOD: https://www.tutorialspoint.com/chash-queryable-take-method

        //can use list to hold all recipe objects,can idenitfy the recipes using ID property

        //ASK IF WE NEED TO USE ABSTARCT CLASS AND INTERFACES?
    }
}
