using System;
using System.Linq;
using PortSimulator.Application.Views.ViewAbstractions;
using PortSimulator.Core.Entities;
using PortSimulator.DataAccessLayer;
using PortSimulator.DataAccessLayer.Manager;
using PortSimulator.DataAccessLayer.Validators;

namespace PortSimulator.Application.Views
{
    public class TripView : BaseView
    {
        private EntityManager<Trip> _manager;

        public TripView()
        {
            Header = "Id\tStartDate\tEndDate\t\tShipID\tCapId\tPortFId\tPortTId";
            
            var repository = new Repository<Trip>();
            _manager = new EntityManager<Trip>(repository, new TripValidator(repository));
        }

        #region CRUD
        public override void Insert()
        {
            try
            {
                Console.Write(string.Format("Insert {0}'s {1} : ", "Trip", "StartDate"));
                var startDate = DateTime.Parse(Console.ReadLine());
                Console.Write(string.Format("Insert {0}'s {1} : ", "Trip", "EndDate"));
                var endDate = DateTime.Parse(Console.ReadLine());
                Console.Write(string.Format("Select {0}'s {1} : ", "Trip", "Ship"));
                var ship = GetDependence<Ship>();
                Console.Write(string.Format("Select {0}'s {1} : ", "Trip", "Captain"));
                var captain = GetDependence<Captain>();
                Console.Write(string.Format("Select {0}'s {1} : ", "Trip", "PortFrom"));
                var portFrom = GetDependence<Port>();
                Console.Write(string.Format("Select {0}'s {1} : ", "Trip", "PortTo"));
                var portTo = GetDependence<Port>();

                var trip = new Trip()
                {
                    StartDate = startDate,
                    EndDate = endDate,
                    Ship = ship,
                    Captain = captain,
                    PortFrom = portFrom,
                    PortTo = portTo
                };

                _manager.Insert(trip);
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid input");
            }
        }

        public override void Update()
        {
            var trip = SelectMenuItem(_manager.SelectAll().ToList());
            try
            {
                Console.Write(string.Format("Insert {0}'s {1} : ", "Trip", "StartDate"));
                var startDate = DateTime.Parse(Console.ReadLine());
                Console.Write(string.Format("Insert {0}'s {1} : ", "Trip", "EndDate"));
                var endDate = DateTime.Parse(Console.ReadLine());
                Console.Write(string.Format("Select {0}'s {1} : ", "Trip", "Ship"));
                var ship = GetDependence<Ship>();
                Console.Write(string.Format("Select {0}'s {1} : ", "Trip", "Captain"));
                var captain = GetDependence<Captain>();
                Console.Write(string.Format("Select {0}'s {1} : ", "Trip", "PortFrom"));
                var portFrom = GetDependence<Port>();
                Console.Write(string.Format("Select {0}'s {1} : ", "Trip", "PortTo"));
                var portTo = GetDependence<Port>();

                trip.StartDate = startDate;
                trip.EndDate = endDate;
                trip.Ship = ship;
                trip.Captain = captain;
                trip.PortFrom = portFrom;
                trip.PortTo = portTo;

                _manager.Update(trip);
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid input");
            }
        }

        public override void Delete()
        {
            var ship = SelectMenuItem(_manager.SelectAll().ToList());
            _manager.Delete(ship.Id);
        }

        public override void Select()
        {
            Console.Write(string.Format("Insert {0}'s {1} : ", "Trip", "Id"));
            try
            {
                var id = int.Parse(Console.ReadLine());

                Console.WriteLine(Header);
                Console.WriteLine(_manager.Select(id));
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid id.");
            }
        }

        public override void SelectAll()
        {
            Console.WriteLine(Header);
            foreach (var trip in _manager.SelectAll())
            {
                Console.WriteLine(trip);
            }
        }
        #endregion
    }
}
