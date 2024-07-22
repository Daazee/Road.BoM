using Microsoft.EntityFrameworkCore;
using RoadBoM.Web.Models.Entities;
using System.Collections.Generic;

namespace RoadBoM.Web.Context
{
    public class RoadBoMContext : DbContext
    {
        public RoadBoMContext(DbContextOptions<RoadBoMContext> options)
            : base(options)
        {

        }

        public DbSet<MeasurementBill> MeasurementBill { get; set; }
        public DbSet<Road> Road { get; set; }
        public DbSet<BillCategory> BillCategory { get; set; }
        public DbSet<BillItem> BillItem { get; set; }
        public DbSet<BillItemRate> BillItemRate { get; set; }
    }
}
