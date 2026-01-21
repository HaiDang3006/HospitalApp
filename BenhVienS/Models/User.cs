using System;

namespace BenhVienS.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool Gender { get; set; }
        public int RoleId { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Parameterless constructor
        public User()
        {
        }

        // Full constructor
        public User(
            int userId,
            string username,
            string passwordHash,
            string fullName,
            string email,
            string phoneNumber,
            string address,
            DateTime dateOfBirth,
            bool gender,
            int roleId,
            bool status,
            DateTime createdAt,
            DateTime updatedAt)
        {
            UserId = userId;
            Username = username;
            PasswordHash = passwordHash;
            FullName = fullName;
            Email = email;
            PhoneNumber = phoneNumber;
            Address = address;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            RoleId = roleId;
            Status = status;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }
    }
}
