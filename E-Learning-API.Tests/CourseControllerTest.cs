using AutoFixture;
using E_Learning_API.Controllers;
using E_Learning_API.Interfaces;
using E_Learning_API.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace E_Learning_API.Tests;

public class CourseControllerTest
{
    [Fact]
    public async Task Get_ListCourse_ShouldReturn200OKAsync()
    {
        // Arrange 
        Fixture fixture = new();
        fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
        fixture.Behaviors.Add(new OmitOnRecursionBehavior());

        var courseMoq = new Mock<ICourseRepository>();
        var courseList = fixture.CreateMany<Course>(5).AsEnumerable();
        var courseController = new CoursesController(courseMoq.Object);

        // Act
        courseMoq.Setup(repo => repo.GetAll()).ReturnsAsync(courseList);
        var result = await courseController.Get();
        var obj = result as ObjectResult;

        // Assert
        Assert.Equal(200, obj.StatusCode);
    }

    [Fact]
    public async void Get_EmptyListCourse_ShouldReturn204NoContent()
    {

        // Arrange 
        var courseMoq = new Mock<ICourseRepository>();
        var courseController = new CoursesController(courseMoq.Object);
        var courseList = new List<Course>();

        // Act
        courseMoq.Setup(repo => repo.GetAll()).ReturnsAsync(courseList);
        var result = await courseController.Get();
        var obj = result as NoContentResult;

        // Assert
        Assert.Equal(204, obj.StatusCode);
    }
}