using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GinasioIsla.Models;

namespace GinasioIsla.Data
{
    public class GinasioContext : DbContext
    {
        public GinasioContext (DbContextOptions<GinasioContext> options)
            : base(options)
        {
        }

        public DbSet<GinasioIsla.Models.Aluno> Aluno { get; set; } = default!;

        public DbSet<GinasioIsla.Models.Modalidade> Modalidade { get; set; }

        public DbSet<GinasioIsla.Models.Inscricao> Inscricao { get; set; }
    }
}
