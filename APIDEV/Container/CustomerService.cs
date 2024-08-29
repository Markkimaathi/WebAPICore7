using APIDEV.Helper;
using APIDEV.Modal;
using APIDEV.Repos;
using APIDEV.Repos.Models;
using APIDEV.Service;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace APIDEV.Container
{
    public class CustomerService : ICustomerService
    {
        private readonly LearndataContext context;  
        private readonly IMapper  mapper;
        private readonly ILogger<CustomerService> logger;

        public CustomerService(LearndataContext context,IMapper mapper, ILogger<CustomerService> logger)
        {
            this.context = context;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<APIResponse> Create(Customermodal data)
        {
            APIResponse response = new APIResponse();
            try
            {
                this.logger.LogInformation("Create Begins");
                Brand _customer = this.mapper.Map<Customermodal, Brand>(data);
                await this.context.Brands.AddAsync(_customer);
                await this.context.SaveChangesAsync();
                response.ResponseCode = 201;
                response.Result = data.Code;
            }
            catch (Exception ex)
            {
                response.ResponseCode = 400;
                response.Errormessage = ex.Message;
                this.logger.LogError(ex.Message,ex);
            }
            return response;
        }

        public async Task<List<Customermodal>> Getall()
        { 
            List<Customermodal> _response = new List<Customermodal>();
            var _data= await this.context.Brands.ToListAsync();
            if(_data != null )
            {
                _response=this.mapper.Map<List<Brand>,List<Customermodal>>(_data);
            }
            return _response;
        }

        public async Task<Customermodal> Getbycode(string code)
        {
            Customermodal _response = new Customermodal();
            var _data = await this.context.Brands.FindAsync(code);
            if (_data != null)
            {
                _response = this.mapper.Map<Brand, Customermodal>(_data);
            }
            return _response;
        }

        public async Task<APIResponse> Remove(string code)
        {
            APIResponse response = new APIResponse();
            try
            {
                var _customer = await this.context.Brands.FindAsync(code);
                if (_customer != null)
                {
                    this.context.Brands.Remove(_customer);
                    await this.context.SaveChangesAsync();
                    response.ResponseCode = 200;
                    response.Result = code;
                }
                else
                {
                    response.ResponseCode = 404;
                    response.Errormessage = "Data not found";
                }
            }
            catch (Exception ex)
            {
                response.ResponseCode = 400;
                response.Errormessage = ex.Message;
            }
            return response;
        }

        public async Task<APIResponse> Update(Customermodal data, string code)
        {

            APIResponse response = new APIResponse();
            try
            {
                var _customer = await this.context.Brands.FindAsync(code);
                if (_customer != null)
                {
                    _customer.Name=data.Name;
                    _customer.Category=data.Category;
                    _customer.Id=data.Id;
                    _customer.IsActive=data.IsActive;
                    await this.context.SaveChangesAsync();
                    response.ResponseCode = 200;
                    response.Result = code;
                }
                else
                {
                    response.ResponseCode = 404;
                    response.Errormessage = "Data not found";
                }
            }
            catch (Exception ex)
            {
                response.ResponseCode = 400;
                response.Errormessage = ex.Message;
            }
            return response;
        }
    }
}