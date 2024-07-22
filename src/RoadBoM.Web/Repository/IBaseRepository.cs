namespace RoadBoM.Web.Repository
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> GetItem(int id);
        Task<IEnumerable<T>> GetItems();
        Task<T> AddItem(T item);
        Task<T> UpdateItem(T item);
        Task<T> RemoveItem(int id);
    }
}
