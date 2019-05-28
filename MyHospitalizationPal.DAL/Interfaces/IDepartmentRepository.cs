using MyHospitalizationPal.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHospitalizationPal.DAL.Interfaces
{
    public interface IDepartmentRepository : IRepository<Department>
    {
        //IEnumerable<Department> GetDepartments(int id);
        void Create(Department entity);
        void Delete(int id);
        Department Details(int id);
        void Edit(Department entity);
        IEnumerable<Department> GetAll();
    }
}
