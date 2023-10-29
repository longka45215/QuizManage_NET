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
    public class ExpertAssignRepository : IExpertAssignRepository
    {
        public void DeleteExpertAssign(ExpertAssign expass)
        {
            ExpertAssignDAO.DeleteExpertAssign(expass);
        }

        public List<ExpertAssign> GetExpertAssign()
        {
            return ExpertAssignDAO.GetExpertAssign();
        }

        public ExpertAssign? GetExpertAssign(int id, string subid)
        {
            return ExpertAssignDAO.GetExpertAssign(id,subid);
        }

        public void SaveExpertAssign(ExpertAssign expass)
        {
            ExpertAssignDAO.SaveExpertAssign(expass);
        }

        public void UpdateExpertAssign(ExpertAssign expass)
        {
            ExpertAssignDAO.UpdateExpertAssign(expass);
        }
    }
}
