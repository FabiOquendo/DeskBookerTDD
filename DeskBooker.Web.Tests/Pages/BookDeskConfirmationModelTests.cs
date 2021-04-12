using System;
using Xunit;

namespace DeskBooker.Web.Pages
{
    public class BookDeskConfirmationModelTests
    {
        [Fact]
        public void ShouldStoreParameterValuesInProperties()
        {
            // Arrange
            const int deskBookingId = 7;
            const string firstName = "Fabio";
            var date = new DateTime(2020, 1, 28);

            var bookDeskConfirmationModel = new BookDeskConfirmationModel();

            // Act
            bookDeskConfirmationModel.OnGet(deskBookingId, firstName, date);

            // Assert
            Assert.Equal(deskBookingId, bookDeskConfirmationModel.DeskBookingId);
            Assert.Equal(firstName, bookDeskConfirmationModel.FirstName);
            Assert.Equal(date, bookDeskConfirmationModel.Date);
        }
    }
}
