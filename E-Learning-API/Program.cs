using E_Learning_API.Data;
using E_Learning_API.Faker;
using E_Learning_API.Interfaces;
using E_Learning_API.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<ICourseRepository, CoursesRepository>();
builder.Services.AddScoped<ITagRepository, TagRepository>();
builder.Services.AddScoped<IAssignementRepository, AssignementRepository>();
builder.Services.AddDbContext<ElearningDataContext>(s => s.UseNpgsql(builder.Configuration.GetConnectionString("ElearningDB")));


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

WebApplication app = builder.Build();
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

//if (args.Length == 1 && args[0].ToLower() == "seed")
//{
//    await FakeCourses.SetFakeCourses(app, 5);
//}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

