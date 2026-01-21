using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenhVienS.Models
{
    public class UserSession
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public int Role { get; set; }
        public DateTime ExpiredAt { get; set; }
    }
}
