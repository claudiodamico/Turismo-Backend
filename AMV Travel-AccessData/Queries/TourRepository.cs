using AMV_Travel_AccessData.Data;
using AMV_Travel_Domain.Commands;
using AMV_Travel_Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AMV_Travel_AccessData.Queries
{
    public class TourRepository : ITourRepository
    {
        private readonly AMV_TravelDbContext _context;

        public TourRepository(AMV_TravelDbContext context)
        {
            _context = context;
        }
        public List<Tour> MostrarTours()
        {
            return _context.Tours.ToList();
        }

        void ITourRepository.AgregarTour(Tour tour)
        {
            _context.Tours.Add(tour);
            _context.SaveChanges();
        }

        public async Task<Tour> ObtenerTourPorId(int tourId)
        {
            return await _context.Tours
                                 .FirstOrDefaultAsync(t => t.Id == tourId);
        }

        public async Task<bool> EliminarTour(int Id)
        {
            var tour = await _context.Tours.FindAsync(Id);
            if (tour == null)
            {
                return false;  
            }

            _context.Tours.Remove(tour);
            await _context.SaveChangesAsync();
            return true;  
        }
    }
}
