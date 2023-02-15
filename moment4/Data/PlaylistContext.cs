namespace moment4.Data
{
    using Microsoft.AspNetCore.Connections;
    using Microsoft.EntityFrameworkCore;
    using moment4.Models;
    public class PlaylistContext : DbContext // Inherit from class DbContext
    {
        // Contructor with settings. Save PlaylistContext in variable options and send to base class
        public PlaylistContext(DbContextOptions<PlaylistContext> options) : base(options)
        {
        }

        // Link Context to Collection model and add name to database tables
        public DbSet<Song> Songs { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
