namespace RoadBoM.Web.Models.DTOs.Request
{
    public class AddBillItemRequestDTO
    {
        public string Code { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string? Unit { get; set; }
        public decimal Order { get; set; }
    }
}
