using inverseyou.ddd.Entities;
using inverseyou.ddd.Repositories;
using inverseyou.ddd.Values;
using inverseyou.infra.PersistStoreModel;
using System;
using System.Linq;

namespace inverseyou.infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly EFBaseRepository _baseRepository;
        public UserRepository(EFBaseRepository baseRepository)
        {
            _baseRepository = baseRepository;
        }

        void IUserRepository.AddNewUser(User user)
        {
        }

        void IUserRepository.ChangeUserAccountStatus(User user)
        {
            _baseRepository.Inv_User.FirstOrDefault(u => u.Id == user.Id);
        }

        User IUserRepository.GetUserById(int userId)
        {
            var invUser = _baseRepository.Inv_User.FirstOrDefault();
            return null;
        }

        User IUserRepository.GetUserByNameAndPwd(string name, string pwd)
        {
            User result = null;
            var user = _baseRepository.Inv_User.FirstOrDefault(u => u.Name == name && u.Password == pwd);
            if(user != null)
            {
                result = User.GetValidUser(user.Id, user.Name, user.BirthDay, user.Email, user.MobileNumber, user.Password, (Gender)user.GenderCode, (UserAccountStatus)user.AccountStatusCode);
            }

            return result;
        }

        void IUserRepository.UpdateUserBasicInfo(User user)
        {
            throw new NotImplementedException();
        }

        void IRepository.SaveChanges()
        {
            _baseRepository.SaveChanges();
        }
    }
}
