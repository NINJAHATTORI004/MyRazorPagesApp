using Microsoft.AspNetCore.Mvc;
using ConferenceRoomBooking.Services;
using System.Threading.Tasks;

namespace ConferenceRoomBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookRoomController : ControllerBase
    {
        private readonly BookingService _bookingService;

        public BookRoomController(BookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BookingModel booking)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _bookingService.BookRoomAsync(booking);

            if (result)
            {
                return Ok("Booking successful");
            }
            else
            {
                return StatusCode(500, "An error occurred while processing your request");
            }
        }
    }
}