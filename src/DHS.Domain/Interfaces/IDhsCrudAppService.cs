using DHS.Domain.Core.Interfaces;
using DHS.Domain.Core.Interfaces.Audit;
using DHS.Domain.Core.Interfaces.Audit.Dtos;
using DHS.Domain.Core.Services.Dtos.Audit;
using DHS.Domain.Core.Services.Dtos.Filters;
using DHS.Domain.Core.Services.Dtos.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DHS.Domain.Interfaces
{
    public interface IDhsCrudAppService<TEntity, TEntityDto> :
        IDhsCrudAppService<TEntity, TEntityDto, int>
    where TEntity : class, IEntity
    where TEntityDto : IEntityDto
    {
    }

    public interface IDhsCrudAppService<TEntity, TEntityDto, TPrimaryKey> :
        IDhsCrudAppService<TEntity, TEntityDto, TPrimaryKey, PagedAndSortedResultRequestDto>
    where TEntity : class, IEntity<TPrimaryKey>
    where TEntityDto : IEntityDto<TPrimaryKey>
    {
    }

    public interface IDhsCrudAppService<TEntity, TEntityDto, TPrimaryKey, TGetAllInput> :
     IDhsCrudAppService<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, GetAllFilteredPagination>
     where TEntity : class, IEntity<TPrimaryKey>
     where TEntityDto : IEntityDto<TPrimaryKey>
    {
    }

    public interface IDhsCrudAppService<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, IRecoverDataInput> :
        IDhsCrudAppService<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, IRecoverDataInput, FilterToSelectPickerDto>
        where TEntity : class, IEntity<TPrimaryKey>
        where TEntityDto : IEntityDto<TPrimaryKey>
    {
    }

    public interface IDhsCrudAppService<TEntity, TEntityDto, TPrimaryKey, in TGetAllInput, in TRecoverDataInput, in TGetAllSelectInput> :
       IDhsCrudAppService<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TRecoverDataInput, TGetAllSelectInput, TEntityDto>
       where TEntity : class, IEntity<TPrimaryKey>
       where TEntityDto : IEntityDto<TPrimaryKey>
    {
    }

    public interface IDhsCrudAppService<TEntity, TEntityDto, TPrimaryKey, in TGetAllInput, in TRecoverDataInput, in TGetAllSelectInput, in TCreateInput> :
       IDhsCrudAppService<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TRecoverDataInput, TGetAllSelectInput, TCreateInput, TCreateInput>
       where TEntity : class, IEntity<TPrimaryKey>
       where TEntityDto : IEntityDto<TPrimaryKey>
       where TCreateInput : IEntityDto<TPrimaryKey>
    {
    }

    public interface IDhsCrudAppService<TEntity, TEntityDto, TPrimaryKey, in TGetAllInput, in TRecoverDataInput, in TGetAllSelectInput, in TCreateInput, in TUpdateInput> :
       IDhsCrudAppService<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TRecoverDataInput, TGetAllSelectInput, TCreateInput, TUpdateInput, EntityDto<TPrimaryKey>>
       where TEntity : class, IEntity<TPrimaryKey>
       where TEntityDto : IEntityDto<TPrimaryKey>
       where TCreateInput : IEntityDto<TPrimaryKey>
       where TUpdateInput : IEntityDto<TPrimaryKey>
    {
    }

    public interface IDhsCrudAppService<TEntity, TEntityDto, TPrimaryKey, in TGetAllInput, in TRecoverDataInput, in TGetAllSelectInput, in TCreateInput, in TUpdateInput, in TGetInput> :
        IDhsCrudAppService<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TRecoverDataInput, TGetAllSelectInput, TCreateInput, TUpdateInput, TGetInput, EntityDto<TPrimaryKey>>
        where TEntity : class, IEntity<TPrimaryKey>
        where TEntityDto : IEntityDto<TPrimaryKey>
        where TCreateInput : IEntityDto<TPrimaryKey>
        where TUpdateInput : IEntityDto<TPrimaryKey>
        where TGetInput : IEntityDto<TPrimaryKey>
    {
    }

    public interface IDhsCrudAppService<TEntity, TEntityDto, TPrimaryKey, in TGetAllInput, in TRecoverDataInput, in TGetAllSelectInput, in TCreateInput, in TUpdateInput, in TGetInput, in TDeleteInput> :
        IService<TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput, TGetInput, TDeleteInput>
        where TEntity : class, IEntity<TPrimaryKey>
        where TEntityDto : IEntityDto<TPrimaryKey>
        where TCreateInput : IEntityDto<TPrimaryKey>
        where TUpdateInput : IEntityDto<TPrimaryKey>
        where TGetInput : IEntityDto<TPrimaryKey>
        where TDeleteInput : IEntityDto<TPrimaryKey>
    {
        Task<PagedResultDto<TEntityDto>> RecoverData(TRecoverDataInput input);

        Task<PagedResultDto<TEntityDto>> FilterToSelectPicker(TGetAllSelectInput input);

        IQueryable<TEntity> CreateQuery();

        Task<IQueryable<TEntity>> Filter(IQueryable<TEntity> query, TRecoverDataInput input);

        Expression<Func<TEntity, object>> Sort(TRecoverDataInput input);

        IQueryable<TEntity> Pagination(IQueryable<TEntity> query, TRecoverDataInput input);

        Task<List<TEntityDto>> ProcessToReturn(List<TEntityDto> dtoList);

        Task<PagedResultDto<TEntityDto>> GetAllToFilter(TGetAllInput input);
    }
}
