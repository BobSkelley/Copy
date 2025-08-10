using FitnessTracker.Models;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;

namespace FitnessTracker.Services
{
    public class DataService
    {
        public async Task<AppData> LoadData()
        {
            if (!File.Exists(Constants.DataPath))
                return new AppData();

            var json = await File.ReadAllTextAsync(Constants.DataPath);
            try
            {
                return JsonConvert.DeserializeObject<AppData>(json) ?? new AppData();
            }
            catch (JsonException)
            {
                // If deserialization fails, the file is likely corrupt.
                // Delete it and start fresh.
                File.Delete(Constants.DataPath);
                return new AppData();
            }
        }

        public async Task SaveData(AppData data)
        {
            var json = JsonConvert.SerializeObject(data, Formatting.Indented);
            await File.WriteAllTextAsync(Constants.DataPath, json);
        }
    }
}