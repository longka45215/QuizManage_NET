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
    public class RegisterRepository : IRegisterRepository
    {
        public void DeleteRegister(Register register)
        {
            RegisterDAO.DeleteRegister(register);
        }

        public List<Register> GetRegister()
        {
            return RegisterDAO.GetRegister();
        }

        public Register? GetRegister(int id, string cour)
        {
            return RegisterDAO.GetRegister(id,cour);
        }

        public void SaveRegister(Register register)
        {
            RegisterDAO.SaveRegister(register);
        }

        public void UpdateRegister(Register register)
        {
           RegisterDAO.UpdateRegister(register);
        }
    }
}
