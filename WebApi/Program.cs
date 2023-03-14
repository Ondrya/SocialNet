using Application.Services;
using Domain.Models;
using Persistence;
using System.Configuration;

InsertData();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSingleton(new LoginServices());
builder.Services.AddSingleton(new UserService(builder.Configuration["ConnectionStrings:MySQL"]));


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


void InsertData()
{
    using (var context = new SocialContext())
    {
        // Creates the database if not exists
        // context.Database.EnsureDeleted();
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