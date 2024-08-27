using APIDEV.Modal;
using APIDEV.Repos;
using APIDEV.Repos.Models;
using APIDEV.Service;
using AutoMapper;

namespace APIDEV.Container
{
    public class CustomerService : ICustomerService
    {
        private readonly LearndataContext context;
        private readonly IMapper  mapper;

        public CustomerService(LearndataContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public List<Customermodal> GetAll()
        { 
            List<Customermodal> _response = new List<Customermodal>();
            var _data= this.context.Brands.ToList();
            if(_data != null )
            {
                _response=this.mapper.Map<List<Brand>,List<Customermodal>>(_data);
            }
            return _response;
        }
    }
}
