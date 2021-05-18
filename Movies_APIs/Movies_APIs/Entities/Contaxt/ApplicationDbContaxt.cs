using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace Movies_APIs.Entities.Contaxt
{
    public class ApplicationDbContaxt :DbContext
    {

        public ApplicationDbContaxt(DbContextOptions<ApplicationDbContaxt> options):base(options)
        {

        }


        public DbSet<Genres> Genres { get; set; }

        public DbSet<Actor> Actors { get; set; }
    }
}
