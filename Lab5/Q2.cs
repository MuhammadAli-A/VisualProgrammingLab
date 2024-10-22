using System;
using System.Collections.Generic;

// Base Class: Customer
public class Customer
{
    public int CustomerId { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    // Customer can make multiple reservations
    public List<Reservation> Reservations { get; set; }

    public Customer()
    {
        Reservations = new List<Reservation>();
    }

    public void MakeReservation(Reservation reservation)
    {
        Reservations.Add(reservation);
    }
}

// Derived Class: RetailCustomer (inherits Customer)
public class RetailCustomer : Customer
{
    public string CreditCardType { get; set; }
    public string CreditCardNo { get; set; }
}

// Derived Class: CorporateCustomer (inherits Customer)
public class CorporateCustomer : Customer
{
    public string CompanyName { get; set; }
    public int FrequentFlyerPts { get; set; }
    public string BillingAccountNo { get; set; }
}

// Reservation Class
public class Reservation
{
    public int ReservationNo { get; set; }
    public DateTime Date { get; set; }
    public Customer Customer { get; set; }  // Reservation made by a Customer
    public List<Seat> Seats { get; set; }   // A reservation reserves multiple seats
    public Flight Flight { get; set; }      // Reservation is related to a specific flight

    public Reservation()
    {
        Seats = new List<Seat>();
    }
}

// Seat Class
public class Seat
{
    public int RowNo { get; set; }
    public int SeatNo { get; set; }
    public decimal Price { get; set; }
    public string Status { get; set; }  // Example: "Reserved", "Available"
}

// Flight Class
public class Flight
{
    public int FlightId { get; set; }
    public DateTime Date { get; set; }
    public string Origin { get; set; }
    public string Destination { get; set; }
    public TimeSpan DepartureTime { get; set; }
    public TimeSpan ArrivalTime { get; set; }
    public int SeatingCapacity { get; set; }

    // A flight contains multiple seats
    public List<Seat> Seats { get; set; }

    public Flight()
    {
        Seats = new List<Seat>();
    }
}

// Main Program to demonstrate the scenario
public class Program
{
    public static void Main(string[] args)
    {
        // Create a flight
        Flight flight = new Flight
        {
            FlightId = 101,
            Date = DateTime.Now,
            Origin = "New York",
            Destination = "Los Angeles",
            DepartureTime = new TimeSpan(14, 0, 0),
            ArrivalTime = new TimeSpan(17, 30, 0),
            SeatingCapacity = 150
        };

        // Add some seats to the flight
        flight.Seats.Add(new Seat { RowNo = 1, SeatNo = 1, Price = 200000, Status = "Available" });
        flight.Seats.Add(new Seat { RowNo = 1, SeatNo = 2, Price = 200000, Status = "Available" });

        // Create a retail customer
        RetailCustomer retailCustomer = new RetailCustomer
        {
            CustomerId = 1,
            FirstName = "Muhammad",
            LastName = "Ali",
            Email = "m.ali@gmail.com",
            Phone = "123-456789",
            CreditCardType = "Visa",
            CreditCardNo = "4111111111111111"
        };

        // Create a reservation for the retail customer
        Reservation reservation = new Reservation
        {
            ReservationNo = 1001,
            Date = DateTime.Now,
            Customer = retailCustomer,
            Flight = flight
        };

        // Add seats to the reservation
        reservation.Seats.Add(flight.Seats[0]);  // Seat 1A
        flight.Seats[0].Status = "Reserved";     // Mark seat as reserved

        // Add reservation to the customer
        retailCustomer.MakeReservation(reservation);

        // Output reservation details
        Console.WriteLine($"Customer: {retailCustomer.FirstName} {retailCustomer.LastName}");
        Console.WriteLine($"\nReservation No: {reservation.ReservationNo} \nFlight: {flight.Origin} to {flight.Destination}");
        foreach (var seat in reservation.Seats)
        {
            Console.WriteLine($"Seat: Row {seat.RowNo}, No {seat.SeatNo} \nPrice: {seat.Price} \nStatus: {seat.Status}");
        }
    }
}
