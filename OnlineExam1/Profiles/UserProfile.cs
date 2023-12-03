using AutoMapper;
using OnlineExam1.DTO;
using OnlineExam1.Entity;

namespace OnlineExam1.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
        }
    }
    
}
