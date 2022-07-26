using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BEL;
using DAL;

namespace BLL
{
    public class UserService
    {
        static UserService()
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<User, UserModel>();
                cfg.CreateMap<UserModel, User>();
            });
        }
        public static List<UserModel> Get()
        {
            var data = AutoMapper.Mapper.Map<List<UserModel>>(DataAccessFactory.UserDataAccess().Get());
            return data;
        }
        public static UserModel Get(int id)
        {
            var data = Mapper.Map<UserModel>(DataAccessFactory.UserDataAccess().Get(id));
            return data;
        }
        public static void Create(UserModel user)
        {
            var data = Mapper.Map<User>(user);
            DataAccessFactory.UserDataAccess().Add(data);

        }
        public static void Edit(UserModel user)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<UserModel, User>());
            var data = Mapper.Map<User>(user);
            DataAccessFactory.UserDataAccess().Edit(data);

        }
        public static void Delete(int id)
        {
            DataAccessFactory.UserDataAccess().Delete(id);
        }
    }
}
