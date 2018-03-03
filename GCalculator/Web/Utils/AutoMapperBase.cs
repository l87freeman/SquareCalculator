using AutoMapper;
using Services.Models;
using Web.Models;

namespace Web.Utils
{
    public static class AutoMapperBase
    {
        public static IMapper Mapper { get; private set; }

        static AutoMapperBase()
        {
            var config = new MapperConfiguration(x =>
            {
                x.CreateMap<Point, PointDto>().ReverseMap();
                x.CreateMap<CalculationResult, CalculationResultDto>().ReverseMap();
                x.CreateMap<MessageGrb, MessageDto>().ReverseMap();
                x.CreateMap<LogDescription, LogDescriptionDto>().ReverseMap();
            });

            Mapper = config.CreateMapper();
        }
    }
}