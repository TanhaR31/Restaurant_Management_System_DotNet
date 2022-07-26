using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DAL;
using BEL;

namespace BLL
{
    public class AuthService
    {
        static AuthService()
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<User, UserModel>();
                cfg.CreateMap<UserModel, User>();
                cfg.CreateMap<Token, TokenModel>();
                cfg.CreateMap<TokenModel, Token>();
            });
        }
        public static TokenModel Auth(UserModel user)
        {
            var db_user = Mapper.Map<User>(user);
            var token = DataAccessFactory.AuthDataAccess().Authenticate(db_user);
            var tokenModel = Mapper.Map<TokenModel>(token);
            return tokenModel;
        }
        public static bool CheckValidityToken(string token)
        {
            var rs = DataAccessFactory.AuthDataAccess().IsAuthenticated(token);
            return rs;
        }
        public static bool Logout(string token)
        {
            return DataAccessFactory.AuthDataAccess().Logout(token);
        }
    }
}
