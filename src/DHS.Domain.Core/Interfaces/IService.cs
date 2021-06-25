using DHS.Domain.Core.Interfaces.Audit.Dtos;
using DHS.Domain.Core.Services.Dtos.Audit;
using DHS.Domain.Core.Services.Dtos.Pages;
using System.Threading.Tasks;

namespace DHS.Domain.Core.Interfaces
{
    public interface IService<TEntityDto>
       : IService<TEntityDto, int>
        where TEntityDto : IEntityDto
    {
    }

    public interface IService<TEntityDto, TPrimaryKey>
       : IService<TEntityDto, TPrimaryKey, PagedAndSortedResultRequestDto>
       where TEntityDto : IEntityDto<TPrimaryKey>
    {
    }

    public interface IService<TEntityDto, TPrimaryKey, in TGetAllInput>
       : IService<TEntityDto, TPrimaryKey, TGetAllInput, TEntityDto, TEntityDto>
       where TEntityDto : IEntityDto<TPrimaryKey>
    {
    }

    public interface IService<TEntityDto, TPrimaryKey, in TGetAllInput, in TCreateInput>
        : IService<TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TCreateInput>
        where TEntityDto : IEntityDto<TPrimaryKey>
        where TCreateInput : IEntityDto<TPrimaryKey>
    {
    }

    public interface IService<TEntityDto, TPrimaryKey, in TGetAllInput, in TCreateInput, in TUpdateInput>
         : IService<TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput, EntityDto<TPrimaryKey>>
         where TEntityDto : IEntityDto<TPrimaryKey>
         where TUpdateInput : IEntityDto<TPrimaryKey>
    {
    }

    public interface IService<TEntityDto, TPrimaryKey, in TGetAllInput, in TCreateInput, in TUpdateInput, in TGetInput>
           : IService<TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput, TGetInput, EntityDto<TPrimaryKey>>
           where TEntityDto : IEntityDto<TPrimaryKey>
           where TUpdateInput : IEntityDto<TPrimaryKey>
           where TGetInput : IEntityDto<TPrimaryKey>
    {
    }

    public interface IService<TEntityDto, TPrimaryKey, in TGetAllInput, in TCreateInput, in TUpdateInput, in TGetInput, in TDeleteInput>
      where TEntityDto : IEntityDto<TPrimaryKey>
      where TUpdateInput : IEntityDto<TPrimaryKey>
      where TGetInput : IEntityDto<TPrimaryKey>
      where TDeleteInput : IEntityDto<TPrimaryKey>
    {
        Task<TEntityDto> Get(TGetInput input);

        Task<PagedResultDto<TEntityDto>> GetAll(TGetAllInput input);

        Task<TEntityDto> Create(TCreateInput input);

        Task<TEntityDto> Update(TUpdateInput input);

        Task Delete(TDeleteInput input);
    }
}
