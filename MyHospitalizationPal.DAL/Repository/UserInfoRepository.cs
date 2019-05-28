using MyHospitalizationPal.DAL.Interfaces;
using MyHospitalizationPal.DAL.Models;
using MyHospitalizationPal.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHospitalizationPal.Server.DAO.Repository
{
    public class UserInfoRepository : Repository<UserInfo>, IUserInfoRepository 
    {
        private ApplicationContext Context
        {
            get
            {
                return db as ApplicationContext;
            }
        }
        public UserInfoRepository(ApplicationContext context) : base(context)
        {
            
        }
        
        public void Create(UserInfo entity)
        {
            Context.UserInfo.Add(entity);
            Context.SaveChanges();
        }

        public void Delete(int id)
        {
            var userinfo = Context.UserInfo.SingleOrDefault(p => p.Id == id);
            Context.UserInfo.Remove(userinfo);
            Context.SaveChanges();
        }

        public UserInfo Details(int id)
        {
            var userinfo = Context.UserInfo.SingleOrDefault(p => p.Id == id);
            return userinfo;
        }

        public void Edit(UserInfo entity)
        {
            Context.UserInfo.Update(entity);
            Context.SaveChanges();
        }

        public IEnumerable<UserInfo> GetAll()
        {
            var userinfo = Context.UserInfo.ToList();
            return userinfo;
        }

        public UserInfo GetUserByUnicodeId(string unicode)
        {
            return Context.UserInfo.SingleOrDefault(u => u.UniqueCodeId.Equals(unicode));
        }

    }
}
