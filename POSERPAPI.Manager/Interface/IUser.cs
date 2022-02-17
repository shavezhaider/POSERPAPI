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
        public Task<ForgotPasswordResponse> ForgotPassword(ForgotPasswordRequest appUserRequest);
        public Task<IdentityUser> GetUserByEmailAsyn(string email);
        public Task<IdentityUser> GetUserByUserAsyn(string UserName);
        public Task<IdentityUser> GetUserByIdAsyn(string Id);
        public Task<IdentityUser> ResetPassword(ResetPasswordRequest resetPassword);
    }
}

