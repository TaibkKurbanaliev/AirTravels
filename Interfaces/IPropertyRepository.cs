namespace AirTravels.Interfaces
{
    public interface IPropertyRepository<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
    }
}
