using MyHospitalizationPal.DAL.Interfaces;
using MyHospitalizationPal.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHospitalizationPal.DAL.Repository
{
    class RoomRepository : Repository<Room>, IRoomRepository
    {
        private ApplicationContext Context
        {
            get
            {
                return db as ApplicationContext;
            }
        }
        public RoomRepository(ApplicationContext context) : base(context)
        {
            
        }
        public void Create(Room entity)
        {
            Context.Room.Add(entity);
            Context.SaveChanges();
        }

        public void Delete(int id)
        {
            var room = Context.Room.SingleOrDefault(r => r.Id == id);
            Context.Room.Remove(room);
            Context.SaveChanges();
        }

        public Room Details(int id)
        {
            return Context.Room.SingleOrDefault(r => r.Id == id);
        }

        public void Edit(Room entity)
        {
            Context.Room.Update(entity);
            Context.SaveChanges();
        }

        public IEnumerable<Room> GetAll()
        {
            return Context.Room.ToList();
        }
    }
}
