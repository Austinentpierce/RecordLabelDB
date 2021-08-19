using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;


namespace RecordLabelDB
{
    class RecordLabelDBContext : DbContext
    {
        public Dbset<Band> Band { get; set; }
        public Dbset<Album> Album { get; set; }
        public Dbset<Songs> Songs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("server=localhost;database=RecordLabelDB");

            //var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
            //optionsBuilder.UseLoggerFactory(loggerFactory);
        }
    }
}