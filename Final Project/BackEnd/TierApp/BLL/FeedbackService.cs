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
    public class FeedbackService
    {
        static FeedbackService()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Feedback, FeedbackModel>();
                cfg.CreateMap<FeedbackModel, Feedback>();
            });
        }

        public static List<FeedbackModel> GetAllFeedback()
        {
            var data = AutoMapper.Mapper.Map<List<FeedbackModel>>(FeedbackRepo.GetAllFeedback());
            return data;
        }
    }
}
