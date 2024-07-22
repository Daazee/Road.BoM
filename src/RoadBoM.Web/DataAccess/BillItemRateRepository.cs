using RoadBoM.Web.Context;
using RoadBoM.Web.Models.Entities;
using RoadBoM.Web.Repository;

namespace RoadBoM.Web.DataAccess
{
    public class BillItemRateRepository : BaseRepository<BillItemRate>, IBillItemRateRepository
    {
        private RoadBoMContext context;
        public BillItemRateRepository(RoadBoMContext context) : base(context)
        {
            this.context = context;
        }
    }
}
