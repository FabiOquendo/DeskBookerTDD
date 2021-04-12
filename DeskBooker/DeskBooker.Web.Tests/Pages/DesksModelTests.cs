using DeskBooker.Core.DataInterface;
using DeskBooker.Core.Domain;
using Moq;
using Xunit;

namespace DeskBooker.Web.Pages
{
    public class DesksModelTests
    {
        [Fact]
        public void ShouldGetAllDesks()
        {
            // Arrange
            var desks = new[]
            {
                new Desk(),
                new Desk(),
                new Desk(),
            };

            var deskRepositoryMock = new Mock<IDeskRepository>();
            deskRepositoryMock.Setup(x => x.GetAll())
                .Returns(desks);

            var desksModel = new DesksModel(deskRepositoryMock.Object);

            // Act
            desksModel.OnGet();

            // Assert
            Assert.Equal(desks, desksModel.Desks);
        }
    }
}
