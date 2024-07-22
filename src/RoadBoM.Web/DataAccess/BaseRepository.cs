using Microsoft.EntityFrameworkCore;
using RoadBoM.Web.Context;
using RoadBoM.Web.Repository;

namespace RoadBoM.Web.DataAccess
{
    public class BaseRepository<T> : IDisposable, IBaseRepository<T> where T : class
    {
        private RoadBoMContext context;

        public BaseRepository(RoadBoMContext _context)
        {
            context = _context;
        }
        public async Task<T> GetItem(int id)
        {
            var model = await context.Set<T>().FindAsync(id);
            return model;
        }

        // gets list of items async
        public async Task<IEnumerable<T>> GetItems()
        {
            var result = await context.Set<T>().ToListAsync();
            return result;
        }


        public async Task<T> AddItem(T item)
        {
            try
            {
                context.Set<T>().Add(item);
                await context.SaveChangesAsync();
                return item;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        // updates an entity in a set
        public async Task<T> UpdateItem(T item)
        {
            context.Entry<T>(item).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return item;
        }

        // removes an entity in a set
        public async Task<T> RemoveItem(int id)
        {
            var query = await context.Set<T>().FindAsync(id);
            if (query != null)
            {
                context.Set<T>().Remove(query);
                await context.SaveChangesAsync();
            }
            return query;
        }


        public void Dispose()
        {
            context.Dispose();
        }
    }
}
