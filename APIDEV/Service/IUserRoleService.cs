﻿using APIDEV.Helper;
using APIDEV.Modal;
using APIDEV.Repos.Models;


namespace APIDEV.Service
{
    public interface IUserRoleServicecs
    {
        Task<APIResponse> AssignRolePermission(List<TblRolepermission> _data);
        Task<List<TblRole>> GetAllRoles();
        Task<List<TblMenu>> GetAllMenus();
        Task<List<Appmenu>> GetAllMenubyrole(string userrole);
        Task<Menupermission> GetMenupermissionbyrole(string userrole, string menucode);
    }
}