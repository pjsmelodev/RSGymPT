using RSGymPT.Models;
using System.Text.Json;

namespace RSGymPT.Data
{
    //<summary>
    //This class contains the seed data for the application.
    //</summary>
    public static class SeedData
    {
        private static readonly string UsersPath = "Data/JsonFiles/users.json";
        private static readonly string PersonalTrainersPath = "Data/JsonFiles/personal_trainers.json";

        //<summary>
        //This method initializes the seed data.
        //If the files are missing, an exception is thrown.
        //</summary>
        public static void Initialize()
        {
            var users = LoadData<User>(UsersPath);
            Console.WriteLine($"Loaded {users.Count} users from {UsersPath}.");

            var personalTrainers = LoadData<PersonalTrainer>(PersonalTrainersPath);
            Console.WriteLine($"Loaded {personalTrainers.Count} personal trainers from {PersonalTrainersPath}.");
        }

        //<summary>
        //Loads and deserializes the data from the specified JSON file.
        //</summary>
        //<param name="path">The path to the file to be loaded.</param>
        private static List<T> LoadData<T>(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"File not found: {path}. Please ensure it exists and is populated.");
            }

            var jsonData = File.ReadAllText(path);
            return JsonSerializer.Deserialize<List<T>>(jsonData) ?? new List<T>();
        }
    }
}
