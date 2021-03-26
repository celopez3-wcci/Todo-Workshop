using System;
using System.Collections.Generic;
using System.Text;
using todos.Models;
using Xunit;

namespace todos.Tests
{
    public class TodoTest
    {
        Todo sut;

        public TodoTest()
        {
            sut = new Todo();
            sut.Id = 1;
            sut.Name = "";
            sut.CreatedOn = DateTime.Now;
        }

        [Fact]
        public void Todo_Sets_Name_On_TodoModel()
        {
            // Arrange
            // Act
            string name = sut.Name;
            // Assert

            Assert.Equal("", name);
        }

    }
}
