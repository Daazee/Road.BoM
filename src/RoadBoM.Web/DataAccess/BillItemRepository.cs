using RoadBoM.Web.Context;
using RoadBoM.Web.Models.Entities;
using RoadBoM.Web.Repository;

namespace RoadBoM.Web.DataAccess
{
    public class BillItemRepository : BaseRepository<BillItem>, IBillItemRepository
    {
        private RoadBoMContext context;
        public BillItemRepository(RoadBoMContext context) : base(context)
        {
            this.context = context;
        }
    }
}
