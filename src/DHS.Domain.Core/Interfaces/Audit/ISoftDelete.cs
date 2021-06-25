using System.ComponentModel;

namespace DHS.Domain.Core.Interfaces.Audit
{
    public interface ISoftDelete
    {
        [DefaultValue(false)]
        bool IsDeleted { get; set; }
    }
}
