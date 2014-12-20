using System;
using System.Linq;
using PortSimulator.Application.Views.ViewAbstractions;
using PortSimulator.Core.Entities;
using PortSimulator.DataAccessLayer;
using PortSimulator.DataAccessLayer.Manager;
using PortSimulator.DataAccessLayer.Validators;

namespace PortSimulator.Application.Views
{
    public class CargoView : BaseView
    {
        private readonly EntityManager<Cargo> _manager; 
        public CargoView()
        {
            Header = "Id\tNumber\tWeight\tPrice\tIPrice\tCTypeId\tTripId";

            var repository = new Repository<Cargo>();
            _manager = new EntityManager<Cargo>(repository, new CargoValidator(repository));
        }

        #region CRUD
        public override void Insert()
        {
            try
            {
                Console.Write(string.Format("Insert {0}'s {1} : ", "Cargo", "Number"));
                var number = int.Parse(Console.ReadLine());
                Console.Write(string.Format("Insert {0}'s {1} : ", "Cargo", "Weight"));
                var weight = int.Parse(Console.ReadLine());
                Console.Write(string.Format("Insert {0}'s {1} : ", "Cargo", "Price"));
                var price = int.Parse(Console.ReadLine());
                Console.Write(string.Format("Insert {0}'s {1} : ", "Cargo", "InsurancePrice"));
                var insurancePrice = int.Parse(Console.ReadLine());
                Console.Write(string.Format("Select {0}'s {1} : ", "Cargo", "Trip"));
                var trip = GetDependence<Trip>();
                Console.Write(string.Format("Select {0}'s {1} : ", "Cargo", "CargoType"));
                var cargoType = GetDependence<CargoType>();

                var cargo = new Cargo()
                {
                    Number = number,
                    Weight = weight,
                    Price = price,
                    InsurancePrice = insurancePrice,
                    Trip = trip,
                    CargoType = cargoType
                };

                _manager.Insert(cargo);
            }
            catch (Exception e)
            {
                Console.WriteLine();
            }
        }

        public override void Update()
        {
            var cargo = SelectMenuItem(_manager.SelectAll().ToList());
            try
            {
                Console.Write(string.Format("Insert {0}'s {1} : ", "Cargo", "Number"));
                var number = int.Parse(Console.ReadLine());
                Console.Write(string.Format("Insert {0}'s {1} : ", "Cargo", "Weight"));
                var weight = int.Parse(Console.ReadLine());
                Console.Write(string.Format("Insert {0}'s {1} : ", "Cargo", "Price"));
                var price = int.Parse(Console.ReadLine());
                Console.Write(string.Format("Insert {0}'s {1} : ", "Cargo", "InsurancePrice"));
                var insurancePrice = int.Parse(Console.ReadLine());
                Console.Write(string.Format("Select {0}'s {1} : ", "Cargo", "Trip"));
                var trip = GetDependence<Trip>();
                Console.Write(string.Format("Select {0}'s {1} : ", "Cargo", "CargoType"));
                var cargoType = GetDependence<CargoType>();

                cargo.Number = number;
                cargo.Weight = weight;
                cargo.Price = price;
                cargo.InsurancePrice = insurancePrice;
                cargo.Trip = trip;
                cargo.CargoType = cargoType;

                _manager.Update(cargo);
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid input");
            }
        }

        public override void Delete()
        {
            var cargo = SelectMenuItem(_manager.SelectAll().ToList());
            _manager.Delete(cargo.Id);
        }

        public override void Select()
        {
            Console.Write(string.Format("Insert {0}'s {1} : ", "Cargo", "Id"));
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
            foreach (var cargo in _manager.SelectAll())
            {
                Console.WriteLine(cargo);
            }
        }
        #endregion
    }
}
