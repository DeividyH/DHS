using DHS.Domain.Core.Services.Dtos.Audit;
using System.ComponentModel.DataAnnotations;

namespace DHS.Application.Dtos.Users
{
    public class UserDto : EntityDto<long>
    {
        [Required]
        [MaxLength(10)]
        public string UserName { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public bool IsActive { get; set; }
    }
}
