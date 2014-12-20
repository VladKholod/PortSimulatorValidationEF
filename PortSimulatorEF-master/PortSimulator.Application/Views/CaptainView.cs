using System;
using System.Linq;
using PortSimulator.Application.Views.ViewAbstractions;
using PortSimulator.Core.Entities;
using PortSimulator.DataAccessLayer;
using PortSimulator.DataAccessLayer.Manager;
using PortSimulator.DataAccessLayer.Validators;

namespace PortSimulator.Application.Views
{
    public class CaptainView : BaseView
    {
        private readonly EntityManager<Captain> _manager;

        public CaptainView()
        {
            Header = "Id\tFName\tLName";

            var repository = new Repository<Captain>();
            _manager = new EntityManager<Captain>(repository, new CaptainValidator(repository));
        }

        #region CRUD
        public override void Insert()
        {
            Console.Write(string.Format("Insert {0}'s {1} : ", "Captain", "FirstName"));
            string firstName = Console.ReadLine();
            Console.Write(string.Format("Insert {0}'s {1} : ", "Captain", "LastName"));
            string lastName = Console.ReadLine();

            var captain = new Captain() {FirstName = firstName, LastName = lastName};

            _manager.Insert(captain);
        }

        public override void Update()
        {
            var captain = SelectMenuItem(_manager.SelectAll().ToList());

            Console.Write(string.Format("Insert {0}'s {1} : ", "Captain", "FirstName"));
            string firstName = Console.ReadLine();
            Console.Write(string.Format("Insert {0}'s {1} : ", "Captain", "LastName"));
            string lastName = Console.ReadLine();

            captain.FirstName = firstName;
            captain.LastName = lastName;

            _manager.Update(captain);
        }

        public override void Delete()
        {
            var captain = SelectMenuItem(_manager.SelectAll().ToList());
            _manager.Delete(captain.Id);
        }

        public override void Select()
        {
            try
            {
                var id = int.Parse(Console.ReadLine());

                Console.WriteLine(Header);
                Console.WriteLine(_manager.Select(id));
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid id");
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
