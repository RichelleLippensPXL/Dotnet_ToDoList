using static NUnit.Framework.Interfaces.TNode;

namespace ToDoListApp.Domain.Tests;

public class ToDoItemTests
{
    [Test]
    public void CreateNew_ValidDescription_ShouldReturnNewItem_ThatIsNotDone_AndWithIdAndDescription()
    {
        var sut = ToDoItem.CreateNew("tekst");
        Assert.That(sut.Id, Is.Not.EqualTo(Guid.Empty));
        Assert.That(sut.Description, Is.EqualTo("tekst"));
        Assert.That(sut.IsDone, Is.EqualTo(false));
    }
    [Test]
    public void CreateNew_DescriptionIsNullOrEmpty_ShouldThrowArgumentException()
    {
        // Arrange / Act /Assert
        Assert.That(() => ToDoItem.CreateNew(""), Throws.TypeOf<ArgumentException>());
        Assert.That(() => ToDoItem.CreateNew(null), Throws.TypeOf<ArgumentException>());
    }
}