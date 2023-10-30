using Library.API.Data.Models;
using Library.API.Data.Services;
using LibraryApp.Controllers;
using LibraryApp.Data.MockData;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace LibraryApp.Test
{
    public class BookControllerTest
    {
        [Fact]
        public void IndexUnitTest()
        {
            //arrange
            var mockRepo = new Mock<IBookService>();
            mockRepo.Setup(n => n.GetAll()).Returns(MockData.GetTestBookItems());
            var controller = new BooksController(mockRepo.Object);

            //act
            var result = controller.Index();

            //assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var viewResultBooks = Assert.IsAssignableFrom<List<Book>>(viewResult.ViewData.Model);
            Assert.Equal(5, viewResultBooks.Count);
        }
    }
}