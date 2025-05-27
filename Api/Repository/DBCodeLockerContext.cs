using Api.Models;
using Microsoft.EntityFrameworkCore;
using MySqlX.XDevAPI;

namespace Api.Repository
{
    public class DBCodeLockerContext : DbContext
    {
        public DBCodeLockerContext(DbContextOptions<DBCodeLockerContext> options) : base(options)
        {
        }
        public DbSet<Usuario> usuario { get;set; }
    }
}