using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConferenceRoomBooking.Services
{
    public class BookingService
    {
        private readonly HttpClient _httpClient;
        private const string ApiUrl = "https://api.example.com/bookRoom";

        public BookingService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> BookRoomAsync(BookingModel booking)
        {
            var json = JsonSerializer.Serialize(booking);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(ApiUrl, content);

            return response.IsSuccessStatusCode;
        }
    }

    public class BookingModel
    {
        public string EmployeeName { get; set; }
        public DateTime BookingDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string RoomNumber { get; set; }
        public string Notes { get; set; }
    }
}