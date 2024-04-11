using System;
using System.Text.Json;

namespace FlavorFiesta.BusinessLogic
{
	public class PreferencesManager
	{
        //define a list
        private List<Preferences> _preferencesList = new List<Preferences>();
        private readonly string _filePath;

        public PreferencesManager(string filePath)
        {
            _filePath = filePath;
            LoadPreferences();
        }
        public void AddPreferences(Preferences preferences)
        {
            _preferencesList.Add(preferences);
            SavePreferences();
        }
        public IEnumerable<Preferences> GetUserPreferences() => _preferencesList;

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
                _preferencesList = JsonSerializer.Deserialize<List<Preferences>>(jsonString) ?? new List<Preferences>();
            }
        }
  //      private void RetriveUserInfo()
		//{
		//	//takes the user information, and takes them into a listview page where
		//	//they can either do previous prefernces or new prefernces
		//	return;
		//}
	}
}

