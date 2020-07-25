using Memory.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Memory.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Agent> Agents { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<MoneyTransferCategory> MoneyTransferCategories { get; set; }

        public DataContext() : base()
        {
        }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source= C:\\dev\\memory\\memory.db");

        public void OnAppStart(IServiceProvider serviceProvider)
        {
           // Database.Migrate();
        }
    }
}
