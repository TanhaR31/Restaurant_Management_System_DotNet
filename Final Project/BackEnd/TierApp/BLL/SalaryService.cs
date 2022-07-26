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
    public class SalaryService
    {
        static SalaryService()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Salary, SalaryModel>();
                cfg.CreateMap<SalaryModel, Salary>();
            });
        }

        public static List<SalaryModel> GetSalary()
        {
            var data = AutoMapper.Mapper.Map<List<SalaryModel>>(SalaryRepo.GetSalary());
            return data;
        }

        public static void GiveSalary(SalaryModel sal)
        {
            var data = Mapper.Map<Salary>(sal);
            SalaryRepo.GiveSalary(data);
        }
    }
}
