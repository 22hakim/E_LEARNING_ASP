using System;
using AutoFixture;
using E_Learning_API.Tests.Services;

namespace E_Learning_API.Tests.Helpers;

public class FixturesServices : IFixtures
{
    public static Fixture? _fixture = null; 

    public static Fixture GetFixture()
    {
        if (_fixture is not null)
            return _fixture;

        
        _fixture = new();
        _fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
        _fixture.Behaviors.Add(new OmitOnRecursionBehavior());

        return _fixture;
    }
}

