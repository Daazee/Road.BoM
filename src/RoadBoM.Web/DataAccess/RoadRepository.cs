using RoadBoM.Web.Context;
using RoadBoM.Web.Models.Entities;
using RoadBoM.Web.Repository;

namespace RoadBoM.Web.DataAccess
{
    public class RoadRepository : BaseRepository<Road>, IRoadRepository
    {
        private RoadBoMContext context;
        public RoadRepository(RoadBoMContext context) : base(context)
        {
            this.context = context;
        }
    }
}
