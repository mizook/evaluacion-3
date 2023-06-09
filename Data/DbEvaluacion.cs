using eval_3.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Proxies;


namespace eval_3.Data
{
    public class DbEvaluacion : DbContext
    {
        // TABLAS DE NUESTRA DB
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookReservation> Book_reservations { get; set; }

       public DbEvaluacion(DbContextOptions<DbEvaluacion> options) : base(options)
        {
        }

        // Cargamos las navegaciones de datos
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies(); // Habilita la carga perezosa
        }

        // Creamos algunos datos semilla
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Usuarios
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    id = 1,
                    name = "Prof. Aleen Konopelski",
                    faculty = "Voluptatibus quia voluptatem quia nisi.",
                    date_last_reserve = DateTime.Parse("2023-06-09T23:37:54.000000Z"),
                    cant_reserves_last_mont = 1
                },
                new User
                {
                    id = 2,
                    name = "Antoinette Mayer",
                    faculty = "Animi laboriosam voluptatum assumenda odit.",
                    date_last_reserve = null,
                    cant_reserves_last_mont = 0
                },
                new User
                {
                    id = 3,
                    name = "Yvonne Terry",
                    faculty = "Et sed quos enim ut quis hic.",
                    date_last_reserve = DateTime.Parse("2023-06-08T23:37:54.000000Z"),
                    cant_reserves_last_mont = 1
                }
            );


            // Libros
            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    id = 1,
                    name = "Yvette Corwin V",
                    description = "Ea non nesciunt distinctio aspernatur eum id id.",
                },
                new Book
                {
                    id = 2,
                    name = "Felipa Lindgren DVM",
                    description = "Iure quibusdam aut quo qui pariatur eum libero."
                },
                new Book
                {
                    id = 3,
                    name = "Ollie Rowe",
                    description = "At velit et hic modi sunt iure consequatur."
                }
            );
            // Reservas de libros
            modelBuilder.Entity<BookReservation>().HasData(
                new BookReservation
                {
                    id = 1,
                    code = "cgLFZuT6Y8q7cf0byW",
                    user_id = 1,
                    book_id = 1,
                    date_reserve = DateTime.Parse("2023-06-09T23:37:54.000000Z"),
                },
                new BookReservation
                {
                    id = 2,
                    code = "6xvGgDMVCYy28epj83P9BUOd",
                    user_id = 3,
                    book_id = 2,
                    date_reserve = DateTime.Parse("2023-06-08T23:37:54.000000Z"),
                },
                new BookReservation
                {
                    id = 3,
                    code = "If0VJg6Py60FS2Er318",
                    user_id = 3,
                    book_id = 3,
                    date_reserve = DateTime.Parse("2023-06-08T23:37:54.000000Z"),
                }
            );
        }
    }
}