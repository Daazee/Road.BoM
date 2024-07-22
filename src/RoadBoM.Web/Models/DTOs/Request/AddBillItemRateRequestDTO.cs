namespace RoadBoM.Web.Models.DTOs.Request
{
    public class AddBillItemRateRequestDTO
    {
        public long BillItemId { get; set; }
        public string RateType { get; set; } = null!;
        public decimal Amount { get; set; }
        public string? Unit { get; set; }
        public decimal Order { get; set; }
    }
}
