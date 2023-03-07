using System.ComponentModel.DataAnnotations;

namespace AdminPoodle.Models
{

    public class Comment {
         public int Id {get; set;}

        [Required(ErrorMessage = "Obligatoriskt")]
        [Display(Name = "Namn:")]
        public String? CommenterName {get; set;} 

        [Required(ErrorMessage = "Obligatoriskt")]
        [Display(Name = "Kommentar:")]
        public String? Text {get; set;} 

    [DataType(DataType.Date)]
    public DateOnly? DateCreated {get; init;} = DateOnly.FromDateTime(DateTime.Now); //Endast Datum


        public int? NewsId {get ; set;}
        public News? News {get; set;}

    }
}