namespace YoutubeAPI.Services.Interfaces
{
    public interface IRepo<T, U>
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> CreateAsync(U item);
        Task<bool> UpdateAsync(T item);
        Task<bool> DeleteAsync(int id);
    }
}
