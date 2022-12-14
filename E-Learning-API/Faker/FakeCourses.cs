using Bogus;
using Bogus.Extensions;

using E_Learning_API.Data;
using E_Learning_API.Models;
using E_Learning_API.Models.Enum;

namespace E_Learning_API.Faker;

public class FakeCourses
{

    public static void SetFakeCourses(IApplicationBuilder appB, int n)
    {
        using var serviceScope = appB.ApplicationServices.CreateScope();
        var context = serviceScope.ServiceProvider.GetService<ElearningDataContext>();

        if (context is not null)
        {
            var coursFaker = new Faker<Course>()
                .RuleFor(x => x.Title, x => x.Lorem.Sentence(new Random().Next(3, 8)))
                .RuleFor(x => x.CreatedAt, x => x.Date.Recent(4))
                .RuleFor(x => x.Content, x => x.Lorem.Lines(new Random().Next(1, 5)))
                .RuleFor(c => c.Published, f => f.PickRandom<Published>())
                .RuleFor(c => c.Level, f => f.PickRandom<LevelCourse>());

            var courses = Enumerable.Range(1, n)
                .Select(_ => coursFaker.Generate())
                .ToList();

            context.AddRange(courses);
            context.SaveChanges();

        }
    }
}

