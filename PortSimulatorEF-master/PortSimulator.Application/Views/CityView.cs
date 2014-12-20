using System;
using System.Linq;
using PortSimulator.Application.Views.ViewAbstractions;
using PortSimulator.Core.Entities;
using PortSimulator.DataAccessLayer;
using PortSimulator.DataAccessLayer.Manager;
using PortSimulator.DataAccessLayer.Validators;

namespace PortSimulator.Application.Views
{
    public class CityView : BaseView
    {
        private readonly EntityManager<City> _manager;

        public CityView()
        {
            Header = "Id\tName";

            var repository = new Repository<City>();
            _manager = new EntityManager<City>(repository, new CityValidator(repository));
        }

        #region CRUD
        public override void Insert()
        {
            Console.Write(string.Format("Insert {0}'s {1} : ", "City", "Name"));
            string name = Console.ReadLine();
            var city = new City() {Name = name};

            _manager.Insert(city);
        }

        public override void Update()
        {
            var city = SelectMenuItem(_manager.SelectAll().ToList());

            Console.Write(string.Format("Insert {0}'s {1} : ", "City", "Name"));
            string name = Console.ReadLine();
            city.Name = name;

            _manager.Update(city);
        }

        public override void Delete()
        {
            var city = SelectMenuItem(_manager.SelectAll().ToList());
            _manager.Delete(city.Id);
        }

        public override void Select()
        {
            Console.Write(string.Format("Insert {0}'s {1} : ", "City", "Id"));
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
            foreach (var city in _manager.SelectAll())
            {
                Console.WriteLine(city);
            }
        }
        #endregion
    }
}
