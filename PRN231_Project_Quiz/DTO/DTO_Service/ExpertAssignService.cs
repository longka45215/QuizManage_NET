using AutoMapper;
using BusinessObject.Models;
using DTO.DTOs;
using Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DTO_Service
{
    public class ExpertAssignService
    {
        private readonly IExpertAssignRepository expertAssignRepository;
        private readonly IMapper mapper;
        public ExpertAssignService(IExpertAssignRepository expertAssignRepository, IMapper mapper)
        {
            this.expertAssignRepository = expertAssignRepository;
            this.mapper = mapper;
        }
        public void DeleteExpertAssign(ExpertAssignDTO expass)
        {
            expertAssignRepository.DeleteExpertAssign(mapper.Map<ExpertAssign>(expass));
        }

        public List<ExpertAssignDTO> GetExpertAssign()
        {
            return mapper.Map<List<ExpertAssignDTO>>(expertAssignRepository.GetExpertAssign());
        }

        public ExpertAssign? GetExpertAssign(int id,string subid)
        {
            return mapper.Map<ExpertAssign?>(expertAssignRepository.GetExpertAssign(id,subid));
        }

        public void SaveExpertAssign(ExpertAssignDTO expass)
        {
            expertAssignRepository.SaveExpertAssign(mapper.Map<ExpertAssign>(expass));
        }

        public void UpdateExpertAssign(ExpertAssignDTO expass)
        {
            expertAssignRepository.UpdateExpertAssign(mapper.Map<ExpertAssign>(expass));
        }
    }
}
