using DeskBooker.Core.Domain;
using DeskBooker.Core.Processor;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DeskBooker.Web.Pages
{
    public class BookDeskModel : PageModel
    {
        private IDeskBookingRequestProcessor _deskBookingRequestProcessor;

        public BookDeskModel(IDeskBookingRequestProcessor deskBookingRequestProcessor)
        {
            _deskBookingRequestProcessor = deskBookingRequestProcessor;
        }

        [BindProperty]
        public DeskBookingRequest DeskBookingRequest { get; set; }

        public IActionResult OnPost()
        {
            IActionResult actionResult = Page();

            if(ModelState.IsValid)
            {
                var result = _deskBookingRequestProcessor.BookDesk(DeskBookingRequest);
                if (result.Code == DeskBookingResultCode.Success)
                {
                    actionResult = RedirectToPage("BookDeskConfirmation", new 
                    {
                        result.DeskBookingId,
                        result.FirstName,
                        result.Date
                    });
                }
                else if(result.Code == DeskBookingResultCode.NoDeskAvailable)
                {
                    ModelState.AddModelError("DeskBookingRequest.Date", "No desk available for selected date");
                }
            }

            return actionResult;
        }
    }
}