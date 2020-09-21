using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MyKittyLocation.Models
{
    [Table("Cats")]
    public class CatModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? CatId { get; set; }
        [DisplayName("Numer obroży")]
        [Required(ErrorMessage = "Pole wymagane")]
        [MaxLength(10)]
        public string? CollarId { get; set; }
        [DisplayName("Imię")]
        [Required(ErrorMessage = "Pole wymagane")]
        [MaxLength(10)]
        public string? Name { get; set; }
        [DisplayName("Zdjęcie")]
        public byte[] Photo { get; set; }
        public string? OwnerID { get; set; }
        
    }
}
