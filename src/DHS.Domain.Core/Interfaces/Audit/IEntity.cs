using System.ComponentModel.DataAnnotations;

namespace DHS.Domain.Core.Interfaces.Audit
{
    public interface IEntity: 
            IEntity<int>
    {
    }

    public interface IEntity<TPrinmaryKey>
    {
        [Key]
        TPrinmaryKey Id{ get; set; }
    }
}
