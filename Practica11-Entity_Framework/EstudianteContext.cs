using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica11_Entity_Framework
{
    public class EstudianteContext : DbContext
    {
        public DbSet<Estudiante> Estudiante { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LAPTOP-GKE3OSON\\SQLEXPRESS;Database=Progra2;Trusted_Connection=SSPI;MultipleActiveResultSets=True;TrustServerCertificate=True;");
        }



    }
}
