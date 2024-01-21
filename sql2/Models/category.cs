using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http.Features;

namespace sql2.Models{
     public class Category
    {   [Key]
        public int Id {get; set;}
        [Required]
        public string? Name {get; set;}
        public ICollection<items>? Items {get;set;}
    }
}