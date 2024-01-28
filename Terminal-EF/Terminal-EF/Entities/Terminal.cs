using BusTerminal.EntityMaps;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terminal_EF.Entities
{
    public static class Terminal
    {

        public static string num;
        public static void AddBus(string name, int type)
        {
            var context = new EfTerminalDb();
            var bus = new Bus
            {
                Name = name,
                Type = (Type)type

            };
            bus.SetCapacity();
            if (bus.Chairs != null)
            {
                bus.Chairs.Clear();

            }

            bus.SetChair();
            context.Buses.Add(bus);
            context.SaveChanges();
        }
        public static void AddTrip(int type)
        {
            var context = new EfTerminalDb();

            if (type == 1)
            {
                var item = context.Buses.Where(_ => _.Type == Type.Normal);
                foreach (var bus in item)
                {
                    Console.WriteLine($"{bus.Id}->name={bus.Name}--Type{bus.Type}");
                }
                int option = GetInt("Enter option");

                string origin = GetString("set origin");
                string destination = GetString("set destination");
                decimal ticketPrice = GetDecimal("set Ticket Price");
                var trip = new Trip
                {
                    Origin = origin,
                    Destination = destination,
                    TicketPrice = ticketPrice,
                    GroupId = option,

                };
                context.Trips.Add(trip);
                context.SaveChanges();
            }

            if (type == 2)
            {
                var item = context.Buses.Where(_ => _.Type == Type.Vip);
                foreach (var bus in item)
                {
                    Console.WriteLine($"{bus.Id}->name:{bus.Name}--Type:{bus.Type}");
                }
                int option = GetInt("Enter option");

                string origin = GetString("set origin");
                string destination = GetString("set destination");
                decimal ticketPrice = GetDecimal("set Ticket Price");
                var trip = new Trip
                {
                    Origin = origin,
                    Destination = destination,
                    TicketPrice = ticketPrice,
                    GroupId = option,

                };
                context.Trips.Add(trip);
                context.SaveChanges();
            }

        }

        public static void ShowTrip()
        {
            var context = new EfTerminalDb();
            foreach (var trip in context.Trips.Include(_ => _.Bus))
            {
                Console.WriteLine($"{trip.Id}->name:{trip.Bus.Name}--" +
                    $"Type:{trip.Bus.Type}--" +
                    $"origin:{trip.Origin}--" +
                    $"destination:{trip.Destination}--" +
                    $"Price:{trip.TicketPrice}");
            }

        }



        public static void BookTheTicket()
        {
            var context = new EfTerminalDb();
            ShowTrip();
            int option = GetInt("Enter trip");


            foreach (var trip in context.Trips.Where(_ => _.Id == option).Include(_ => _.Bus).ThenInclude(_ => _.Chairs))
            {
                foreach (var chair in trip.Bus.Chairs)
                {

                    Console.WriteLine($"{chair.IdNum}->{trip.Bus.Name}--{chair.Num}");
                }
            }
            int chooschair = GetInt("Enter Chair");
            var seat = context.Chairs.Where(_ => _.IdNum == chooschair).Include(_ => _.Bus).ThenInclude(_ => _.Trip);
            foreach (var item in seat)
            {
                item.Num = "RR";
                foreach (var total in item.Bus.Trip)
                {

                    total.Total += total.TicketPrice * 30 / (100);

                }
            }
            context.SaveChanges();
        }







        public static void BuyTheTicket()
        {
            var context = new EfTerminalDb();
            ShowTrip();
            int option = GetInt("Enter Trip");


            foreach (var trip in context.Trips.Where(_ => _.Id == option).Include(_ => _.Bus).ThenInclude(_ => _.Chairs))
            {
                foreach (var chair in trip.Bus.Chairs)
                {

                    Console.WriteLine($"{chair.IdNum}->{trip.Bus.Name}--{chair.Num}");
                }
            }
            int chooschair = GetInt("Enter Chair");
            var seat = context.Chairs.Where(_ => _.IdNum == chooschair).Include(_ => _.Bus).ThenInclude(_ => _.Trip);
            foreach (var item in seat)
            {
                item.Num = "BB";

                foreach (var total in item.Bus.Trip)
                {

                    total.Total += total.TicketPrice;

                }

            }
            context.SaveChanges();
        }


        public static void CancelTicket()
        {
            var context = new EfTerminalDb();
            ShowTrip();
            int option = GetInt("Enter trip");
            var trips = context.Trips.Where(_ => _.Id == option).Include(_ => _.Bus).ThenInclude(_ => _.Chairs);
            foreach (var trip in trips)
            {
                foreach (var chair in trip.Bus.Chairs)
                {

                    Console.WriteLine($"{chair.IdNum}->{trip.Bus.Name}--{chair.Num}");
                }
            }
            int chooschair = GetInt("Enter Chair");
            var seat = context.Chairs.Where(_ => _.IdNum == chooschair).Include(_ => _.Bus).ThenInclude(_ => _.Trip);
            foreach (var item in seat)
            {

                if (item.Num == "RR")
                {
                    item.Num = item.IdNum.ToString();
                    foreach (var total in item.Bus.Trip)
                    {

                        total.Total = (total.TicketPrice * 80 / (100)) - (total.TicketPrice * 30 / (100));

                    }
                }

                if (item.Num == "BB")
                {
                    item.Num = item.IdNum.ToString();
                    foreach (var total in item.Bus.Trip)
                    {
                        total.Total = (total.TicketPrice * 90 / (100)) -(total.TicketPrice);
                    }
                }

            }

            context.SaveChanges();
        }

        public static void ShowTripTotal()
        {
            var context = new EfTerminalDb();
            ShowTrip();
            int option = GetInt("Enter trip");
            foreach (var trip in context.Trips.Where(_ => _.Id == option).Include(_ => _.Bus))
            {
                Console.WriteLine($"Total={trip.Total}");
            }

        }





        public static int GetInt(string message)
        {
            Console.WriteLine(message);
            int get = int.Parse(Console.ReadLine()!);
            return get;
        }


        public static string GetString(string message)
        {
            Console.WriteLine(message);
            string get = Console.ReadLine()!;
            return get;
        }



        public static double GetDouble(string message)
        {
            Console.WriteLine(message);
            double get = double.Parse(Console.ReadLine()!);
            return get;
        }

        public static decimal GetDecimal(string message)
        {
            Console.WriteLine(message);
            decimal get = decimal.Parse(Console.ReadLine()!);
            return get;
        }
    }
}
