using LiteDB;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelInvatare.Model
{
    public class RezervareModel : IValidatableObject
    {
        public int Id { get; set; }

        [Display(Name = "Nume si Prenume")]
        [Required(ErrorMessage = "Acest camp este obligatoriu!")]
        public string Nume { get; set; }

        [Required(ErrorMessage = "Acest camp este obligatoriu!")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Numar telefon invalid!")]
        public string Telefon { get; set; }

        [Display(Name = "Adresa Email")]
        [Required(ErrorMessage = "Acest camp este obligatoriu!")]
        [EmailAddress(ErrorMessage = "Adresa email invalida!")]
        public string Email { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Acest camp este obligatoriu!")]
        [DataType(DataType.Date)]
        [Display(Name = "Check In")]
        public DateTime CheckIn { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Acest camp este obligatoriu!")]
        [DataType(DataType.Date)]
        [Display(Name = "Check Out")]
        public DateTime CheckOut { get; set; }

        [Display(Name = "Tip Camera")]
        public string TipCamera { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> res = new List<ValidationResult>();
            if (DateTime.Compare(CheckIn.Date, CheckOut.Date) > -1)
            {
                var prop = new[] { "CheckIn" };
                ValidationResult mss = new ValidationResult("Check In-ul nu poate fi in aceeasi zi sau dupa Check Out.", prop);
                res.Add(mss);
            }
            if (DateTime.Compare(CheckIn.Date, DateTime.Now.Date) < 0)
            {
                var prop = new[] { "CheckIn" };
                ValidationResult mss = new ValidationResult("Check In-ul nu poate fi in trecut.", prop);
                res.Add(mss);
            }
            if (DateTime.Compare(CheckIn.Date, DateTime.Now.Date) < 0)
            {
                var prop = new[] { "CheckIn" };
                ValidationResult mss = new ValidationResult("Check Out-ul nu poate fi in trecut.", prop);
                res.Add(mss);
            }
            //if (CamereGasite < 1)
            //{
            //    var prop = new[] { "TipCamera" };
            //    ValidationResult mss = new ValidationResult("Nu avem disponibilitate, va rugam selectati o alta perioada sau alt tip de camera", prop);
            //    res.Add(mss);
            //}
            return res;
        }

    }
}
