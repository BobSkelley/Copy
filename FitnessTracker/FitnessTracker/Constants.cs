namespace FitnessTracker
{
    public static class Constants
    {
        public const string DataFilename = "FitnessTracker.json";

        public static string DataPath =>
            Path.Combine(FileSystem.AppDataDirectory, DataFilename);
    }
}