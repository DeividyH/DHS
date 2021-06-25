using DHS.Domain.Core.Interfaces.Pages;
using DHS.Domain.Core.Services.Dtos.MaxResult;
using System;
using System.ComponentModel.DataAnnotations;

namespace DHS.Domain.Core.Services.Dtos.Pages
{
    /// <summary>
    /// Simply implements <see cref="IPagedResultRequest"/>.
    /// </summary>
    [Serializable]
    public class PagedResultRequestDto : LimitedResultRequestDto, IPagedResultRequest
    {
        [Range(0, int.MaxValue)]
        public virtual int SkipCount { get; set; }
    }
}
