namespace RoadBoM.Web.Models.DTOs.Request
{
    public class AddBillCategoryRequestDTO
    {
        public string Code { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Order { get; set; }
    }
}
