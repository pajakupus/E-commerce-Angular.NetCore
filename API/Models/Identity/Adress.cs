namespace API.Models.Identity
{
    public class Adress
    {
        public int id { get; set; }
        public string FirstName { get; set; }
        public string LastNAme { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string AppUserId {get; set;}
        public AppUser AppUser { get; set; }
    }
}