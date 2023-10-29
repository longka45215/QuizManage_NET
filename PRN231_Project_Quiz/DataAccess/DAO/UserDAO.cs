using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class UserDAO
    {
        public static List<User> GetUser()
        {
            var list = new List<User>();
            try
            {
                using (var context = new MyDbContext())
                {
                    list = context.Users.Include(u=>u.Role).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }
        public static List<RoleName> GetRoleNames() {
            var list = new List<RoleName>();
            try
            {
                using (var context = new MyDbContext())
                {
                    list = context.RoleNames.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }
       
        public static void SaveUser(User quiz)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    context.Users.Add(quiz);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }
        public static void UpdateUser(User quiz)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    context.Entry(quiz).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        
    }
}
