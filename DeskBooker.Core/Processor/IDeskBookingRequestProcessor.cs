using DeskBooker.Core.Domain;

namespace DeskBooker.Core.Processor
{
    public interface IDeskBookingRequestProcessor
    {
        DeskBookingResult BookDesk(DeskBookingRequest request);
    }
}