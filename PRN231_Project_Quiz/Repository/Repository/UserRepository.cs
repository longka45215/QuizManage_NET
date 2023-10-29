using BusinessObject.Models;
using DataAccess.DAO;
using Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class UserRepository : IUserRepository
    {
        public List<RoleName> GetRoleNames()
        {
            return UserDAO.GetRoleNames();
        }

        public List<User> GetUsers()
        {
            return UserDAO.GetUser();
        }

        public void SaveUser(User user)
        {
            UserDAO.SaveUser(user);
        }

        public void UpdateUser(User user)
        {
            UserDAO.UpdateUser(user);
        }
    }
}
