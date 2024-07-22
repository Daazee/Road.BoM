﻿namespace RoadBoM.Web.Models.DTOs.Response
{
    public class GetBillItemResponseDTO
    {
        public long Id { get; set; }
        public string Code { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string? Unit { get; set; }
        public decimal Order { get; set; }
        public int Status { get; set; }
        public string CreatedBy { get; set; } = null!;

        public DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; } = null!;
        public DateTime UpdatededOn { get; set; }
    }
}
