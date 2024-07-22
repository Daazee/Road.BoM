using RoadBoM.Web.Context;
using RoadBoM.Web.Models.Entities;
using RoadBoM.Web.Repository;

namespace RoadBoM.Web.DataAccess
{
    public class MeasurementBillRepository : BaseRepository<MeasurementBill>, IMeasurementBillRepository
    {
        private RoadBoMContext context;
        public MeasurementBillRepository(RoadBoMContext context) : base(context)
        {
            this.context = context;
        }
    }
}
