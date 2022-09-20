using AutoFixture;
using Bogus;
using E_Learning_API.Controllers;
using E_Learning_API.Interfaces;
using E_Learning_API.Models;
using E_Learning_API.Tests.Helpers;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace E_Learning_API.Tests.System;

public class CourseControllerTest
{
    [Fact]
    public async Task Get_ListCourse_ShouldReturn200OKAsync()
    {
        // Arrange 
        var fixture = FixturesServices.GetFixture();
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

    [Fact]
    public async Task GetValue_OneCourse_ShouldReturn200OKAsync()
    {
        // Arrange 
        const int TEST_ID = 1;
        var courseMoq = new Mock<ICourseRepository>();
        var courseController = new CoursesController(courseMoq.Object);

        // Act
        courseMoq.Setup(x => x.GetByIdAsyncUntracked(TEST_ID)).ReturnsAsync(new Course());
        var result = await courseController.Get(TEST_ID);
        var obj = result as ObjectResult;

        // Assert
        Assert.Equal(200, obj.StatusCode);
    }

    [Fact]
    public async void GetValue_NoCourse_ShouldReturn404NotFound()
    {
        // Arrange 
        const int TEST_ID = 1;
        var courseMoq = new Mock<ICourseRepository>();
        var courseController = new CoursesController(courseMoq.Object);
        Course? noFindObject = null;

        // Act
        courseMoq.Setup(x => x.GetByIdAsyncUntracked(TEST_ID)).ReturnsAsync(noFindObject); 
        var result = await courseController.Get(TEST_ID);
        var obj = result as NotFoundResult;

        // Assert
        Assert.Equal(404, obj.StatusCode);
    }

    //[Fact]
    //public async void Post_AddPost_ShouldReturn201Created()
    //{
    //    // Arrange 

    //    var courseMoq = new Mock<ICourseRepository>();
    //    var courseController = new CoursesController(courseMoq.Object);
    //    Course? noFindObject = null;

    //    // Act
    //    courseMoq.Setup(x => x.GetByIdAsyncUntracked(TEST_ID)).ReturnsAsync(noFindObject);
    //    var result = await courseController.Get(TEST_ID);
    //    var obj = result as NotFoundResult;

    //    // Assert
    //    Assert.Equal(404, obj.StatusCode);
    //}

}