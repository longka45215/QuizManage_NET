using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class RegisterDAO
    {
        public static List<Register> GetRegister()
        {
            var list = new List<Register>();
            try
            {
                using (var context = new MyDbContext())
                {
                    list = context.Registers.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }
        public static Register? GetRegister(int id, string cour)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    return context.Registers.FirstOrDefault(a => a.UserId == id && a.CourseId.Equals(cour));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void SaveRegister(Register res)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    string sql = 
                        "INSERT INTO Register ([userID],[courseID]) VALUES ({0}, {1})";
                    context.Database.ExecuteSqlRaw(sql, res.UserId, res.CourseId );

                }
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }
        public static void UpdateRegister(Register res)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    context.Entry(res).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static void DeleteRegister(Register res)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    var p1 = context.Registers
                        .SingleOrDefault(a => a.UserId == res.UserId && a.CourseId.Equals(res.CourseId));
                    if (p1 == null)
                    {
                        throw new Exception("not found");
                    }
                    string sql = "DELETE FROM Register WHERE userID = {0} and courseID like {1}";
                    context.Database.ExecuteSqlRaw(sql, res.UserId, res.CourseId);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
