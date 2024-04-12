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
        public void AddPreferences(BusinessLogic.Preferences preferences)
        {
            _preferencesList.Add(preferences);
            SavePreferences();
        }
        public IEnumerable<BusinessLogic.Preferences> GetUserPreferences() => _preferencesList;

        private void SavePreferences()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            File.WriteAllText(_filePath, JsonSerializer.Serialize(_preferencesList, options));
        }


        private void LoadPreferences()
        {
            if (File.Exists(_filePath))
            {
                string jsonString = File.ReadAllText(_filePath);
                _preferencesList = JsonSerializer.Deserialize<List<BusinessLogic.Preferences>>(jsonString) ?? new List<BusinessLogic.Preferences>();
            }
        }
    }
}

