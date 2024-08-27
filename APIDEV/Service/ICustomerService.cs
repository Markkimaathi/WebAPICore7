using APIDEV.Helper;
using APIDEV.Modal;
using APIDEV.Repos.Models;

namespace APIDEV.Service
{
    public interface ICustomerService
    {
        Task<List<Customermodal>> Getall();

        Task<Customermodal> Getbycode(string code);

        Task<APIResponse> Remove(string code);

        Task<APIResponse> Create(Customermodal data);

        Task<APIResponse> Update(Customermodal data,string code);
    }
}
