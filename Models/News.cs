using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AdminPoodle.Models {
public class News {

    public int Id {get; set;}

    [Display (Name = "Titel:")]
    [Required]
    public string? Title {get; set;}


    [Display (Name = "Inlägg:")]
    [Required]
    public string? Post {get; set;}


    [Display (Name = "Bild:")]
    public string? ImageName {get; set;}


    [DataType(DataType.Date)]
    public DateOnly? DateCreated {get; init;} = DateOnly.FromDateTime(DateTime.Now); //Endast Datum


    [NotMapped] //När en migration görs kommer detta inte skapas i databasen, endast gränssnittet
    [Display(Name = "Bild")]
    public IFormFile? ImageFile {get; set;}
}
}