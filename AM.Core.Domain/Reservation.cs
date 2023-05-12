using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Core.Domain
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }
        public int Price { get; set; }
        public int Seat { get; set; }

        public bool VIP { get; set; }

        public Passenger Passenger { get; set; }
        public Flight Flight { get; set; }

        public Reservation(int price, int seat, bool vIP, Passenger passenger, Flight flight)
        {
            Price = price;
            Seat = seat;
            VIP = vIP;
            passenger.Reservations.Add(this);
            flight.Reservations.Add(this);
            Passenger = passenger;
            Flight = flight;
            
        }
        public Reservation() { }    
    }
}
