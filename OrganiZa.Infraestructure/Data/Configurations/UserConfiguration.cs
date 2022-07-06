using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrganiZa.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrganiZa.Infraestructure.Data.Configurations
{
    class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(e => e.Id)
            .HasMaxLength(500)
           .IsUnicode(false);
            builder.Property(e => e.Usuario)
            .HasMaxLength(500)
           .IsUnicode(false);
            builder.Property(e => e.Contraseña)
              .HasMaxLength(500)
             .IsUnicode(false);
            builder.Property(e => e.Rolusuario)
              .HasMaxLength(500)
             .IsUnicode(false);
            builder.Property(e => e.IdA)
            .HasMaxLength(500)
           .IsUnicode(false);
            builder.Property(e => e.IdT)
            .HasMaxLength(500)
           .IsUnicode(false);
            builder.Property(e => e.CreateAt).HasColumnType("datetime");
            builder.Property(e => e.Usuario)
            .HasMaxLength(250)
            .IsUnicode(false);
            builder.Property(e => e.Status).HasDefaultValueSql("((1))");
            builder.Property(e => e.UpdateAt).HasColumnType("datetime");
       

        }
    }
}
