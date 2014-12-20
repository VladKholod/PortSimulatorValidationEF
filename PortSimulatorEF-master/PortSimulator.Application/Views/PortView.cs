using System;
using System.Linq;
using PortSimulator.Application.Views.ViewAbstractions;
using PortSimulator.Core.Entities;
using PortSimulator.DataAccessLayer;
using PortSimulator.DataAccessLayer.Manager;
using PortSimulator.DataAccessLayer.Validators;

namespace PortSimulator.Application.Views
{
    public class PortView : BaseView
    {
        private readonly EntityManager<Port> _manager;

        public PortView()
        {
            Header = "Id\tName\t\tCityId";

            var repository = new Repository<Port>();
            _manager = new EntityManager<Port>(repository, new PortValidator(repository));
        }

        #region CRUD
        public override void Insert()
        {
            Console.Write(string.Format("Insert {0}'s {1} : ", "Port", "Name"));
            var name = Console.ReadLine();
            Console.Write(string.Format("Select {0}'s {1} : ", "Port", "City"));
            var city = GetDependence<City>();

            var port = new Port()
            {
                Name = name,
                City = city
            };

            _manager.Insert(port);

        }

        public override void Update()
        {
            var port = SelectMenuItem(_manager.SelectAll().ToList());

            Console.Write(string.Format("Insert {0}'s {1} : ", "Port", "Name"));
            var name = Console.ReadLine();
            Console.Write(string.Format("Select {0}'s {1} : ", "Port", "City"));
            var city = GetDependence<City>();

            port.Name = name;
            port.City = city;

            _manager.Update(port);
        }

        public override void Delete()
        {
            var cargo = SelectMenuItem(_manager.SelectAll().ToList());
            _manager.Delete(cargo.Id);
        }

        public override void Select()
        {
            Console.Write(string.Format("Insert {0}'s {1} : ", "Port", "Id"));
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
            foreach (var port in _manager.SelectAll())
            {
                Console.WriteLine(port);
            }
        }
        #endregion
    }
}
