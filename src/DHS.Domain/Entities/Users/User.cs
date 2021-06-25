using DHS.Domain.Core.Entities.Audit;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DHS.Domain.Entities.Users
{
    [Table("DHS_Users")]
    public class User : FullAuditedEntity<long>
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
