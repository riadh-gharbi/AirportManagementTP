using AM.Core.Domain;
using AM.Core.Interface;
using AM.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Core.Service
{
    public class PlaneService : Service<Plane>,IPlaneService
    {
        //   IRepository<Plane> _repository;
        //   readonly IUnitOfWork unitOfWork;
        //
        public IList<Plane> Planes { get; set; }
        public PlaneService(IUnitOfWork unitOfWork):base(unitOfWork)
        {
            Planes = GetAll();
        //    this.unitOfWork = unitOfWork;
     //       _repository = unitOfWork.GetRepository<Plane>();
        }


        //16-d
        public void DeleteUselessPlanes()
        {
            Planes.Where(p => p.flights.Where(f => CalculateYears(f.FlightDate) > 1)
            .ToList().Count > 0)
                .ToList().ForEach(p =>
                {
                    Delete(p);
                    Planes.Remove(p);
                });

           
        }
        public static int CalculateYears(DateTime lastUsed)
        {
            int YearsPassed = DateTime.Now.Year - lastUsed.Year;
            // Are we before the birth date this year? If so subtract one year from the mix
            if (DateTime.Now.Month < lastUsed.Month || 
                (DateTime.Now.Month == lastUsed.Month && 
                DateTime.Now.Day < lastUsed.Day))
            {
                YearsPassed--;
            }
            return YearsPassed;
        }
        //16-b
        public IList<Flight> GetFlights(int number)
        {
            return Planes.OrderByDescending(p => p.ManufactureDate).Take(number).SelectMany(p => p.flights).ToList();
        }

        //16-a
        public IList<Passenger> GetPassengers(Plane p)
        {
            return p.flights.SelectMany(f =>f.passengers).ToList(); 
        }


        //16-c
        public bool IsAvailable(int n, Flight flight)
        {
            return flight.MyPlane.Capacity - flight.passengers.Count < n;
        }
  
    }
}
