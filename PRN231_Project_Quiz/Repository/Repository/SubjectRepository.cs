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
    public class SubjectRepository : ISubjectRepository
    {
        public void DeleteSubject(Subject subject)
        {
            SubjectDAO.DeleteSubject(subject);
        }

        public Subject? GetSubject(string id)
        {
           return SubjectDAO.GetSubject(id);    
        }

        public List<Subject> GetSubjects()
        {
            return SubjectDAO.GetSubject();
        }

        public void SaveSubject(Subject subject)
        {
            SubjectDAO.SaveSubject(subject);
        }

        public void UpdateSubject(Subject subject)
        {
            SubjectDAO.UpdateSubject(subject);
        }
    }
}
