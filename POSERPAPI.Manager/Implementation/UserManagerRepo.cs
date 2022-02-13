using AutoMapper;
using Microsoft.AspNetCore.Identity;
using POSERPAPI.Entities.Entity;
using POSERPAPI.Entities.Request;
using POSERPAPI.Entities.Response;
using POSERPAPI.Manager.Interface;
using POSERPAPI.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSERPAPI.Manager.Implementation
{
    public class UserManagerRepo : IUser
    {
        private readonly UserManager<IdentityUser> _userManager;
         private readonly IMapper _mapper;
        // private readonly JwtHandler _jwtHandler;
        public UserManagerRepo(UserManager<IdentityUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;

        }

        public async Task<AppUserResponse> AddUser(AppUserRequest appUserRequest)
        {
            var user = _mapper.Map<IdentityUser>(appUserRequest.appUserEntity);
            user.UserName = "Admin";
           var result= await _userManager.CreateAsync(user, appUserRequest.appUserEntity.Password);
            ProcessingStatusEntity processingStatusEntity = new ProcessingStatusEntity();
            AppUserResponse appUserResponse = new AppUserResponse();
            
            if (!result.Succeeded)
            {
                var errors = (from r in result.Errors
                              select new ErrorEntity
                              {
                                  ErrorCode = r.Code,
                                  ErrorDescription = r.Description
                              }).ToList();
                            
                ErrorEntity errorEntity = new ErrorEntity();
                errorEntity.ErrorCode = Constants.Failure;
                //errorEntity.ErrorDescription = errors;

                processingStatusEntity.Status = Constants.Failure;
                processingStatusEntity.Errors = new List<ErrorEntity>();
                processingStatusEntity.Errors.AddRange(errors);                
                //return 

            }
            else
            {
                processingStatusEntity.Status = Constants.Success;
            }
            appUserResponse.processingStatus = processingStatusEntity;
            return appUserResponse;
            
        }

        public async Task<IdentityUser> GetUserAuthenticationToken(UserAuthenticationRequest userAuthenticationRequest)
        {
            var user = await _userManager.FindByNameAsync(userAuthenticationRequest.UserName);
            if (user == null || !await _userManager.CheckPasswordAsync(user, userAuthenticationRequest.Password))
                return null;
            else
                return   user;

        }
    }
}
