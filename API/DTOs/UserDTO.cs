using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class UserDTO
    {
        public string Username { get; set; }
        public string NickName { get; set; }
        public string About { get; set; }
        public string PhotoUrl { get; set; }
        public string Token { get; set; }
    }
}