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
    public class InventoryService
    {
        static InventoryService()
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<InventoryProduct, InvProductModel>();
                cfg.CreateMap<InvProductModel, InventoryProduct>();
                cfg.CreateMap<InventoryOrdersDetail, InvProductDetailModel>();
                cfg.CreateMap<InvProductDetailModel, InventoryOrdersDetail>();
                cfg.CreateMap<InventoryOrdersTotal, InvOrderTotalModel>();
                cfg.CreateMap<InvOrderTotalModel, InventoryOrdersTotal>();
            });
        }
        public static List<InvProductModel> GetAllInventoryProduct()
        {
            var data = AutoMapper.Mapper.Map<List<InvProductModel>>(InventoryRepo.GetAllInventoryProduct());
            return data;
        }

        public static List<InvProductDetailModel> GetAllInventoryOrder()
        {
            var data = AutoMapper.Mapper.Map<List<InvProductDetailModel>>(InventoryRepo.GetAllInventoryOrder());
            return data;
        }

        public static List<InvOrderTotalModel> GetAllInventoryTotal()
        {
            var data = AutoMapper.Mapper.Map<List<InvOrderTotalModel>>(InventoryRepo.GetAllInventoryTotal());
            return data;
        }

        public static void CreateOrder(InvProductDetailModel des)
        {
            var data = Mapper.Map<InventoryOrdersDetail>(des);
            InventoryRepo.CreateOrder(data);
        }

        public static List<InvOrderTotalModel> PlaceOrder()
        {
            var data = AutoMapper.Mapper.Map<List<InvOrderTotalModel>>(InventoryRepo.PlaceOrder());
            return data;
        }

        public static void RecieveOrder(InvOrderTotalModel ot)
        {
            var data = Mapper.Map<InventoryOrdersTotal>(ot);
            InventoryRepo.RecieveOrder(data);
        }
    }
}
