using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OnlineExam1.DTO
{
    public class UserDTO
    {
        public int? UserId { get; set; }

        public string? Name { get; set; }

        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Role { get; set; }
        public int SiteID { get; set; }

    }
}
