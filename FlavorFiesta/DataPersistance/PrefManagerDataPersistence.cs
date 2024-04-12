using System;
using System.Text.Json;
using FlavorFiesta.BusinessLogic;

namespace FlavorFiesta.DataPersistance
{
	public class PrefManagerDataPersistence
	{
        //define a list
        private List<BusinessLogic.Preferences> _preferencesList = new List<BusinessLogic.Preferences>();
        private readonly string _filePath;

        public PrefManagerDataPersistence(string filePath)
        {
            _filePath = filePath;
            LoadPreferences();
        }
                public IEnumerable<BusinessLogic.Preferences> GetUserPreferences() => _preferencesList;

        public void AddPreferences(FlavorFiesta.BusinessLogic.Preferences preferences)
        {
            _preferencesList.Add(preferences);
            SavePreferences();
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

        private void LoadPreferences()
        {
            try
            {
                if (File.Exists(_filePath))
                {
                    string jsonString = File.ReadAllText(_filePath);
                    _preferencesList = JsonSerializer.Deserialize<List<FlavorFiesta.BusinessLogic.Preferences>>(jsonString) ?? new List<FlavorFiesta.BusinessLogic.Preferences>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading preferences: {ex.Message}");
            }
        }
    }
}

