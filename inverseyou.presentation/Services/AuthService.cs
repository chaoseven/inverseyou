using inverseyou.ddd.Entities;
using inverseyou.ddd.Repositories;
using inverseyou.presentation.Models;
using System;

namespace inverseyou.presentation.Services
{
    public class AuthService
    {
        private IUserRepository _userRepository;
        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void RegisterNewUser(RegisterUser user,out Exception exception)
        {
            exception = null;
            try
            {
                var newUser = User.CreateNewUser(user.Name, user.BirthDay, user.Email, user.MobileNumber, user.Password, user.GenderCode);
                _userRepository.AddNewUser(newUser);
            }
            catch(Exception ex)
            {
                exception = ex;
            }
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
