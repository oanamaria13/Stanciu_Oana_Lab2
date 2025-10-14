using System.ComponentModel.DataAnnotations;

namespace Stanciu_Oana_Lab2.Models
{
    public class Author
    {
        public int ID { get; set; }

        [Required, StringLength(50)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required, StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public ICollection<Book>? Books { get; set; }

        [Display(Name = "Author Name")]
        public string FullName => $"{FirstName} {LastName}";
    }
}
