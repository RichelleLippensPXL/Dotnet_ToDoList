namespace ToDoListApp.Domain.Tests
{
    [TestFixture]
    public class ToDoListTests
    {
        [Test]
        public void CreateNew_ValidTitle_ShouldReturnNewListWithIdAndTitle()
        {
            // Arrange / Act
            var toDoList = ToDoList.CreateNew("title");

            //Assert
            Assert.That(toDoList.Id, Is.Not.EqualTo(Guid.Empty));
            Assert.That(toDoList.Title, Is.EqualTo("title"));
        }
        [Test]
        public void CreateNew_TitleIsNullOrEmpty_ShouldThrowArgumentException()
        {
            // Arrange / Act /Assert
            Assert.That(() => ToDoList.CreateNew(""), Throws.TypeOf<ArgumentException>());
            Assert.That(() => ToDoList.CreateNew(null), Throws.TypeOf<ArgumentException>());
        }
    }
}