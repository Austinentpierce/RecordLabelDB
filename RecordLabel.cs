using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;


namespace RecordLabelDB
{
    public class RecordLabelDBContext : DbContext
    {
        public Dbset<Band> Band { get; set; }
        public Dbset<Album> Album { get; set; }
        public Dbset<Songs> Songs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("server=localhost;database=RecordLabelDB");
        }
    }
}