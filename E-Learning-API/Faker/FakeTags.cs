using Bogus;
using Bogus.Extensions;

using E_Learning_API.Data;
using E_Learning_API.Models;
using E_Learning_API.Models.Enum;

namespace E_Learning_API.Faker;

public class FakeTags
{
    public static void SetFakeTags(IApplicationBuilder appB, int n)
    {
        using var serviceScope = appB.ApplicationServices.CreateScope();
        var context = serviceScope.ServiceProvider.GetService<ElearningDataContext>();

        if (context is not null)
        {
            var tagFaker = new Faker<Tag>()
                .RuleFor(x => x.Name, x => x.Lorem.Word());

            var tags = Enumerable.Range(1, n)
                .Select(_ => tagFaker.Generate())
                .ToList();

            context.AddRange(tags);
            context.SaveChangesAsync();

        }
    }
}

