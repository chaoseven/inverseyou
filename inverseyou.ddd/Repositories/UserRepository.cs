using inverseyou.ddd.Entities;

namespace inverseyou.ddd.Repositories
{
    public interface IUserRepository:IRepository<User>
    {
        void AddNewUser(User user);

        User GetUserById(int userId);

        User GetUserByNameAndPwd(string name, string pwd);

        void UpdateUserBasicInfo(User user);

        void ChangeUserAccountStatus(User user);
    }
}
