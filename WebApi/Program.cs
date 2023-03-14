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
                Name = "�",
                Description = "�������"
            },
            new Gender()
            {
                Name = "�",
                Description = "�������"
            },
            new Gender()
            {
                Name = "s",
                Description = "����������� ����"
            },
        };

        var cities = new List<City>()
        {
            new City()
            {
                Name = "������"
            },
            new City()
            {
                Name = "���"
            }
        };

        var interests = new List<Interest>()
        {
            new Interest()
            {
                Name = "���������"
            },
            new Interest()
            {
                Name = "������ �������� �������� � ���������"
            },
            new Interest()
            {
                Name = "��������"
            }
        };

        var users = new List<User>()
        {
            new User()
            {
                NameFirst = "����",
                DateOfBirth = new DateTime(1, 1, 1),
                Gender = genders[0],
                City = cities[0]
            },
            new User()
            {
                NameFirst = "���",
                DateOfBirth = new DateTime(2, 1, 1),
                Gender = genders[1],
                City = cities[0]
            },
            new User()
            {
                NameFirst = "����",
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