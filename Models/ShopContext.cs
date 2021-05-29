namespace EFCore
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;

    public class ShopContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder: optionsBuilder);
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=EFCore;Trusted_Connection=True");
            optionsBuilder.UseLoggerFactory(loggerFactory);
            optionsBuilder.UseLazyLoadingProxies();
        }

        public DbSet<Product> products { get; set; }
        public DbSet<Category> categories { get; set; }

        public static readonly ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddFilter(DbLoggerCategory.Query.Name, LogLevel.Information);
            // builder.AddFilter(DbLoggerCategory.Database.Name, LogLevel.Information);
            builder.AddConsole();
        });
    }
}