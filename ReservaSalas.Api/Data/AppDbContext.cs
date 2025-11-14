using Microsoft.EntityFrameworkCore;
using ReservaSalas.Api.Models;

namespace ReservaSalas.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> opts) : base(opts) {}

    public DbSet<Location> Locations => Set<Location>();
    public DbSet<Room> Rooms => Set<Room>();
    public DbSet<Reservation> Reservations => Set<Reservation>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Location>().HasKey(l => l.Id);
        modelBuilder.Entity<Room>().HasKey(r => r.Id);
        modelBuilder.Entity<Reservation>().HasKey(r => r.Id);

        modelBuilder.Entity<Room>()
            .HasOne(r => r.Location)
            .WithMany()
            .HasForeignKey(r => r.LocationId);

        modelBuilder.Entity<Reservation>()
            .HasOne(r => r.Location)
            .WithMany()
            .HasForeignKey(r => r.LocationId);

        modelBuilder.Entity<Reservation>()
            .HasOne(r => r.Room)
            .WithMany()
            .HasForeignKey(r => r.RoomId);

        modelBuilder.Entity<Reservation>()
            .HasIndex(r => new { r.RoomId, r.Start, r.End });
    }
}
