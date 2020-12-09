using System.ComponentModel.DataAnnotations;

namespace API.DTOS
{
    public class AdressDto
    {
        [Required]
         public string FirstName { get; set; }
        [Required]
        public string LastNAme { get; set; }
        [Required]
        public string Street { get; set; }
         [Required]
        public string City { get; set; }
         [Required]
        public string ZipCode { get; set; }
      
    }
}