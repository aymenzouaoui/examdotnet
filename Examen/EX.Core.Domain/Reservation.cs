using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX.Core.Domain
{
    public class Reservation
    {
        public int ReservationId { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public DateTime dateReservation { get; set; }
        [Range(1, 4)]
        public int nbPersonnes { get; set; }
        public CLient cLient { get; set; }
        public int CLientId { get; set; }
        public Pack pack { get; set; }
    }
}
