using MyHospitalizationPal.DAL.Interfaces;
using MyHospitalizationPal.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHospitalizationPal.DAL.Repository
{
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        
        public ApplicationContext Context
        {
            get
            {
                return db as ApplicationContext;
            }
        }
        public DepartmentRepository(ApplicationContext context) : base (context)
        {

        }
        
        public void Create(Department entity)
        {
           // this.Add(entity);
            Context.Department.Add(entity);
            Context.SaveChanges();
        }

        public void Delete(int id)
        {
           // Delete((Department)Get(e => e.Id == id));
            var department = Context.Department.SingleOrDefault(d => d.Id == id);
            Context.Department.Remove(department);
            Context.SaveChanges();
        }

        public Department Details(int id)
        {
            return Context.Department.SingleOrDefault(d => d.Id == id);
        }

        public void Edit(Department entity)
        {
            Context.Department.Update(entity);
            Context.SaveChanges();
        }

        public IEnumerable<Department> GetAll()
        {
            return Context.Department.ToList();
        }
    }
}
