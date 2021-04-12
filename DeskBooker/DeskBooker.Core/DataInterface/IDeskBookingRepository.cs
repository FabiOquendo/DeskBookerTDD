using DeskBooker.Core.Domain;
using System.Collections.Generic;

namespace DeskBooker.Core.DataInterface
{
    public interface IDeskBookingRepository
    {
        void Save(DeskBooking deskBooking);
        IEnumerable<DeskBooking> GetAll();
    }
}
