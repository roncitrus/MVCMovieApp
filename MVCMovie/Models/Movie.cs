using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCMovie.Models
{
    public class Movie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }  // primary Key for DB.

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Title { get; set; } 

        [Display(Name = "Release Date")] // specifies the correct Display for the field
        [DataType(DataType.Date)]   // Only the date is displayed, not time.  User not requeired to enter time info.
        public DateTime ReleaseDate { get; set; }

        [RegularExpression(@"^[A-Z]+[a-z-_A-Z\s]*$")]
        [Required]
        [StringLength(30)]
        public string Genre { get; set; }

        [Range(1, 100)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]  // specifies a currency
        public decimal Price { get; set; }

        [RegularExpression(@"^[0-9A-Z]+[a-zA-Z\s]*$")]
        [StringLength(5)]
        [Required]
        public string Rating { get; set; }
    }
}
