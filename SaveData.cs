using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;

namespace TP_Project
{
    static class SaveData
    {
        private static string filepath = @"D:\JsonData.json"; 
        public static void Save(ObservableCollection<HomeworkItem> items)
        {
            string json = JsonSerializer.Serialize(items);
            File.WriteAllText(filepath, json);  
        }
        //hh
        public static ObservableCollection<HomeworkItem> Load()
        {
            if (!File.Exists(filepath))
                return new ObservableCollection<HomeworkItem>();

            string json = File.ReadAllText(filepath);

            if(string.IsNullOrEmpty(json))
                return new ObservableCollection<HomeworkItem>();

            return JsonSerializer.Deserialize<ObservableCollection<HomeworkItem>>(json) ?? new ObservableCollection<HomeworkItem>();
        }  
    }
}
