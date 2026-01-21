using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenhVienS.Enums;
namespace BenhVienS.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public bool Gender {  get; set; }
        public DateTime BirthDay { get; set; }
        public int role { get; set; }
        public bool isStatus { get; set; }
        public DateTime Create_Day { get; set; }
        public DateTime Update_Day { get; set; }

    }

}
