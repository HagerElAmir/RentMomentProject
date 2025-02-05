
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Rent_A_Moment.Models;
using Rent_A_Moment.Dto;

namespace Rent_A_Moment.Entity
{
    public class AppDbContext :IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options) : base(options)
        {

        }
        public DbSet<Admin> Admins { get; set; }






        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderDetail> OderDetails { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Rent_A_Moment.Dto.LoginDto> LoginDto { get; set; } = default!;
        public DbSet<Rent_A_Moment.Dto.RegisterDto> RegisterDto { get; set; } = default!;

    }
}
