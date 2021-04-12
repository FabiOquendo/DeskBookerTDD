using DeskBooker.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Xunit;

namespace DeskBooker.DataAccess.Repositories
{
    public class DeskBookingRepositoryTests
    {
        [Fact]
        public void ShouldSaveTheDeskBooking()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<DeskBookerContext>()
              .UseInMemoryDatabase(databaseName: "ShouldSaveTheDeskBooking")
              .Options;

            var deskBooking = new DeskBooking
            {
                FirstName = "Fabio",
                LastName = "Oquendo",
                Date = new DateTime(2021, 4, 10),
                Email = "fabio@oquendo.com",
                DeskId = 1
            };

            // Act
            using (var context = new DeskBookerContext(options))
            {
                var repository = new DeskBookingRepository(context);
                repository.Save(deskBooking);
            }

            // Assert
            using (var context = new DeskBookerContext(options))
            {
                var bookings = context.DeskBooking.ToList();
                var storedDeskBooking = Assert.Single(bookings);

                Assert.Equal(deskBooking.FirstName, storedDeskBooking.FirstName);
                Assert.Equal(deskBooking.LastName, storedDeskBooking.LastName);
                Assert.Equal(deskBooking.Email, storedDeskBooking.Email);
                Assert.Equal(deskBooking.DeskId, storedDeskBooking.DeskId);
                Assert.Equal(deskBooking.Date, storedDeskBooking.Date);
            }
        }

        [Fact]
        public void ShouldGetAllOrderedByDate()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<DeskBookerContext>()
              .UseInMemoryDatabase(databaseName: "ShouldGetAllOrderedByDate")
              .Options;

            var storedList = new List<DeskBooking>
      {
        CreateDeskBooking(1,new DateTime(2020, 1, 27)),
        CreateDeskBooking(2,new DateTime(2020, 1, 25)),
        CreateDeskBooking(3,new DateTime(2020, 1, 29))
      };

            var expectedList = storedList.OrderBy(x => x.Date).ToList();

            using (var context = new DeskBookerContext(options))
            {
                foreach (var deskBooking in storedList)
                {
                    context.Add(deskBooking);
                    context.SaveChanges();
                }
            }

            // Act
            List<DeskBooking> actualList;
            using (var context = new DeskBookerContext(options))
            {
                var repository = new DeskBookingRepository(context);
                actualList = repository.GetAll().ToList();
            }

            // Assert
            Assert.Equal(expectedList, actualList, new DeskBookingEqualityComparer());
        }

        private class DeskBookingEqualityComparer : IEqualityComparer<DeskBooking>
        {
            public bool Equals([AllowNull] DeskBooking x, [AllowNull] DeskBooking y)
            {
                return x.Id == y.Id;
            }

            public int GetHashCode([DisallowNull] DeskBooking obj)
            {
                return obj.Id.GetHashCode();
            }
        }

        private DeskBooking CreateDeskBooking(int id, DateTime dateTime)
        {
            return new DeskBooking
            {
                Id = id,
                FirstName = "Fabio",
                LastName = "Oquendo",
                Date = dateTime,
                Email = "fabio@oquendo.com",
                DeskId = 1
            };
        }
    }
}