using RoadBoM.Web.Context;
using RoadBoM.Web.Models.Entities;
using RoadBoM.Web.Repository;

namespace RoadBoM.Web.DataAccess
{
    public class BillCategoryRepository : BaseRepository<BillCategory>, IBillCategoryRepository
    {
        private RoadBoMContext context;
        public BillCategoryRepository(RoadBoMContext context) : base(context)
        {
            this.context = context;
        }
    }
}
