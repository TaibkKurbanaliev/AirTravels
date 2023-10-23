using AirTravels.Data;
using AirTravels.Interfaces;
using AirTravels.Models;
using Microsoft.EntityFrameworkCore;

namespace AirTravels.Repository
{
    public class PassangerRepository : IPassangerRepository
    {
        private readonly AirTravelContext _context;
        public PassangerRepository(AirTravelContext context)
        {
            _context = context;
        }

        public bool Add(Passanger passanger)
        {
            _context.Add(passanger);
            return Save();
        }

        public bool Delete(Passanger passanger)
        {
            _context.Remove(passanger);
            return Save();
        }

        public async Task<IEnumerable<Passanger>> GetAll()
        {
            return await _context.Passangers.ToListAsync();
        }

        public async Task<Passanger> GetById(int? id)
        {
            return await _context.Passangers.Include(x => x.Tickets).FirstOrDefaultAsync(passanger => passanger.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0;
        }

        public bool Update(Passanger passanger)
        {
            _context.Update(passanger);
            return Save();
        }
    }
}
