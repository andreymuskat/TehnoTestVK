using AutoMapper;
using TehnoTest.BLL.Models;
using TehnoTestVk.API.Models.UserGroupModels.Response;
using TehnoTestVk.API.Models.UserModels.Request;
using TehnoTestVk.API.Models.UserModels.Response;
using TehnoTestVk.API.Models.UserStateModels.Response;

namespace TehnoTestVk.API
{
    public class MapperApiProfile : Profile
    {
        public MapperApiProfile()
        {
            CreateMap<UserModelBLL, UserResponse>();
            CreateMap<UserRequest, UserModelBLL>();
            CreateMap<UserGroupModelBLL, UserGroupResponse>();
            CreateMap<UserStateModelBLL, UserStateResponse>();
        }
    }
}
