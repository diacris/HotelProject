using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelInvatare.Model
{
    public class ReviewModel
    {
        [StringLength(500, MinimumLength = 10, ErrorMessage = "Opinia trebuie sa fie intre 10 si 500 de caractere.")]
        [Required(ErrorMessage ="Opinia este necesara.")]
        public string Opinie { get; set; }
        [Range(0, 10, ErrorMessage = "Nota nu este valida.")]
        [Required(ErrorMessage = "Nota este necesara.")]
        public int Nota { get; set; }
        public int Id { get; set; }
    }
}
