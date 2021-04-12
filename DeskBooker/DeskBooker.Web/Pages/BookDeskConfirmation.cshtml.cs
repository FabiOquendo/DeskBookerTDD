using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace DeskBooker.Web.Pages
{
  public class BookDeskConfirmationModel : PageModel
  {
    public int DeskBookingId { get; set; }

    public string FirstName { get; set; }

    public DateTime Date { get; set; }

    public void OnGet(int deskBookingId, string firstName, DateTime date)
    {
      DeskBookingId = deskBookingId;
      FirstName = firstName;
      Date = date;
    }
  }
}