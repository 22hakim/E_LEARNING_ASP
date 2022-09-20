using AutoFixture;
using E_Learning_API.Controllers;
using E_Learning_API.Interfaces;
using E_Learning_API.Models;
using E_Learning_API.Tests.Helpers;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace E_Learning_API.Tests.System;

public class TagControllerTest
{
    [Fact]
    public async void Get_ListTags_ShouldReturn200OKAsync()
    {
        // Arrange 
        var fixture = FixturesServices.GetFixture();
        var tagList = fixture.CreateMany<Tag>(5).AsEnumerable();
        var tagMoq = new Mock<ITagRepository>();
        var tagController = new TagController(tagMoq.Object);

        // Act
        tagMoq.Setup(repo => repo.GetAll()).ReturnsAsync(tagList);
        var result = await tagController.Get();
        var obj = result as ObjectResult;

        // Assert
        Assert.Equal(200, obj!.StatusCode);
    }

    [Fact]
    public async void Get_EmptyListTag_ShouldReturn204NoContent()
    {

        // Arrange 
        var tagMoq = new Mock<ITagRepository>();
        var tagController = new TagController(tagMoq.Object);
        var tagList = new List<Tag>();

        // Act
        tagMoq.Setup(repo => repo.GetAll()).ReturnsAsync(tagList);
        var result = await tagController.Get();
        var obj = result as StatusCodeResult;

        // Assert
        Assert.Equal(204, obj!.StatusCode);
    }

    [Fact]
    public async void GetValue_Onetag_ShouldReturn200OKAsync()
    {
        // Arrange 
        const int TEST_ID = 1;
        var tagMoq = new Mock<ITagRepository>();
        var tagController = new TagController(tagMoq.Object);
        var fakeTag = new Tag();

        // Act
        tagMoq.Setup(x => x.GetByIdAsyncUntracked(TEST_ID)).ReturnsAsync(fakeTag);
        var result = await tagController.Get(TEST_ID);
        var obj = result as ObjectResult;

        // Assert
        Assert.Equal(200, obj!.StatusCode);
    }

    [Fact]
    public async void GetValue_Notag_ShouldReturn404NotFound()
    {
        // Arrange 
        const int TEST_ID = 1;
        var tagMoq = new Mock<ITagRepository>();
        var tagController = new TagController(tagMoq.Object);
        Tag? noFindObject = null;

        // Act
        tagMoq.Setup(x => x.GetByIdAsyncUntracked(TEST_ID)).ReturnsAsync(noFindObject);
        var result = await tagController.Get(TEST_ID);
        var obj = result as StatusCodeResult;

        // Assert
        Assert.Equal(404, obj!.StatusCode);
    }

    [Fact]
    public async void Post_AddPost_ShouldReturn201Created()
    {
        // Arrange 
        var fixture = FixturesServices.GetFixture();
        var tagMoq = new Mock<ITagRepository>();
        var tagController = new TagController(tagMoq.Object);
        var tag = fixture.Create<Tag>();
        const bool ADD_RETURN_VALUE = true;

        // Act
        tagMoq.Setup(repo => repo.Add(It.IsAny<Tag>())).ReturnsAsync(ADD_RETURN_VALUE);
        var result = await tagController.Post(tag);
        var obj = result as CreatedAtActionResult;

        // Assert
        Assert.Equal(201, obj!.StatusCode);
    }

    [Fact]
    public async void Put_Onetag_ShouldReturn204NoContent()
    {
        // Arrange 
        var tagMoq = new Mock<ITagRepository>();
        var tagController = new TagController(tagMoq.Object);
        const bool UPDATE_RETURN_VALUE = true;
        const int TEST_ID = 1;
        var faketag = new Tag()
        {
            Id = 1
        };

        // Act
        var result = await tagController.Put(TEST_ID, faketag);
        tagMoq.Setup(x => x.Update(faketag)).ReturnsAsync(UPDATE_RETURN_VALUE);
        var obj = result as StatusCodeResult;

        // Assert
        Assert.Equal(204, obj!.StatusCode);
    }

    [Fact]
    public async void Put_Wrongtag_ShouldReturn400BadRequest()
    {
        // Arrange 
        var tagMoq = new Mock<ITagRepository>();
        var tagController = new TagController(tagMoq.Object);

        const int TEST_ID = 1;
        var faketag = new Tag()
        {
            Id = 2
        };

        // Act;
        var result = await tagController.Put(TEST_ID, faketag);
        var obj = result as StatusCodeResult;

        // Assert
        Assert.Equal(400, obj!.StatusCode);
    }

    [Fact]
    public async void Delete_Onetag_ShouldReturn204NoContent()
    {
        // Arrange 
        var tagMoq = new Mock<ITagRepository>();
        var tagController = new TagController(tagMoq.Object);

        const int TEST_ID = 1;
        var faketag = new Tag()
        {
            Id = 1
        };

        // Act;
        tagMoq.Setup(x => x.GetByIdAsyncUntracked(TEST_ID)).ReturnsAsync(faketag);
        var result = await tagController.Delete(TEST_ID);
        var obj = result as StatusCodeResult;

        // Assert
        Assert.Equal(204, obj!.StatusCode);
    }

    [Fact]
    public async void Delete_Wrongtag_ShouldReturn404NotFound()
    {
        // Arrange 
        var tagMoq = new Mock<ITagRepository>();
        var tagController = new TagController(tagMoq.Object);

        const int TEST_ID = 1;
        var faketag = new Tag()
        {
            Id = 1
        };
        Tag? noFindObject = null;

        // Act
        tagMoq.Setup(x => x.GetByIdAsyncUntracked(TEST_ID)).ReturnsAsync(noFindObject);
        var result = await tagController.Delete(TEST_ID);
        var obj = result as StatusCodeResult;

        // Assert
        Assert.Equal(404, obj!.StatusCode);
    }

}
