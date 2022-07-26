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
    public class ManagerService
    {
        static ManagerService()
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<ManagersDetail, ManagerModel>();
                cfg.CreateMap<ManagerModel, ManagersDetail>();
            });
        }
        public static void Edit(ManagerModel man)
        {
            var data = Mapper.Map<ManagersDetail>(man);
            ManagerRepo.Edit(data);
        }

        public static ManagerModel Getinfo()
        {
            var data = Mapper.Map<ManagerModel>(ManagerRepo.GetInfo());
            return data;
        }
    }
}
