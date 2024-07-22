using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace RoadBoM.Web.Models.Entities
{
    public class MeasurementBill
    {
        [Key]
        public long Id { get; set; }
        public decimal Quantity { get; set; }
        public long BillCategoryId { get; set; }
        public long BillItemId { get; set; }
        public int BillItemRateId { get; set; }

        public int CreatedFrom { get; set; }
        public int Status { get; set; }
        public string CreatedBy { get; set; } = null!;

        public DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set;} = null!;
        public DateTime UpdatededOn { get; set; }
    }
}
