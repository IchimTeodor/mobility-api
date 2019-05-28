using MyHospitalizationPal.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHospitalizationPal.DAL.Interfaces
{
    public interface IRoomRepository : IRepository<Room>
    {
        void Create(Room entity);
        void Delete(int id);
        Room Details(int id);
        void Edit(Room entity);
        IEnumerable<Room> GetAll();

    }
}
