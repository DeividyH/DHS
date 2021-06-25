using DHS.Domain.Core.Interfaces.MaxResult;
using System;
using System.ComponentModel.DataAnnotations;

namespace DHS.Domain.Core.Services.Dtos.MaxResult
{
    /// <summary>
    /// Simply implements <see cref="ILimitedResultRequest"/>.
    /// </summary>
    public class LimitedResultRequestDto : ILimitedResultRequest
    {
        [Range(1, int.MaxValue)]
        public virtual int MaxResultCount { get; set; } = 10;
    }
}
