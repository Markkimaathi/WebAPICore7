using APIDEV.Repos;
using APIDEV.Repos.Models;
using APIDEV.Service;

namespace APIDEV.Container
{
    public class CustomerService : ICustomerService
    {
        private readonly LearndataContext context;

        public CustomerService(LearndataContext context)
        {
            this.context = context;
        }
        public List<Brand> GetAll()
        {
            return this.context.Brands.ToList();
        }
    }
}
