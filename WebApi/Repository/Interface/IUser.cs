using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Models;

public interface IUser
{
    Task<IEnumerable<UserModel>> AllUsers();
    Task<UserModel> GetUserById(int id);
    Task<UserModel> CreateUser(UserModel model);
    Task<UserModel> UpdateUser(UserModel model);
    Task<UserModel> DeleteUser(UserModel model);
}