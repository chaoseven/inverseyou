using inverseyou.ddd.Entities;
using inverseyou.ddd.Values;
using System;

namespace inverseyou.ddd.Repositories
{
    public interface IUserRepository:IRepository<User>
    {
        int GetUsersSummary(Gender? gender, DateTime? birthDayL, DateTime? birthDayR, UserAccountStatus? accountStatus);

        void AddNewUser(User user);

        User GetUserById(int userId);

        User GetUserByName(string name);

        User GetUserByNameAndPwd(string name, string pwd);

        void UpdateUserBasicInfo(User user);

        void ChangeUserAccountStatus(User user);
    }
}
