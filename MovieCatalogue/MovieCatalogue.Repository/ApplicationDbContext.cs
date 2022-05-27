
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieCatalogue.Domain.DomainModels;
using MovieCatalogue.Domain.Identity;
using System;

namespace MovieCatalogue.Repository
{
    public class ApplicationDbContext : IdentityDbContext<CatalogueUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<PersonRole> PersonRoles { get; set; }
        public virtual DbSet<MovieGenre> MovieGenres { get; set; }
        public virtual DbSet<MoviePerson> MoviePeople { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            builder.Entity<Movie>()
                .Property(z => z.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<Genre>()
                .Property(z => z.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<Person>()
                .Property(z => z.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<Role>()
                .Property(z => z.Id)
                .ValueGeneratedOnAdd();




            builder.Entity<PersonRole>()
                .HasOne(z => z.Person)
                .WithMany(z => z.PersonRoles)
                .HasForeignKey(z => z.RoleId);

            builder.Entity<PersonRole>()
                .HasOne(z => z.Role)
                .WithMany(z => z.PersonRoles)
                .HasForeignKey(z => z.PersonId);


            builder.Entity<MovieGenre>()
                .HasOne(z => z.Movie)
                .WithMany(z => z.MovieGenres)
                .HasForeignKey(z => z.GenreId);

            builder.Entity<MovieGenre>()
              .HasOne(z => z.Genre)
              .WithMany(z => z.MovieGenres)
              .HasForeignKey(z => z.MovieId);


            builder.Entity<MoviePerson>()
              .HasOne(z => z.Movie)
              .WithMany(z => z.MoviePeople)
              .HasForeignKey(z => z.PersonId);

            builder.Entity<MoviePerson>()
              .HasOne(z => z.Person)
              .WithMany(z => z.MoviePeople)
              .HasForeignKey(z => z.MovieId);

        }
    }
}
