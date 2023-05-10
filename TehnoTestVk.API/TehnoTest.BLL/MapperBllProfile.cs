using AutoMapper;
using TechnoTestVk.DAL.Models;
using TehnoTest.BLL.Models;

namespace TehnoTest.BLL
{
    public class MapperBllProfile : Profile
    {
        public MapperBllProfile()
        {
            CreateMap<UserEntity, UserModelBLL>().ReverseMap();
            CreateMap<UserGroupEntity, UserGroupModelBLL>();
            CreateMap<UserStateEntity, UserStateModelBLL>();
        }
    }
}
