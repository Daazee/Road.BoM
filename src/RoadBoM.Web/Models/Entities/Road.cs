using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace RoadBoM.Web.Models.Entities
{
    public class Road
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string Location { get; set; } = null!;
        public decimal Length { get; set; }

        public decimal Width { get; set; }

        public decimal Row { get; set; }

        public int Poles { get; set; }

        public string Type { get; set; } = null!;

        public int Culvert { get; set; }

        public int Outfall { get; set; }
        public int Status { get; set; }
        public string CreatedBy { get; set; } = null!;

        public DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set;} = null!;
        public DateTime UpdatededOn { get; set; }
    }
}
