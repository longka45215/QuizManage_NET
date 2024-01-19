using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class ExpertAssignDAO
    {
        public static List<ExpertAssign> GetExpertAssign()
        {
            var list = new List<ExpertAssign>();
            try
            {
                using (var context = new MyDbContext())
                {
                    list = context.ExpertAssigns.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }
        public static ExpertAssign? GetExpertAssign(int id, string subid)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    return context.ExpertAssigns.FirstOrDefault(a => a.UserId == id && a.SubjectId.Equals(subid));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void SaveExpertAssign(ExpertAssign expass)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    var item = context.ExpertAssigns
                       .FirstOrDefault(x => x.UserId == expass.UserId && x.SubjectId.Equals(expass.SubjectId));
                    if (item == null)
                    {
                        string sql =
                        "INSERT INTO [dbo].[ExpertAssign]([userID],[subjectID]) VALUES ({0}, {1})";
                        context.Database.ExecuteSqlRaw(sql, expass.UserId, expass.SubjectId);
                    }
                    else
                    {
                        throw new Exception("This Expert has been Assign to this Subject");
                    }

                }
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }
        public static void UpdateExpertAssign(ExpertAssign expass)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    context.Entry(expass).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static void DeleteExpertAssign(ExpertAssign expass)
        {
            try
            {
                using (var context = new MyDbContext())
                {

                    var p1 = context.ExpertAssigns
                        .FirstOrDefault(a => a.UserId == expass.UserId && a.SubjectId.Equals(expass.SubjectId));
                    if (p1 == null)
                    {
                        throw new Exception("not found");
                    }
                    string sql = "DELETE FROM [ExpertAssign] WHERE userID = {0} and subjectID like {1}";
                    context.Database.ExecuteSqlRaw(sql, expass.UserId, expass.SubjectId);


                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
