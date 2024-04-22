using AMV_Travel_Domain.Entities;

namespace AMV_Travel_Domain.Commands
{
    public interface ITourRepository
    {
        List<Tour> MostrarTours();
        void AgregarTour(Tour tour);
        Task<Tour> ObtenerTourPorId(int tourId);
    }
}
