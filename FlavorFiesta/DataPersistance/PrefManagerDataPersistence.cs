using System;
using System.Text;
using System.Text.Json;
using FlavorFiesta.BusinessLogic;

namespace FlavorFiesta.DataPersistance
{
    public class PrefManagerDataPersistence
    {
        private List<BusinessLogic.Preferences> _preferencesList = new List<BusinessLogic.Preferences>();
        private readonly string _filePath;

        public PrefManagerDataPersistence(string filePath)
        {
            _filePath = filePath;
            LoadPreferences();
        }

        public IEnumerable<BusinessLogic.Preferences> GetUserPreferences() => _preferencesList;

        public void AddPreferences(BusinessLogic.Preferences preferences)
        {
            _preferencesList.Add(preferences);
            SavePreferences(); // Save in JSON format by default
            SavePreferencesToCSV(); // Also save in CSV format
        }

        private void SavePreferences()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            try
            {
                Console.WriteLine("Saving Preferences:");
                foreach (var pref in _preferencesList)
                {
                    Console.WriteLine($"DietType: {pref.DietType}, CaloriesRange: {pref.CaloriesRange}");
                }

                string jsonString = JsonSerializer.Serialize(_preferencesList, options);
                File.WriteAllText(_filePath, jsonString);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving preferences: {ex.Message}");
            }
        }

        private void SavePreferencesToCSV()
        {
            StringBuilder csvContent = new StringBuilder();
            csvContent.AppendLine("DietType,CuisineType,MealType,CaloriesRange,ProteinRange,SugarRange,ServingsRange,PrepTimeRange,DietaryRestrictions");

            foreach (var pref in _preferencesList)
            {
                string restrictions = string.Join(";", pref.DietaryRestrictions);
                csvContent.AppendLine($"{pref.DietType},{pref.CuisineType},{pref.MealType},{pref.CaloriesRange},{pref.ProteinRange},{pref.SugarRange},{pref.ServingsRange},{pref.PrepTimeRange},\"{restrictions}\"");
            }

            try
            {
                File.WriteAllText(_filePath.Replace(".json", ".csv"), csvContent.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving preferences to CSV: {ex.Message}");
            }
        }

        private void LoadPreferences()
        {
            try
            {
                if (File.Exists(_filePath))
                {
                    string jsonString = File.ReadAllText(_filePath);
                    _preferencesList = JsonSerializer.Deserialize<List<BusinessLogic.Preferences>>(jsonString) ?? new List<BusinessLogic.Preferences>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading preferences: {ex.Message}");
            }
        }
    }
}

