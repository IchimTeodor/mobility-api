using MyHospitalizationPal.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHospitalizationPal.DAL.Interfaces
{
    public interface IUserInfoRepository : IRepository<UserInfo>
    {
        void Create(UserInfo entity);
        void Delete(int id);
        UserInfo Details(int id);
        void Edit(UserInfo entity);
        IEnumerable<UserInfo> GetAll();
        UserInfo GetUserByUnicodeId(string unicode);
    }
}