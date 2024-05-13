using EX.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX.Data
{
    public class Configuration : IEntityTypeConfiguration<CLient>
    {
        public void Configure(EntityTypeBuilder<CLient> builder)
        {
            builder.HasOne(a => a.Conseiller)
                .WithMany(ar => ar.clients)
                .HasForeignKey(a => a.ConseillerFK)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
