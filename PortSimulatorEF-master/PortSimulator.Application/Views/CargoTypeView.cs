using System;
using System.Linq;
using PortSimulator.Application.Views.ViewAbstractions;
using PortSimulator.Core.Entities;
using PortSimulator.DataAccessLayer;
using PortSimulator.DataAccessLayer.Manager;
using PortSimulator.DataAccessLayer.Validators;

namespace PortSimulator.Application.Views
{
    public class CargoTypeView : BaseView
    {
        private readonly EntityManager<CargoType> _manager;

        public CargoTypeView()
        {
            Header = "Id\tName";

            var repository = new Repository<CargoType>();
            _manager = new EntityManager<CargoType>(repository, new CargoTypeValidator(repository));
        }

        #region CRUD
        public override void Insert()
        {
            Console.Write(string.Format("Insert {0}'s {1} : ", "CargoType", "Name"));
            string name = Console.ReadLine();
            var cargoType = new CargoType() {Name = name};

            _manager.Insert(cargoType);
        }

        public override void Update()
        {
            var cargoType = SelectMenuItem(_manager.SelectAll().ToList());

            Console.Write(string.Format("Insert {0}'s {1} : ", "CargoType", "Name"));
            string name = Console.ReadLine();
            cargoType.Name = name;

            _manager.Update(cargoType);
        }

        public override void Delete()
        {
            var cargoType = SelectMenuItem(_manager.SelectAll().ToList());
            _manager.Delete(cargoType.Id);
        }

        public override void Select()
        {
            Console.Write(string.Format("Insert {0}'s {1} : ", "CargoType", "Id"));
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
            foreach (var cargoType in _manager.SelectAll())
            {
                Console.WriteLine(cargoType);
            }
        }
        #endregion
    }
}
