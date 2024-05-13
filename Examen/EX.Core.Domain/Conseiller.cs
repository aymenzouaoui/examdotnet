using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX.Core.Domain
{
   public class Conseiller
    {
       
        public int conseillerId { get; set; }
        public string conseillrName { get; set; }
        public string prenom { get; set; }
      public IList<CLient> clients { get; set; }
       
    }
}
