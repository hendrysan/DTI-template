using DTI.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DTI.Contexts
{
    public class ConnectionContext : DbContext
    {
        public DbSet<Society> Societies { get; set; }
        public DbSet<FileDetail> FileDetails { get; set; }

        protected readonly IConfiguration _configuration;
        public ConnectionContext(DbContextOptions<ConnectionContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {

            string mySqlConnection = _configuration.GetConnectionString("MySQLConnection");
            options.UseMySQL(mySqlConnection);

        }

        
    }
}
