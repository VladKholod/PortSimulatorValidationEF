using System;
using System.Linq;
using PortSimulator.Application.Views.ViewAbstractions;
using PortSimulator.Core.Entities;
using PortSimulator.DataAccessLayer;
using PortSimulator.DataAccessLayer.Manager;
using PortSimulator.DataAccessLayer.Validators;

namespace PortSimulator.Application.Views
{
    public class ShipView : BaseView
    {
        private readonly EntityManager<Ship> _manager; 
        public ShipView()
        {
            Header = "Id\tNumber\tCapac\tCreateDate\tMaxDist\tTCount\tPortId";

            var repository = new Repository<Ship>();
            _manager = new EntityManager<Ship>(repository, new ShipValidator(repository));
        }

        #region CRUD
        public override void Insert()
        {
            try
            {
                Console.Write(string.Format("Insert {0}'s {1} : ", "Ship", "Number"));
                var number = int.Parse(Console.ReadLine());
                Console.Write(string.Format("Insert {0}'s {1} : ", "Ship", "Capacity"));
                var capacity = int.Parse(Console.ReadLine());
                Console.Write(string.Format("Insert {0}'s {1} : ", "Ship", "CreateDate"));
                var createDate = DateTime.Parse(Console.ReadLine());
                Console.Write(string.Format("Insert {0}'s {1} : ", "Ship", "MaxDistance"));
                var maxDistance = int.Parse(Console.ReadLine());
                Console.Write(string.Format("Insert {0}'s {1} : ", "Ship", "TeamCount"));
                var teamCount = int.Parse(Console.ReadLine());
                Console.Write(string.Format("Select {0}'s {1} : ", "Ship", "Port"));
                var port = GetDependence<Port>();

                var ship = new Ship()
                {
                    Number = number,
                    Capacity = capacity,
                    CreateDate = createDate,
                    MaxDistance = maxDistance,
                    TeamCount = teamCount,
                    Port = port
                };

                _manager.Insert(ship);
            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid input");
            }
        }

        public override void Update()
        {
            var ship = SelectMenuItem(_manager.SelectAll().ToList());
            try
            {
                Console.Write(string.Format("Insert {0}'s {1} : ", "Ship", "Number"));
                var number = int.Parse(Console.ReadLine());
                Console.Write(string.Format("Insert {0}'s {1} : ", "Ship", "Capacity"));
                var capacity = int.Parse(Console.ReadLine());
                Console.Write(string.Format("Insert {0}'s {1} : ", "Ship", "CreateDate"));
                var createDate = DateTime.Parse(Console.ReadLine());
                Console.Write(string.Format("Insert {0}'s {1} : ", "Ship", "MaxDistance"));
                var maxDistance = int.Parse(Console.ReadLine());
                Console.Write(string.Format("Insert {0}'s {1} : ", "Ship", "TeamCount"));
                var teamCount = int.Parse(Console.ReadLine());
                Console.Write(string.Format("Select {0}'s {1} : ", "Ship", "Port"));
                var port = GetDependence<Port>();

                ship.Number = number;
                ship.Capacity = capacity;
                ship.CreateDate = createDate;
                ship.Capacity = capacity;
                ship.MaxDistance = maxDistance;
                ship.Port = port;

                _manager.Update(ship);
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
            Console.Write(string.Format("Insert {0}'s {1} : ", "Ship", "Id"));
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
                foreach (var ship in _manager.SelectAll())
                {
                    Console.WriteLine(ship);
                }
        }
        #endregion
    }
}
