using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using Microsoft.Extensions.Primitives;

namespace Mission06_Rindlisbacher.Models
{
    public class Movie  // create a class with attributes that correspond to the collumns in the database table
    {
        [Key]
        [Required]
        public int MovieID { get; set; }

        [ForeignKey("CategoryId")]
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        [Required(ErrorMessage = "You must enter a title")]
        public string Title { get; set; }

        [Range(1888, int.MaxValue, ErrorMessage = "You must enter a valid year")]
        public int Year {  get; set; }

        public string? Director {  get; set; }

        public string? Rating {  get; set; }

        [Required(ErrorMessage ="You must indicate whether the movie is edited")]
        public bool Edited {  get; set; }  // Permit null values

        public string? LentTo { get; set; }

        [Required(ErrorMessage = "Indicate whether the movie was copied to plex")]
        public bool CopiedToPlex { get; set; }

        [MaxLength(25)] // restrict length
        public string? Notes {  get; set; }

    }
}
