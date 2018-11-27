using inverseyou.ddd.Entities;
using inverseyou.ddd.Events;
using inverseyou.ddd.Repositories;
using inverseyou.ddd.Values;
using inverseyou.infra.PersistStoreModel;
using MediatR;
using System;
using System.Linq;

namespace inverseyou.infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly EFBaseRepository _baseRepository;
        private readonly IMediator _mediatR;
        public UserRepository(EFBaseRepository baseRepository, IMediator mediatR)
        {
            _baseRepository = baseRepository;
            _mediatR = mediatR;
        }

        int IUserRepository.GetUsersSummary(Gender? gender, DateTime? birthDayL,DateTime? birthDayR, UserAccountStatus? accountStatus)
        {
            var result = _baseRepository.Inv_User.AsQueryable();

            if(gender.HasValue)
            {
                result = result.Where(u => u.GenderCode == (int)gender.Value);
            }
            if(birthDayL.HasValue)
            {
                result = result.Where(u => u.BirthDay >= birthDayL.Value);
            }
            if(birthDayR.HasValue)
            {
                result = result.Where(u => u.BirthDay <= birthDayR.Value);
            }
            if (accountStatus.HasValue)
            {
                result = result.Where(u => u.AccountStatusCode == (int)accountStatus);
            }

            return result.Count();
        }

        int GetUserSequenceId()
        {
            var users = _baseRepository.Inv_User;
            if(users == null || users.Count()<=0)
            {
                return 0;
            }
            else
            {
                return users.Max(u => u.Id);
            }
        }

        void IUserRepository.AddNewUser(User user)
        {
            var id = GetUserSequenceId();
            _baseRepository.Inv_User.Add(new Inv_User
            {
                Id = id + 1,
                Name=user.Name,
                BirthDay=user.BirthDay,
                Email=user.Email,
                MobileNumber=user.MobileNumber,
                Password=user.Password,
                GenderCode=(int)user.GenderCode,
                GenderText=user.GenderText,
                AccountStatusCode=(int)user.AccountStatusCode,
                AccountStatusText=user.AccountStatusText
            });

            (this as IRepository).SaveChanges();
        }

        void IUserRepository.ChangeUserAccountStatus(User user)
        {
            _baseRepository.Inv_User.FirstOrDefault(u => u.Id == user.Id);
        }

        User IUserRepository.GetUserById(int userId)
        {
            User user = null;
            var invUser = _baseRepository.Inv_User.FirstOrDefault(u=>u.Id==userId);
            if(invUser!=null)
            {
                user = new User
                {
                    Id = invUser.Id,
                    Name = invUser.Name,
                    Email = invUser.Email,
                    Password = invUser.Password,
                    MobileNumber = invUser.MobileNumber,
                    GenderCode = (Gender)invUser.GenderCode,
                    AccountStatusCode = (UserAccountStatus)invUser.AccountStatusCode
                };
            }

            return user;
        }

        User IUserRepository.GetUserByName(string name)
        {
            User user = null;
            var invUser = _baseRepository.Inv_User.FirstOrDefault(u=>u.Name==name);
            if (invUser != null)
            {
                user = new User
                {
                    Id = invUser.Id,
                    Name = invUser.Name,
                    Email = invUser.Email,
                    Password = invUser.Password,
                    MobileNumber = invUser.MobileNumber,
                    GenderCode = (Gender)invUser.GenderCode,
                    AccountStatusCode = (UserAccountStatus)invUser.AccountStatusCode
                };
            }

            return user;
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