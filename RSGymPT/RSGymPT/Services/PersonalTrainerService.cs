using RSGymPT.Data;
using RSGymPT.Models;

namespace RSGymPT.Services
{
    //<summary>
    //This class contains the methods to manage personal trainers.
    //</summary>
    public class PersonalTrainerService
    {
        //<summary>
        //This method searches for a personal trainer by their code.
        //</summary>
        //<param name="code">The code of the personal trainer to search.</param>
        //<returns>The personal trainer found, or null if not found.</returns>
        public static PersonalTrainer? SearchPTByCode(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
            {
                throw new ArgumentException("Code cannot be null or empty.", nameof(code));
            }

            return SeedData.PersonalTrainers.FirstOrDefault(pt => pt.PTCode == code);
        }

        //<summary>
        //This method lists all personal trainers alphabetically.
        //</summary>
        //<returns>A list of all personal trainers sorted alphabetically by name.</returns>
        public static List<PersonalTrainer> ListPTs()
        {
            return SeedData.PersonalTrainers
                .OrderBy(pt => pt.PTName)
                .ToList();
        }
    }
}
