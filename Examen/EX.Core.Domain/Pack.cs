using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX.Core.Domain
{
    public class Pack
    {
        public int packId { get; set; }
        public int nbPlaces { get; set; }
        public DateTime dateTime { get; set; }
        public int Duree { get; set; }
        public string intitulePack { get; set; }
        public IList<Reservation> reservations { get; set; }
        public IList<Activite> activites { get; set; }
    }
}
