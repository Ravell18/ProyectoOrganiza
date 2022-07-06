using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using OrganiZa.Domain.Entities;
using OrganiZa.Infraestructure.Data.Configurations;

#nullable disable

namespace OrganiZa.Infraestructure.Data
{
    public partial class OrganizarecContext : DbContext
    {
      

        public OrganizarecContext(DbContextOptions<OrganizarecContext> options): base(options)
        {

        }


        public virtual DbSet<Administrador> Administradors { get; set; }
        public virtual DbSet<Calendario> Calendarios { get; set; }
        public virtual DbSet<Escuela> Escuelas { get; set; }
        public virtual DbSet<Pago> Pagos { get; set; }
        public virtual DbSet<Tutor> Tutors { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          

        }
    }



}

