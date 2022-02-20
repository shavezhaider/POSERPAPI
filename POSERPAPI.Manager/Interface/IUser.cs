using Microsoft.AspNetCore.Identity;
using POSERPAPI.Entities.Request;
using POSERPAPI.Entities.Response;
using POSERPAPI.Repository.EDMX;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace POSERPAPI.Manager.Interface
{
    public interface IUser
    {
        public Task<AppUser> GetUserAuthenticationToken(UserAuthenticationRequest userAuthenticationRequest);
        public Task<AppUserResponse> AddUser(AppUserRequest appUserRequest);
        public Task<ForgotPasswordResponse> ForgotPassword(ForgotPasswordRequest appUserRequest);
        public Task<AppUser> GetUserByEmailAsyn(string email);
        public Task<AppUser> GetUserByUserAsyn(string UserName);
        public Task<AppUser> GetUserByIdAsyn(string Id);
        public Task<AppUser> ResetPassword(ResetPasswordRequest resetPassword);
    }
}

