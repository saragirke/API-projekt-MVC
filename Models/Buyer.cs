using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AdminPoodle.Models {
public class Buyer {

    public int Id {get; set;}

    [Display (Name = "Förnamn:")]
    [MaxLength(120, ErrorMessage = "Max 120 tecken")]
    [Required(ErrorMessage = "Obligatoriskt fält")]
    public string? FirstName {get; set;}

    [Display (Name = "Efternamn:")]
    [MaxLength(120, ErrorMessage = "Max 120 tecken")]
    [Required(ErrorMessage = "Obligatoriskt fält")]
    public string? LastName {get; set;}


    [Display (Name = "E-mail:")]
    [Required(ErrorMessage = "Obligatoriskt fält")]
    [EmailAddress(ErrorMessage = "Felaktig e-postadress")]
    public string? Email {get; set;}


    [Display (Name = "Telefonnummer:")]
    [Required(ErrorMessage = "Obligatoriskt fält")]
    [RegularExpression("([0-9]+)", ErrorMessage = "Endast siffror!")]
    public int? Number { get; set; }

        public int? PupId {get ; set;}
        public Pup? Pup {get; set;}

}
}