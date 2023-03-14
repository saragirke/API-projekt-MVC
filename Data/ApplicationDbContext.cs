using AdminPoodle.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AdminPoodle.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<News> News { get; set; }  = default!;
    public DbSet<Interest> Interest { get; set; }  = default!;
    public DbSet<AdminPoodle.Models.Pup> Pup { get; set; } = default!;
    public DbSet<AdminPoodle.Models.Buyer> Buyer { get; set; } = default!;
}
