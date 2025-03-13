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

        public static List<User> Users { get; private set; } = new List<User>();
        public static List<PersonalTrainer> PersonalTrainers { get; private set; } = new List<PersonalTrainer>();

        //<summary>
        //This method initializes the seed data.
        //If the files are missing, an exception is thrown.
        //</summary>
        public static void Initialize()
        {
            Users = LoadData<User>(UsersPath);
            Console.WriteLine($"Loaded {Users.Count} users from {UsersPath}.");

            PersonalTrainers = LoadData<PersonalTrainer>(PersonalTrainersPath);
            Console.WriteLine($"Loaded {PersonalTrainers.Count} personal trainers from {PersonalTrainersPath}.");
            Console.WriteLine();
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
