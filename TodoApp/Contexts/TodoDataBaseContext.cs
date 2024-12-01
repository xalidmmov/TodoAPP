using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TodoApp.Models;

namespace TodoApp.Contexts;

public partial class TodoDataBaseContext : DbContext
{
    public TodoDataBaseContext()
    {
    }

    public TodoDataBaseContext(DbContextOptions<TodoDataBaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Todo> Todos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=ASUS\\SQLEXPRESS;Database=TodoDataBase;Trusted_Connection=True;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Todo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Todo__3214EC0790916AB9");

            entity.ToTable("Todo");

            entity.Property(e => e.Deadline).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Title).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
