using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace RoadBoM.Web.Models.Entities
{
    public class BillItemRate
    {
        [Key]
        public long Id { get; set; }
        public long BillItemId { get; set; }
        public string RateType { get; set; } = null!;
        public decimal Amount { get; set; }
        public int Status { get; set; }
        public string CreatedBy { get; set; } = null!;

        public DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; } = null!;
        public DateTime UpdatededOn { get; set; }
    }
}
