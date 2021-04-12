using DeskBooker.Core.DataInterface;
using DeskBooker.Core.Domain;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace DeskBooker.Web.Pages
{
  public class DeskBookingsModel : PageModel
  {
    private readonly IDeskBookingRepository _deskBookingRepository;

    public DeskBookingsModel(IDeskBookingRepository deskBookingRepository)
    {
      _deskBookingRepository = deskBookingRepository;
    }

    public IEnumerable<DeskBooking> DeskBookings { get; set; }

    public void OnGet()
    {
      DeskBookings = _deskBookingRepository.GetAll();
    }
  }
}