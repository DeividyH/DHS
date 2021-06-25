using DHS.Domain.Core.Interfaces.Lists;
using DHS.Domain.Core.Interfaces.MaxResult;

namespace DHS.Domain.Core.Interfaces.Pages
{
    /// <summary>
    /// This interface is defined to standardize to return a page of items to clients.
    /// </summary>
    /// <typeparam name="T">Type of the items in the <see cref="IListResult{T}.Items"/> list
    public interface IPagedResult<T> : IListResult<T>, IHasTotalCount
    {

    }
}
