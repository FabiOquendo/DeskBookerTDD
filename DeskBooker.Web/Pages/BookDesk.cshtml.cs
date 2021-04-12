using DeskBooker.Core.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DeskBooker.Web.Pages
{
  public class BookDeskModel : PageModel
  {
    [BindProperty]
    public DeskBookingRequest DeskBookingRequest { get; set; }

    public void OnPost()
    {
      
    }
  }
}