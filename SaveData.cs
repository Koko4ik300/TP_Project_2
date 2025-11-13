using System.Text.Json;
using System.IO;

namespace TP_Project
{
    static class SaveData
    {
        public static void Save(string data, string filepath)
        {
            string json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filepath, json);
        }
    }
}
