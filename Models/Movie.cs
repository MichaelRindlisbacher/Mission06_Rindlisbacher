using System.ComponentModel.DataAnnotations;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using Microsoft.Extensions.Primitives;

namespace Mission06_Rindlisbacher.Models
{
    public class Movie  // create a class with attributes that correspond to the collumns in the database table
    {
        public int MovieID { get; set; }

        public string category { get; set; }

        public string Title { get; set; }

        public int Year {  get; set; }

        public string DirectorName {  get; set; }

        public string Rating {  get; set; }

        public bool? Edited {  get; set; }  // Permit null values

        public string? Lent { get; set; }

        [MaxLength(25)] // restrict length
        public string? Notes {  get; set; }

    }
}
