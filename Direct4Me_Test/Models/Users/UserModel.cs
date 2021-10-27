using Direct4Me_Test.Entities;
using System.ComponentModel.DataAnnotations;

namespace Direct4Me_Test.Models.Users
{
  public class UserModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
    }
}