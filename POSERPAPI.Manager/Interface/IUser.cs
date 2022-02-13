using Microsoft.AspNetCore.Identity;
using POSERPAPI.Entities.Request;
using POSERPAPI.Entities.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace POSERPAPI.Manager.Interface
{
    public interface IUser
    {
        public Task<IdentityUser> GetUserAuthenticationToken(UserAuthenticationRequest userAuthenticationRequest);
        public Task<AppUserResponse> AddUser(AppUserRequest appUserRequest);
    }
}

