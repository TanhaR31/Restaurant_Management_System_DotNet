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
    public class DeliveryDeliverymanService
    {
        static DeliveryDeliverymanService()
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<Delivery, DeliveryModel>();
                cfg.CreateMap<DeliveryModel, Delivery>();
                cfg.CreateMap<DeliverymansDetail, DeliverymanModel>();
                cfg.CreateMap<DeliverymanModel, DeliverymansDetail>();
                cfg.CreateMap<Order, OrderModel>();
                cfg.CreateMap<OrderModel, Order>();
            });
        }

        public static List<DeliveryModel> GetAllDeliveries()
        {
            var data = AutoMapper.Mapper.Map<List<DeliveryModel>>(DeliveryDeliverymanRepo.GetAllDeliveries());
            return data;
        }

        public static List<OrderModel> GetAllOrder()
        {
            var data = AutoMapper.Mapper.Map<List<OrderModel>>(DeliveryDeliverymanRepo.GetAllOrder());
            return data;
        }

        public static List<DeliverymanModel> GetAllDeliveryman()
        {
            var data = AutoMapper.Mapper.Map<List<DeliverymanModel>>(DeliveryDeliverymanRepo.GetAllDeliveryman());
            return data;
        }

        public static List<DeliverymanModel> GetFreeDeliveryman()
        {
            var data = AutoMapper.Mapper.Map<List<DeliverymanModel>>(DeliveryDeliverymanRepo.GetFreeDeliveryman());
            return data;
        }

        public static void Assign(DeliveryModel des)
        {
            var data = Mapper.Map<Delivery>(des);
            DeliveryDeliverymanRepo.AssignDeliveryman(data);
        }
    }
}
