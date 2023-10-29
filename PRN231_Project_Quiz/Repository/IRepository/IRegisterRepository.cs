using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepository
{
    public interface IRegisterRepository
    {
        List<Register> GetRegister();
        Register? GetRegister(int id, string cour);
        void SaveRegister(Register register);
        void UpdateRegister(Register register);
        void DeleteRegister(Register register);
    }
}
