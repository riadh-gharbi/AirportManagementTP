using AM.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Core.Service
{
    public interface IPlaneService
    {
        void Add(Plane p);
        void Delete(Plane p);
        IList<Plane> GetAll();

        IList<Passenger> GetPassengers(Plane p);

        /// <summary>
        /// Retour les vols des n avions les moins agés ordonnées par date de départ
        /// </summary>
        /// <returns></returns>
        IList<Flight> GetFlights(int numberOfPlanes);

        bool IsAvailable(int n, Flight flight);
        void DeleteUselessPlanes();
    }
}
