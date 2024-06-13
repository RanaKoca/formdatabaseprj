using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace formdatabaseprj
{
    public class HastaContext:DbContext
    {
        public DbSet<Hastalar> Hastalar { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=LAPTOP-HT6NQQRD;Initial Catalog=DisKlinikDb;Integrated Security=True;Trust Server Certificate=True");
        }
    }
}
