using DeskBooker.Core.DataInterface;
using DeskBooker.Core.Domain;
using System.Collections.Generic;
using System.Linq;

namespace DeskBooker.DataAccess.Repositories
{
    public class DeskBookingRepository : IDeskBookingRepository
    {
        private readonly DeskBookerContext _context;

        public DeskBookingRepository(DeskBookerContext context)
        {
            _context = context;
        }

        public IEnumerable<DeskBooking> GetAll()
        {
            return _context.DeskBooking.OrderBy(x => x.Date).ToList();
        }

        public void Save(DeskBooking deskBooking)
        {
            _context.DeskBooking.Add(deskBooking);
            _context.SaveChanges();
        }
    }
}