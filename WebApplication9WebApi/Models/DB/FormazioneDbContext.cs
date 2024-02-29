using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApplication9WebApi.Models.DB;

public partial class FormazioneDbContext : DbContext
{
    public FormazioneDbContext()
    {
    }

    public FormazioneDbContext(DbContextOptions<FormazioneDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Comune> Comune { get; set; }

    public virtual DbSet<Persona> Persona { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(LocalDB)\\MSSQLLocalDB;Initial Catalog=FormazioneDb;Persist Security Info=False;MultipleActiveResultSets=False;Connection Timeout=30;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Persona>(entity =>
        {
            entity.HasOne(d => d.IdComuneNascitaNavigation).WithMany(p => p.Persona)
                .HasForeignKey(d => d.IdComuneNascita)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Persona_Comune");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
