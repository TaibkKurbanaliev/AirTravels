using AirTravels.Models;

namespace AirTravels.Interfaces
{
    public interface IPassangerRepository
    {
        Task<IEnumerable<Passanger>> GetAll();
        Task<Passanger> GetById(int? id);
        bool Add(Passanger passanger);
        bool Update(Passanger passanger);
        bool Delete(Passanger passanger);
        bool Save();
    }
}
