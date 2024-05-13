using EX.Core.Domain;
using EX.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX.Core.Services
{
    public class ConseillerService : Service<Conseiller>, IConseiller
    {
        public ConseillerService(IUnitOfWork uow) : base(uow)
        {
        }
    }
}
