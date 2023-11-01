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
    public class RegisterService
    {
        private readonly IRegisterRepository registerRepository;
        private readonly IMapper mapper;
        public RegisterService(IRegisterRepository registerRepository, IMapper mapper)
        {
            this.registerRepository = registerRepository;
            this.mapper = mapper;
        }
        public void DeleteRegister(RegisterDTO register)
        {
            registerRepository.DeleteRegister(mapper.Map<Register>(register));
        }

        public List<RegisterDTO> GetRegister()
        {
            return mapper.Map<List<RegisterDTO>>(registerRepository.GetRegister());
        }

        public RegisterDTO? GetRegister(int id,string cour)
        {
            return mapper.Map<RegisterDTO?>(registerRepository.GetRegister(id,cour));
        }

        public void SaveRegister(RegisterDTO register)
        {
            registerRepository.SaveRegister(mapper.Map<Register>(register));
        }

        public void UpdateRegister(RegisterDTO register)
        {
            registerRepository.UpdateRegister(mapper.Map<Register>(register));
        }
    }
}
