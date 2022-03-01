using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using POSERPAPI.Entities.Entity;
using POSERPAPI.Entities.Request;
using POSERPAPI.Entities.Response;
using POSERPAPI.Manager.Interface;
using POSERPAPI.Repository.EDMX;
using POSERPAPI.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using static POSERPAPI.Utilities.Enums;

namespace POSERPAPI.Manager.Implementation
{
    public class UserManagerRepo : IUser
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        ProcessingStatusEntity processingStatusEntity;
        private readonly IEmailSender _emailSender;
        private readonly ISetting _setting;
        // private readonly JwtHandler _jwtHandler;
        public UserManagerRepo(UserManager<AppUser> userManager, IMapper mapper, IEmailSender emailSender,
            ISetting setting)
        {
            _userManager = userManager;
            _mapper = mapper;
            _emailSender = emailSender;
            _setting = setting;
            processingStatusEntity = new ProcessingStatusEntity();


        }

        public async Task<AppUserResponse> AddUser(AppUserRequest appUserRequest)
        {
            AppUserResponse appUserResponse = new AppUserResponse();

            #region Check Duplication Records by email
            var userDetail = GetUserByEmailAsyn(appUserRequest.appUserEntity.Email);
            if (userDetail == null)
            {
                processingStatusEntity.StatusCode = (int)statusCode.DuplicateRecord;
                processingStatusEntity.Message = "Duplicate user email not allowed";
                appUserResponse.processingStatus = processingStatusEntity;
                return appUserResponse;
            }
            #endregion
            #region Check Duplication Records by user name
            var userDetailByuser = GetUserByEmailAsyn(appUserRequest.appUserEntity.UserName);
            if (userDetailByuser == null)
            {
                processingStatusEntity.StatusCode = (int)statusCode.DuplicateRecord;
                processingStatusEntity.Message = "Duplicate user name not allowed";
                appUserResponse.processingStatus = processingStatusEntity;
                return appUserResponse;
            }
            #endregion
            var user = _mapper.Map<AppUser>(appUserRequest.appUserEntity);
            var result = await _userManager.CreateAsync(user, appUserRequest.appUserEntity.Password);


            if (!result.Succeeded)
            {
                var errors = ConvertIdentityErrorToErrorList(result.Errors);
                ErrorEntity errorEntity = new ErrorEntity();
                errorEntity.ErrorCode = Constants.Failure;

                processingStatusEntity.StatusCode = (int)statusCode.Failure;

                processingStatusEntity.Message = ConvertErrorListToString(errors);
                processingStatusEntity.Errors = new List<ErrorEntity>();
                processingStatusEntity.Errors.AddRange(errors);

            }
            else
            {
                var userRole = await _userManager.AddToRoleAsync(user, appUserRequest.appUserEntity.Role);
                processingStatusEntity.StatusCode = (int)statusCode.Success;
                processingStatusEntity.Message = Constants.RegistrationSuccess;
            }
            appUserResponse.processingStatus = processingStatusEntity;

            return appUserResponse;

        }

        public async Task<ForgotPasswordResponse> ForgotPassword(ForgotPasswordRequest appUserRequest)
        {
            ForgotPasswordResponse passwordResponse = new ForgotPasswordResponse();
            var user = await _userManager.FindByNameAsync(appUserRequest.UserName);
            if (user != null)
            {
                
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                token = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(token));
                var resultSetting = _setting.GetSettingByName(DataConstants.DOMAIN_URL);

                var callbackUrl = resultSetting.Value + "resetpassword/" + token + "/"+user.Email;
                EmailModalRequest emailModal = new EmailModalRequest();
                string msgurl = $"Please reset your password by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.";
                emailModal.Body = msgurl;
                emailModal.Subject = "Reset Password";
                emailModal.ToEmailId = user.Email;
                bool funBool = _emailSender.SendEmail(emailModal);
                if (funBool)
                {
                    processingStatusEntity.Message = "Please check your email for password reset instructions";
                    processingStatusEntity.StatusCode = (int)statusCode.Success;

                }
                else
                {
                    processingStatusEntity.Message = "Something went wrong while sending email, Please try again.";
                    processingStatusEntity.StatusCode = (int)statusCode.Error;
                }
                passwordResponse.processingStatus = processingStatusEntity;
            }
            return passwordResponse;
        }

        public async Task<AppUser> GetUserAuthenticationToken(UserAuthenticationRequest userAuthenticationRequest)
        {
            var user = await _userManager.FindByNameAsync(userAuthenticationRequest.UserName);
            if (user == null || !await _userManager.CheckPasswordAsync(user, userAuthenticationRequest.Password))
                return null;
            else
                return user;

        }

        public async Task<AppUser> GetUserByEmailAsyn(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<AppUser> GetUserByIdAsyn(string UserId)
        {
            return await _userManager.FindByIdAsync(UserId);
        }

        public async Task<AppUser> GetUserByUserAsyn(string UserName)
        {
            return await _userManager.FindByNameAsync(UserName);
        }

        public async Task<ProcessingStatusEntity> ResetPassword(ResetPasswordRequest resetPassword)
        {
            var user = await _userManager.FindByEmailAsync(resetPassword.Email);
            if (user == null)
            { }
            var token = resetPassword.Token;
           // resetPassword.Token = WebEncoders.Base64UrlDecode(Encoding.UTF8.GetBytes(token));
            var resetPassResult = await _userManager.ResetPasswordAsync(user, resetPassword.Token, resetPassword.Password);
            if (!resetPassResult.Succeeded)
            {
                var error = ConvertIdentityErrorToErrorList(resetPassResult.Errors);


                processingStatusEntity.Message = ConvertErrorListToString(error);
                processingStatusEntity.StatusCode = (int)statusCode.Failure;
            }
            else
            {
                processingStatusEntity.Message = "";
                processingStatusEntity.StatusCode = (int)statusCode.Success;
            }
            return processingStatusEntity;
        }

        public string ConvertErrorListToString(List<ErrorEntity> errors)
        {
            string errorMessage = string.Empty;
            foreach (var error in errors)
            {
                errorMessage = errorMessage + "Error Code: " + error.ErrorCode + "\nMessage: " + error.ErrorDescription;
            }
            return errorMessage;
        }

        public List<ErrorEntity> ConvertIdentityErrorToErrorList(IEnumerable<IdentityError> errorslist)
        {
            var errors = (from r in errorslist
                          select new ErrorEntity
                          {
                              ErrorCode = r.Code,
                              ErrorDescription = r.Description
                          }).ToList();
            return errors;
        }


    }
}
