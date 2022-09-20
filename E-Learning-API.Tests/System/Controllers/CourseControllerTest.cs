using AutoFixture;
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
    public async void Get_ListCourse_ShouldReturn200OKAsync()
    {
        // Arrange 
        var fixture = FixturesServices.GetFixture();
        var courseList = fixture.CreateMany<Course>(5).AsEnumerable();
        var courseMoq = new Mock<ICourseRepository>();
        var courseController = new CoursesController(courseMoq.Object);

        // Act
        courseMoq.Setup(repo => repo.GetAll()).ReturnsAsync(courseList);
        var result = await courseController.Get();
        var obj = result as ObjectResult;

        // Assert
        Assert.Equal(200, obj!.StatusCode);
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
        var obj = result as StatusCodeResult;

        // Assert
        Assert.Equal(204, obj!.StatusCode);
    }

    [Fact]
    public async void GetValue_OneCourse_ShouldReturn200OKAsync()
    {
        // Arrange 
        const int TEST_ID = 1;
        var courseMoq = new Mock<ICourseRepository>();
        var courseController = new CoursesController(courseMoq.Object);
        var fakeCourse = new Course();
        // Act
        courseMoq.Setup(x => x.GetByIdAsyncUntracked(TEST_ID)).ReturnsAsync(fakeCourse);
        var result = await courseController.Get(TEST_ID);
        var obj = result as ObjectResult;

        // Assert
        Assert.Equal(200, obj!.StatusCode);
    }

    [Fact]
    public async void GetValue_NoCourse_ShouldReturn404NotFound()
    {
        // Arrange 
        const int TEST_ID = 1;
        var courseMoq = new Mock<ICourseRepository>();
        var courseController = new CoursesController(courseMoq.Object);
        Course? noFindobject = null;

        // Act
        courseMoq.Setup(x => x.GetByIdAsyncUntracked(TEST_ID)).ReturnsAsync(noFindobject); 
        var result = await courseController.Get(TEST_ID);
        var obj = result as StatusCodeResult;

        // Assert
        Assert.Equal(404, obj!.StatusCode);
    }

    [Fact]
    public async void Post_AddPost_ShouldReturn201Created()
    {
        // Arrange 
        var fixture = FixturesServices.GetFixture();
        var courseMoq = new Mock<ICourseRepository>();
        var courseController = new CoursesController(courseMoq.Object);
        var course = fixture.Create<Course>();
        const bool ADD_RETURN_VALUE = true;

        // Act
        courseMoq.Setup(repo => repo.Add(It.IsAny<Course>())).ReturnsAsync(ADD_RETURN_VALUE);
        var result = await courseController.Post(course);
        var obj = result as CreatedAtActionResult;

        // Assert
        Assert.Equal(201, obj!.StatusCode);
    }

    [Fact]
    public async void Put_OneCourse_ShouldReturn204NoContent()
    {
        // Arrange 
        var courseMoq = new Mock<ICourseRepository>();
        var courseController = new CoursesController(courseMoq.Object);
        const bool UPDATE_RETURN_VALUE = true;
        const int TEST_ID = 1;
        var fakecourse = new Course()
        {
            Id = 1
        };

        // Act
        var result = await courseController.Put(TEST_ID, fakecourse);
        courseMoq.Setup(x => x.Update(fakecourse)).ReturnsAsync(UPDATE_RETURN_VALUE);
        var obj = result as StatusCodeResult;

        // Assert
        Assert.Equal(204, obj!.StatusCode);
    }

    [Fact]
    public async void Put_WrongCourse_ShouldReturn400BadRequest()
    {
        // Arrange 
        var courseMoq = new Mock<ICourseRepository>();
        var courseController = new CoursesController(courseMoq.Object);

        const int TEST_ID = 1;
        var fakecourse = new Course()
        {
            Id = 2
        };

        // Act;
        var result = await courseController.Put(TEST_ID,fakecourse);
        var obj = result as StatusCodeResult;

        // Assert
        Assert.Equal(400, obj!.StatusCode);
    }

    [Fact]
    public async void Delete_OneCourse_ShouldReturn204NoContent()
    {
        // Arrange 
        var courseMoq = new Mock<ICourseRepository>();
        var courseController = new CoursesController(courseMoq.Object);

        const int TEST_ID = 1;
        var fakecourse = new Course()
        {
            Id = 1
        };

        // Act;
        courseMoq.Setup(x => x.GetByIdAsyncUntracked(TEST_ID)).ReturnsAsync(fakecourse);
        var result = await courseController.Delete(TEST_ID, fakecourse);
        var obj = result as StatusCodeResult;

        // Assert
        Assert.Equal(204, obj!.StatusCode);
    }

    [Fact]
    public async void Delete_WrongCourse_ShouldReturn404NotFound()
    {
        // Arrange 
        var courseMoq = new Mock<ICourseRepository>();
        var courseController = new CoursesController(courseMoq.Object);

        const int TEST_ID = 1;
        var fakecourse = new Course()
        {
            Id = 1
        };
        Course? noFindobject = null;

        // Act
        courseMoq.Setup(x => x.GetByIdAsyncUntracked(TEST_ID)).ReturnsAsync(noFindobject);
        var result = await courseController.Delete(TEST_ID, fakecourse);
        var obj = result as StatusCodeResult;

        // Assert
        Assert.Equal(404, obj!.StatusCode);
    }

}