using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkingManager.Models;
using static ParkingManager.Models.Ticket;
using static ParkingManager.Models.Vehicle;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CheckVehicleClass()
        {
            Vehicle vehicle = new Vehicle(5365, 646, 6869, "Motorcycle");
            VehicleClass vClass = vehicle.Class;
            Assert.IsTrue(vClass == VehicleClass.A);


            vehicle = new Vehicle(5365, 646, 6869, "Private");
            vClass = vehicle.Class;
            Assert.IsTrue(vClass == VehicleClass.A);

            vehicle = new Vehicle(5365, 646, 6869, "Crossover");
            vClass = vehicle.Class;
            Assert.IsTrue(vClass == VehicleClass.A);

            vehicle = new Vehicle(5365, 646, 6869, "SUV");
            vClass = vehicle.Class;
            Assert.IsTrue(vClass == VehicleClass.B);

            vehicle = new Vehicle(5365, 646, 6869, "Van");
            vClass = vehicle.Class;
            Assert.IsTrue(vClass == VehicleClass.B);

            vehicle = new Vehicle(5365, 646, 6869, "Truck");
            vClass = vehicle.Class;
            Assert.IsTrue(vClass == VehicleClass.C);
        }


        [TestMethod]
        public void CheckTicketCreation()
        {
            Ticket ticket = new Ticket(TicketType.VIP);

            Assert.IsTrue(ticket.Type == TicketType.VIP);
            Assert.IsTrue(ticket.LotsStartPosition == 1);
            Assert.IsTrue(ticket.LotsEndPosition == 10);
            Assert.IsTrue(ticket.MaxHeight == int.MaxValue);
            Assert.IsTrue(ticket.MaxWidth == int.MaxValue);
            Assert.IsTrue(ticket.MaxLength == int.MaxValue);

            List<VehicleClass> classes = new List<VehicleClass> { VehicleClass.A, VehicleClass.B, VehicleClass.C };
            Assert.IsTrue(ticket.AllowedClasses.All(classes.Contains));
            Assert.IsTrue(ticket.Cost == 200);
            Assert.IsTrue(ticket.TimeLimitHour == int.MaxValue);


            ticket = new Ticket(TicketType.Value);

            Assert.IsTrue(ticket.Type == TicketType.Value);
            Assert.IsTrue(ticket.LotsStartPosition == 11);
            Assert.IsTrue(ticket.LotsEndPosition == 30);
            Assert.IsTrue(ticket.MaxHeight == 2500);
            Assert.IsTrue(ticket.MaxWidth == 2400);
            Assert.IsTrue(ticket.MaxLength == 5000);

            classes = new List<VehicleClass> { VehicleClass.A, VehicleClass.B };
            Assert.IsTrue(ticket.AllowedClasses.All(classes.Contains));
            Assert.IsTrue(ticket.Cost == 100);
            Assert.IsTrue(ticket.TimeLimitHour == 72);




            ticket = new Ticket(TicketType.Regular);

            Assert.IsTrue(ticket.Type == TicketType.Regular);
            Assert.IsTrue(ticket.LotsStartPosition == 31);
            Assert.IsTrue(ticket.LotsEndPosition == 60);
            Assert.IsTrue(ticket.MaxHeight == 2000);
            Assert.IsTrue(ticket.MaxWidth == 2000);
            Assert.IsTrue(ticket.MaxLength == 3000);

            classes = new List<VehicleClass> { VehicleClass.A };
            Assert.IsTrue(ticket.AllowedClasses.All(classes.Contains));
            Assert.IsTrue(ticket.Cost == 50);
            Assert.IsTrue(ticket.TimeLimitHour == 24);


        }

        [TestMethod]

        public void CheckValidateTicket()
        {
            Ticket ticket = new Ticket(TicketType.VIP);
            Assert.IsTrue(ticket.ValidateTicket(VehicleClass.A) == true);
            Assert.IsTrue(ticket.ValidateTicket(VehicleClass.B) == true);
            Assert.IsTrue(ticket.ValidateTicket(VehicleClass.C) == true);

            ticket = new Ticket(TicketType.Value);
            Assert.IsTrue(ticket.ValidateTicket(VehicleClass.A) == true);
            Assert.IsTrue(ticket.ValidateTicket(VehicleClass.B) == true);
            Assert.IsTrue(ticket.ValidateTicket(VehicleClass.C) == false);

            ticket = new Ticket(TicketType.Regular);
            Assert.IsTrue(ticket.ValidateTicket(VehicleClass.A) == true);
            Assert.IsTrue(ticket.ValidateTicket(VehicleClass.B) == false);
            Assert.IsTrue(ticket.ValidateTicket(VehicleClass.C) == false);


        }

        [TestMethod]

        public void CheckValidateDimension()
        {


            Vehicle vehicle = new Vehicle(50000, 500, 100, "Motorcycle");

            Ticket ticket = new Ticket(TicketType.VIP);
            Assert.IsTrue(ticket.ValidateDimension(vehicle) == true);

            ticket = new Ticket(TicketType.Value);
            Assert.IsTrue(ticket.ValidateDimension(vehicle) == false);

            ticket = new Ticket(TicketType.Regular);
            Assert.IsTrue(ticket.ValidateDimension(vehicle) == false);

            vehicle = new Vehicle(2500, 2400, 5000, "SUV");

            ticket = new Ticket(TicketType.VIP);
            Assert.IsTrue(ticket.ValidateDimension(vehicle) == true);

            ticket = new Ticket(TicketType.Value);
            Assert.IsTrue(ticket.ValidateDimension(vehicle) == true);


        }



        [TestMethod]

        public void CheckGetMinimalTicketPrice()
        {
            Vehicle vehicle = new Vehicle(50000, 500, 100, "Motorcycle");

            Assert.IsTrue(Ticket.GetMinimalTicketPrice(vehicle) == TicketType.VIP);

            vehicle = new Vehicle(2000, 2400, 100, "Motorcycle");

            Assert.IsTrue(Ticket.GetMinimalTicketPrice(vehicle) == TicketType.Value);

            vehicle = new Vehicle(2000, 100, 100, "Van");

            Assert.IsTrue(Ticket.GetMinimalTicketPrice(vehicle) == TicketType.Value);

            vehicle = new Vehicle(2000, 2400, 100, "Truck");

            Assert.IsTrue(Ticket.GetMinimalTicketPrice(vehicle) == TicketType.VIP);

        }


        [TestMethod]

        public void CheckExtraMoney()
        {
            Ticket ticket = new Ticket(TicketType.VIP);

            Assert.IsTrue(ticket.ExtraMoney(TicketType.VIP)==0);

            ticket = new Ticket(TicketType.Value);

            Assert.IsTrue(ticket.ExtraMoney(TicketType.VIP) == 100);

            ticket = new Ticket(TicketType.Regular);

            Assert.IsTrue(ticket.ExtraMoney(TicketType.VIP) == 150);

            ticket = new Ticket(TicketType.Regular);

            Assert.IsTrue(ticket.ExtraMoney(TicketType.Value) == 50);

        }
    }
}
