using inverseyou.ddd.Entities;
using inverseyou.ddd.Repositories;
using inverseyou.infra.Services.AuthServices;
using inverseyou.infra.Services.EncryptionServices;
using inverseyou.presentation.Models;
using System;
using System.Collections.Generic;

namespace inverseyou.presentation.Services
{
    public class AuthService
    {
        private IUserRepository _userRepository;
        private UserRegisterService _userRegisterService;
        private readonly EncryptionManage _encryptionManage;

        public AuthService(IUserRepository userRepository,UserRegisterService userRegisterService,EncryptionManage encryptionManage)
        {
            _userRepository = userRepository;
            _userRegisterService = userRegisterService;
            _encryptionManage = encryptionManage;
        }

        public void RegisterNewUser(RegisterUser user,out Exception exception)
        {
            exception = null;
            try
            {
                var newUser = User.CreateNewUser(user.Name.Trim(), user.BirthDay, user.Email, user.MobileNumber, user.Password, user.GenderCode);
                _userRepository.AddNewUser(newUser);
                var token = _encryptionManage.Encrypt(new Dictionary<string, string> { { "Name",user.Name.Trim()},{ "ExpTime",DateTime.Now.AddMinutes(3).ToString()} });
                _userRegisterService.SendValidationEmail(user.Name, token);
            }
            catch(Exception ex)
            {
                exception = ex;
            }
        }

        public bool EmailComfirm(string name,string token,out Exception ex)
        {
            var isValid = _userRegisterService.ValidationUserEmail(name, token,out ex);
            if (isValid == true)
            {
                var user = _userRepository.GetUserByName(name);
                if (user != null)
                {
                    user.ActiveUserAccount();
                    _userRepository.SaveUserInfo(user);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        public void ActiveUserAccount(int id)
        {
            _userRegisterService.ActiveUserAccount(id);
        }

        public RegisterUser LoginUser(LoginUser user,out Exception exception)
        {
            exception = null;
            RegisterUser result = null;
            try
            {
                var loginUser = _userRepository.GetUserByNameAndPwd(user.Name, user.Password);
                if (loginUser != null)
                {
                    result = new RegisterUser
                    {
                        Id = loginUser.Id,
                        Name = loginUser.Name,
                        BirthDay=loginUser.BirthDay,
                        Email = loginUser.Email,
                        MobileNumber = loginUser.MobileNumber,
                        GenderCode = loginUser.GenderCode,
                        AccountStatusCode = loginUser.AccountStatusCode
                    };
                }
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            return result;
        }
    }
}
