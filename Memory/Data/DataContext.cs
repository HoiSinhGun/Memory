using Memory.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Memory.Data
{
   public class DataContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Agent> Agents { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<MoneyTransferCategory> MoneyTransferCategories { get; set; }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=memory.db");
    }
}
