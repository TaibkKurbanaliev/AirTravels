using AirTravels.Data;
using AirTravels.Interfaces;
using AirTravels.Models;
using Microsoft.EntityFrameworkCore;

namespace AirTravels.Repository
{
    public class TicketRepository : ITicketRepository
    {
        private readonly AirTravelContext _context;

        public TicketRepository(AirTravelContext context)
        {
            _context = context;
        }

        public bool Add(Ticket ticket)
        {
            _context.Add(ticket);
            return Save();
        }

        public bool Delete(Ticket ticket)
        {
            _context.Remove(ticket);
            return Save();
        }

        public async Task<IEnumerable<Ticket>> GetAll()
        {
            return await _context.Tickets.ToListAsync();
        }

        public async Task<Ticket> GetFullInfoByIdAsync(int? id)
        {
            return await _context.Tickets.FirstOrDefaultAsync(i => i.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0;
        }

        public bool Update(Ticket ticket)
        {
            _context.Update(ticket);
            return Save();
        }
    }
}
