using System;
using AutoFixture;
using E_Learning_API.Tests.Services;

namespace E_Learning_API.Tests.Helpers;

public class FixturesServices : IFixtures
{
    public static Fixture GetFixture()
    {
        Fixture fixture = new();
        fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
        fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        return fixture;
    }
}

