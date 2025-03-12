namespace RSGymPT.Models
{
    //<summary>
    //This class represents a user of the application.
    //</summary>
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string UserCode { get; set; }
        public string Password { get; set; }
    }
}
