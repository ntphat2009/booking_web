namespace Booking.Infrastructure.DTOs
{
    public class CategoryDTO : BaseDTO
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required string Image { get; set; }
        public required string Icon { get; set; }
    }
}
