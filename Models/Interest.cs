using System.ComponentModel.DataAnnotations;

namespace AdminPoodle.Models
{

    public class Interest
    {
        public int Id { get; set; }

        [Display(Name = "Förnamn:")]
        [MaxLength(120, ErrorMessage = "Max 120 tecken")]
        [Required(ErrorMessage = "Obligatoriskt fält")]
        public string? FirstName { get; set; }

        [Display(Name = "Förnamn:")]
        [MaxLength(120, ErrorMessage = "Max 120 tecken")] 
        [Required(ErrorMessage = "Obligatoriskt fält")]
        public string? LastName { get; set; }


        [Required(ErrorMessage = "Obligatoriskt")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Endast siffror!")]
        [Range(18, 100, ErrorMessage = "Lägsta ålder 18 år")]
        [Display(Name = "Ålder:")]
        public int? Age { get; set; }

        [Required(ErrorMessage = "Obligatoriskt")]
        [Display(Name = "Kort om dig:")]
        public string? About { get; set; }

        [Required(ErrorMessage = "Obligatoriskt fält")]
        [EmailAddress(ErrorMessage = "Felaktig e-postadress")]
        [Display(Name = "Email:")]
        public string? Email { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateCreated { get; init; } = DateTime.Now;


    }
}