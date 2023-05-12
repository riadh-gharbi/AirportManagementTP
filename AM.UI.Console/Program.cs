// See https://aka.ms/new-console-template for more information

using AM.Core.Domain;
using AM.Core.Interface;
using AM.Core.Service;
using AM.Data;

Console.WriteLine("Hello, World!");
//TP1.Question7
Plane plane= new Plane();
plane.Capacity = 300;
plane.ManufactureDate = new DateTime(2000, 1, 1);
plane.MyPlaneType = PlaneType.Boeing;
//TP1.Question8
Plane plane1 = new Plane(PlaneType.Airbus, 100, new DateTime(2001, 9, 12));
//Tp1.Question9
Plane plane2 = new Plane()
{
    Capacity = 100,
    ManufactureDate = new DateTime(2011, 2, 14)
};
//tp1.Question12.b
Passenger passenger= new Passenger();
Console.WriteLine(passenger.GetPassengerType());
Staff staff= new Staff();
Console.WriteLine(staff.GetPassengerType());
Traveller traveller= new Traveller();
Console.WriteLine(traveller.GetPassengerType());

AMContext context = new AMContext();

Passenger passenger1 = new Passenger();
passenger1.PassportNumber = "11111";
Flight flight1 = new Flight();
flight1.Departure = "Tunis";
flight1.EffectiveArrival = new DateTime(2023,12,12);
flight1.Destination = "Paris";
flight1.EstimatedDuration = 20;
flight1.FlightDate = new DateTime(2023, 12, 12);
passenger1.BirthDate = new DateTime(1996, 2, 20);
FullName f = new FullName();
f.FirstName= "Test";
f.LastName = "Test";
passenger1.MyFullName = f;
passenger1.TelNumber = "200000";
passenger1.EmailAddress = "riadhgharbi@mail.com";



//context.Passengers.Add(passenger1);
////context.Flights.Add(flight1);
//context.SaveChanges();
//Passenger passenger1 = context.Passengers.First();
//Flight flight1= context.Flights.First();
//Reservation reservation = new Reservation(100, 25, false, passenger1, flight1);
//
//context.Add(reservation);
//context.SaveChanges();
UnitOfWork un = new UnitOfWork(context);
IPlaneService planeService = new PlaneService(un);
planeService.DeleteUselessPlanes();




