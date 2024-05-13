using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX.Core.Domain
{
    public class CLient
    {
        [Key]
        public int identifiant { get; set; }
        [Required(ErrorMessage ="veuiller insert votre login")]
        public string login { get; set; }
        [Required,DataType(DataType.Password)]
        public string password{ get; set; }
        public string photo { get; set; }
        public int? ConseillerFK { get; set; }
        public Conseiller Conseiller { get; set; }
        public IList<Reservation> Reservations { get; set; }

    }

}
