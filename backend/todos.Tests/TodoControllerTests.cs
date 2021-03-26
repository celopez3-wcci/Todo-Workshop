using NSubstitute;
using System;
using System.Collections.Generic;
using System.Text;
using todos.Controllers;
using todos.Models;
using todos.Repositories;
using Xunit;

namespace todos.Tests
{
    public class TodoControllerTests
    {
        TodoController sut;
        IRepository<Todo> todoRepo;

        public TodoControllerTests()
        {
            todoRepo = Substitute.For<IRepository<Todo>>();
            sut = new TodoController(todoRepo);
        }

        [Fact]
        public void GetTodos_Returns_A_List()
        {
            // Arrange
            IEnumerable<Todo> expectedList = new List<Todo>();
            todoRepo.GetAll().Returns(expectedList);

            // Act
            var result = sut.GetTodos();

            //Assert 
            Assert.Equal(expectedList, result);

        }

        [Fact]
        public void GetTodo_Returns_A_Todo()
        {
            // Arrange
            var expectedTodo = new Todo();
            todoRepo.GetById(1).Returns(expectedTodo);

            // Assert
            var result = sut.GetTodo(1);

            // Act
            Assert.Equal(expectedTodo, result);
        }

    }
}
