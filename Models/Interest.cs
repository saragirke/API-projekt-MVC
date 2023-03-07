using System.ComponentModel.DataAnnotations;

namespace AdminPoodle.Models {

    public class Interest {
         public int Id {get; set;}

        [Required(ErrorMessage = "Obligatoriskt")]
        [Display(Name = "Namn:")]
        public String? CommenterName {get; set;} 

        [Required(ErrorMessage = "Obligatoriskt")]
        [Display(Name = "Ålder:")]
        public int? Age{get; set;} 

        [Required(ErrorMessage = "Obligatoriskt")]
        [Display(Name = "Kort om dig:")]
        public string? About{get; set;} 
       
        [Required(ErrorMessage = "Obligatoriskt")]
        [Display(Name = "Email:")]
        public string? Email{get; set;} 
       
        [DataType(DataType.Date)]
        public DateTime DateCreated {get; init;} = DateTime.Now;


    }
}