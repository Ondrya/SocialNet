using Domain.Models;
using Persistence;
using System.Runtime.CompilerServices;

Console.WriteLine("Hello, World!");


InsertData();
PrintData();


void InsertData()
{
    using (var context = new SocialContext())
    {
        // Creates the database if not exists
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        var genders = new List<Gender>()
        {
            new Gender()
            {
                Name = "М",
                Description = "мужчина"
            },
            new Gender()
            {
                Name = "Ж",
                Description = "женщина"
            },
            new Gender()
            {
                Name = "s",
                Description = "сферический конь"
            },
        };

        var cities = new List<City>()
        {
            new City()
            {
                Name = "Москва"
            },
            new City()
            {
                Name = "СПб"
            }
        };

        var interests = new List<Interest>()
        {
            new Interest()
            {
                Name = "Плодиться"
            },
            new Interest()
            {
                Name = "Давать названия жтвотным и растениям"
            },
            new Interest()
            {
                Name = "Искушать"
            }
        };

        var users = new List<User>()
        {
            new User() 
            {
                NameFirst = "Адам",
                DateOfBirth = new DateTime(1, 1, 1),
                Gender = genders[0],
                City = cities[0]
            },
            new User() 
            {
                NameFirst = "Ева",
                DateOfBirth = new DateTime(2, 1, 1),
                Gender = genders[1],
                City = cities[0]
            },
            new User()
            {
                NameFirst = "Змей",
                DateOfBirth = new DateTime(3, 1, 1),
                Gender = genders[2],
                City = cities[0]
            },
        };

        context.AddRange(genders);
        context.AddRange(cities);
        context.AddRange(interests);
        context.AddRange(users);

        // Saves changes
        context.SaveChanges();
    }
}


void PrintData()
{
    using (var context = new SocialContext())
    {
        var genders     = context.Genders.ToList();
        var cities      = context.Cities.ToList();
        var interests   = context.Interests.ToList();

        Console.WriteLine(nameof(genders));
        foreach (var item in genders) 
            Console.WriteLine($"{item.Id} --- {item.Name}");
        Console.WriteLine(nameof(cities));
        foreach (var item in cities)
            Console.WriteLine($"{item.Id} --- {item.Name}");
        Console.WriteLine(nameof(interests));
        foreach (var item in interests)
            Console.WriteLine($"{item.Id} --- {item.Name}");

    }
}