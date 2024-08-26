using APIDEV.Modal;
using APIDEV.Repos.Models;

namespace APIDEV.Service
{
    public interface ICustomerService
    {
        List<Customermodal> GetAll();
    }
}
