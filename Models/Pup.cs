using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AdminPoodle.Models {
public class Pup {

    public int Id {get; set;}

    [Display (Name = "Namn:")]
    [Required]
    public string? Title {get; set;}


    [Display (Name = "Kön:")]
    [Required]
    public string? Gender {get; set;}


    [Display (Name = "Tingad:")]
    public bool Booked { get; set; }


    [Display (Name = "Bild:")]
    public string? ImageName {get; set;}

    [NotMapped] //När en migration görs kommer detta inte skapas i databasen, endast gränssnittet
    [Display(Name = "Bild")]
    public IFormFile? ImageFile {get; set;}

}
}