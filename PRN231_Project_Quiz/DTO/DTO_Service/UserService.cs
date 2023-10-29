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
    public class UserService
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        public List<UserDTO> GetUser()
        {
            return mapper.Map<List<UserDTO>>(userRepository.GetUsers());
        }
        public List<RoleDTO> GetRoles()
        {
            return mapper.Map<List<RoleDTO>>(userRepository.GetRoleNames());
        }

        public void SaveUser(UserDTO user)
        {
            userRepository.SaveUser(mapper.Map<User>(user));
        }

        public void UpdateUser(UserDTO user)
        {
            userRepository.UpdateUser(mapper.Map<User>(user));
        }
    }
}
