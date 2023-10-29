using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepository
{
    public interface IExpertAssignRepository
    {
        List<ExpertAssign> GetExpertAssign();
        ExpertAssign? GetExpertAssign(int id, string subid);
        void SaveExpertAssign(ExpertAssign expass);
        void UpdateExpertAssign(ExpertAssign expass);
        void DeleteExpertAssign(ExpertAssign expass);
    }
}

