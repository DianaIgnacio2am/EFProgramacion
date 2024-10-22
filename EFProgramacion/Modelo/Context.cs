using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace EFProgramacion.Modelo
{
    public class Context : DbContext
    {
        public DbSet<Drogueria> Droguerias { get; set; }
        public DbSet<Medicamento> Medicamentos { get; set; }
        public DbSet<Monodroga> Monodrogas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // Configura la cadena de conexión a la base de datos
            options.UseSqlServer("YourConnectionStringHere");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de la entidad Drogueria
            modelBuilder.Entity<Drogueria>(entity =>
            {
                entity.HasKey(e => e.Id); // Define la clave primaria

                entity.Property(e => e.Nombre)
                    .IsRequired() // Este campo es obligatorio
                    .HasMaxLength(100); // Longitud máxima
            });

            // Configuración de la entidad Medicamento
            modelBuilder.Entity<Medicamento>(entity =>
            {
                entity.HasKey(e => e.Id); // Define la clave primaria

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(150);


                // Asumimos que hay una relación con Drogueria
                entity.HasOne(d => d.Drogueria)
                    .WithMany(d => d.Medicamentos)
                    .HasForeignKey(d => d.DrogueriaId); // Define la clave foránea
            });

            // Configuración de la entidad Monodroga
            modelBuilder.Entity<Monodroga>(entity =>
            {
                entity.HasKey(e => e.Id); // Define la clave primaria

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100);
            });
        }
    }
}