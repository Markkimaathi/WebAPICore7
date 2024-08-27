using AutoMapper;
using APIDEV.Modal;
using APIDEV.Repos.Models;

namespace APIDEV.Helper
{
    public class AutoMapperHandler : Profile
    {
        public AutoMapperHandler()
        {
            CreateMap<Brand, Customermodal>().ForMember(item => item.Statusname, opt => opt.MapFrom(
               item => (item.IsActive != null && item.IsActive.Value) ? "Active" : "In active")).ReverseMap();
        }
    }
}