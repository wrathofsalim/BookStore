using BooksStore.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BooksStore.Data
{
    public static class DataSeeder
    {
        public static async Task Seed(this IApplicationBuilder app)
        {
            try
            {
                using var serviceScope = app.ApplicationServices.CreateScope();

                var context = serviceScope.ServiceProvider.GetRequiredService<BooksStoreDbContext>();

                if (context.Database.IsSqlServer())
                {
                    context.Database.Migrate();
                }

                await GenresSeeder(context);
                await AuthorsSeeder(context);

                await BooksSeeder(context);

                await context.SaveChangesAsync();

            }
            catch
            {
                throw new Exception(GlobalConstants.SeedingFailed);
            }
        }

        private static async Task GenresSeeder(BooksStoreDbContext context)
        {
            if (!context.Genres.Any())
            {
                var list = new List<Genre>()
                {
                    new Genre { Id = 1,Name = "Fantasy" },
                    new Genre { Id = 2,Name = "Biography" },
                    new Genre { Id = 3,Name = "Drama" },
                    new Genre { Id = 4,Name = "Fiction" },
                    new Genre { Id = 5,Name = "History" },
                    new Genre { Id = 6,Name = "Romance" },
                    new Genre { Id = 7,Name = "Teen" },
                    new Genre { Id = 8,Name = "Thriller" },
                    new Genre { Id = 9,Name = "Mystery" },
                    new Genre { Id = 10,Name = "Self-Help" },
                    new Genre { Id = 11,Name = "Poetry" },
                    new Genre { Id = 12,Name = "Novel" },
                    new Genre { Id = 13,Name = "Young adult" }
                };


                try
                {
                    context.Database.OpenConnection();
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Genres ON"); 

                    foreach (var genre in list)
                    {
                        context.Entry(genre).State = EntityState.Added;
                    }

                    await context.SaveChangesAsync();
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Genres OFF");
                }
                catch
                {
                    throw new Exception(GlobalConstants.SeedingBooksFailed);
                }
                finally
                {
                    context.Database.CloseConnection();
                }
            }
        }

        private static async Task AuthorsSeeder(BooksStoreDbContext context)
        {
            if (!context.Books.Any())
            {
                var list = new List<Author>()
                {
                    new Author{ Id = 1,Name = "Christie Golden"},
                    new Author{ Id = 2,Name = "Jeff Grubb"},
                    new Author{ Id = 3,Name = "Richard Knaak"},
                    new Author{ Id = 4,Name = "Stephen King" },
                    new Author{ Id = 5,Name = "J. K. Rowling" },
                    new Author{ Id = 6,Name = "J. R. R. Tolken"},
                    new Author{ Id = 7,Name = "Lewis Carroll"}
                };


                try
                {
                    context.Database.OpenConnection();
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Authors ON");

                    foreach (var author in list)
                    {
                        context.Entry(author).State = EntityState.Added;
                    }

                    await context.SaveChangesAsync();
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Authors OFF");
                }
                catch
                {
                    throw new Exception(GlobalConstants.SeedingBooksFailed);
                }
                finally
                {
                    context.Database.CloseConnection(); 
                }
            }
        }

        private static async Task BooksSeeder(BooksStoreDbContext context)
        {
            if (!context.Books.Any())
            {
                var list = new List<Book>()
                {
                    new Book()
                    {
                        Id = 1,
                        Title = "Warcraft: Day of the Dragon",
                        Price = 12.42m,
                        Description = "In the misty past, Azeroth was a realm of diverse " +
                        "creatures including Elves and Dwarves, until the demonic Burning Legion" +
                        " disrupted peace. Orcs, Dragons, Goblins, and Trolls now battle for dominance" +
                        " in a malevolent struggle that shapes the world's destiny.",
                        ImageUrl = "https://m.media-amazon.com/images/I/51BOgAuGTQL.jpg",
                        YearPublished = 2021,
                        AuthorId = 3,
                        GenreId = 1,
                    },
                    new Book()
                    {
                        Id= 2,
                        Title = "Warcraft: Lord of the Clans",
                        Description = "In the misty past of Azeroth, Elves and Dwarves " +
                        "coexisted in harmony until the arrival of the demonic Burning Legion" +
                        " shattered peace. Now, Orcs, Dragons, Goblins, and Trolls vie for dominance, " +
                        "shaping the world's fate, while the enigmatic Orc Thrall's life" +
                        " journey of honor, hatred, and hope unfolds.",
                        Price = 12.52m,
                        ImageUrl = "https://m.media-amazon.com/images/I/51MT4faXmZL.jpg",
                        YearPublished = 2018,
                        AuthorId = 1,
                        GenreId = 1,
                    },
                    new Book()
                    {
                        Id= 3,
                        Title = "Warcraft: The Last Guardian",
                        Price = 10.99m,
                        Description = "In the world of Azeroth, magical races unite " +
                        "until the malevolent Burning Legion led by Lord Sargeras triggers conflict; " +
                        "the Guardians of Tirisfal, champions with godlike powers, including Medivh," +
                        " battle the Legion, but his internal darkness alters Azeroth's destiny in" +
                        " \"The Last Guardian.\"",
                        ImageUrl = "https://m.media-amazon.com/images/I/51sEwIf8r0L._SX331_BO1,204,203,200_.jpg",
                        YearPublished = 2016,
                        AuthorId = 2,
                        GenreId = 1,
                    },
                    new Book()
                    {
                        Id = 4,
                        Title = "Harry Potter and the Sorcerer's Stone",
                        Price = 15.99m,
                        Description = "Follow the journey of a young wizard, Harry Potter, " +
                        "as he discovers his magical heritage and faces the challenges of the " +
                        "wizarding world, including the dark lord Voldemort.",
                        ImageUrl = "https://m.media-amazon.com/images/I/71-++hbbERL.jpg",
                        YearPublished = 1997,
                        AuthorId = 5,
                        GenreId = 1,
                    },
                    new Book() {
                        Id = 5,
                        Title = "Alice's Adventures in Wonderland",
                        Price = 8.75m,
                        Description = "Fall down the rabbit hole with Alice and experience " +
                        "a whimsical world filled with peculiar characters and nonsensical adventures.",
                        ImageUrl = "https://ik.imagekit.io/panmac/tr:f-auto,di-placeholder_portrait_aMjPtD9YZ.jpg,w-270/edition/9781447279990.jpg",
                        YearPublished = 1865,
                        AuthorId = 7,
                        GenreId = 1,
                    },
                    new Book()
                    {
                        Id = 6,
                        Title = "The Fellowship of the Ring",
                        Price = 14.25m,
                        Description = "Embark on an epic journey with Frodo Baggins and " +
                        "his companions as they set out to destroy the One Ring and thwart the " +
                        "dark lord Sauron's plans.",
                        ImageUrl = "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1654215925i/61215351.jpg",
                        YearPublished = 1954,
                        AuthorId = 6,
                        GenreId = 1,
                    }
                };

                try
                {
                    context.Database.OpenConnection();
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Books ON"); 

                    foreach (var book in list)
                    {
                        context.Entry(book).State = EntityState.Added; 
                    }

                    await context.SaveChangesAsync();
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Books OFF"); 
                }
                catch
                {
                    throw new Exception(GlobalConstants.SeedingBooksFailed);
                }
                finally
                {
                    context.Database.CloseConnection();
                }
            }
        }
    }
}
