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
    public class DeliverymanService
    {
        static DeliverymanService()
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<DeliverymansDetail, DeliverymanModel>();
                cfg.CreateMap<DeliverymanModel, DeliverymansDetail>();
            });
        }

        public static List<DeliverymanModel> Get()
        {
            var data = AutoMapper.Mapper.Map<List<DeliverymanModel>>(DataAccessFactory.DeliverymanDataAccess().Get()); 
            return data;
        }
        public static DeliverymanModel Get(int id)
        {

            var data = Mapper.Map<DeliverymanModel>(DataAccessFactory.DeliverymanDataAccess().Get(id)); 
            return data;
        }
        public static void Create(DeliverymanModel user)
        {

            var data = Mapper.Map<DeliverymansDetail>(user); 
            DataAccessFactory.DeliverymanDataAccess().Add(data);

        }
        public static void Edit(DeliverymanModel user)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<DeliverymanModel, DeliverymansDetail>());
            var data = Mapper.Map<DeliverymansDetail>(user); 
            DataAccessFactory.DeliverymanDataAccess().Edit(data);

        }
        public static void Delete(int id)
        {
            DataAccessFactory.DeliverymanDataAccess().Delete(id);
        }
    }
}
