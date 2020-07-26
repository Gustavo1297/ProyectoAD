using BackPrueba.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackPrueba.Context
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }
        /*Se van especificar las tablas que formara parte de nuestro context*/
        public DbSet<usuario> usuario { get; set; }
        
        public DbSet<perfiles> perfil { get; set; }
        /*Se nombra igual que la base para que no tenga problemas con la base de datos*/
    }
}
