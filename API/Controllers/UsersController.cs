using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class UsersController : BaseApiController
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UsersController(IUserRepository userRepository, IMapper mapper)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberDTO>>> GetUsers()
        {
            IEnumerable<MemberDTO> users = await _userRepository.GetMembersAsync();
 
            return Ok(users);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<MemberDTO>> GetUserById(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null) return NotFound("User with this id doesn't exist");
            MemberDTO member = _mapper.Map<MemberDTO>(user);
 
            return member;
        }

        [Authorize]
        [HttpGet("find/{username}")]
        public async Task<ActionResult<MemberDTO>> GetUserByUsername(string username)
        {
            MemberDTO user = await _userRepository.GetMemberByUsernameAsync(username);
            if (user == null) return NotFound("User with this username doesn't exist"); 
            return user;
        }
        
        [Authorize]
        [HttpPut]
        public async Task<ActionResult> UpdateUser(MemberUpdateDTO memberUpdate)
        {
            string username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            AppUser user = await _userRepository.GetUserByUsernameAsync(username);
            if (user == null) return NotFound("User not found");

            _mapper.Map(memberUpdate, user);
            _userRepository.Update(user);

            if(await _userRepository.SaveAllAsync()) return NoContent();

            return BadRequest("Failed to update user");
        }

    }
}