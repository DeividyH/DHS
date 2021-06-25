using AutoMapper;
using DHS.Domain.Core.Interfaces.Audit;
using DHS.Domain.Core.Interfaces.Audit.Dtos;
using DHS.Domain.Core.Interfaces.Filters;
using DHS.Domain.Core.Interfaces.Pages;
using DHS.Domain.Core.Interfaces.Repositories;
using DHS.Domain.Core.Services;
using DHS.Domain.Core.Services.Dtos.Audit;
using DHS.Domain.Core.Services.Dtos.Filters;
using DHS.Domain.Core.Services.Dtos.Pages;
using DHS.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DHS.Domain.Services
{
    public abstract class DhsCrudAppService<TEntity, TEntityDto> :
       DhsCrudAppService<TEntity, TEntityDto, int>
   where TEntity : class, IEntity<int>
   where TEntityDto : IEntityDto<int>
    {
        protected DhsCrudAppService(IRepository<TEntity, int> repository)
            : base(repository)
        {
        }
    }

    public abstract class DhsCrudAppService<TEntity, TEntityDto, TPrimaryKey> :
        DhsCrudAppService<TEntity, TEntityDto, TPrimaryKey, PagedAndSortedResultRequestDto>
    where TEntity : class, IEntity<TPrimaryKey>
    where TEntityDto : IEntityDto<TPrimaryKey>
    {
        protected DhsCrudAppService(IRepository<TEntity, TPrimaryKey> repository)
            : base(repository)
        {
        }
    }

    public abstract class DhsCrudAppService<TEntity, TEntityDto, TPrimaryKey, TGetAllInput> :
        DhsCrudAppService<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, GetAllFilteredPagination>
     where TEntity : class, IEntity<TPrimaryKey>
     where TEntityDto : IEntityDto<TPrimaryKey>
    {
        protected DhsCrudAppService(IRepository<TEntity, TPrimaryKey> repository)
            : base(repository)
        {
        }
    }

    public abstract class DhsCrudAppService<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, IRecoverDataInput> :
        DhsCrudAppService<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, IRecoverDataInput, FilterToSelectPickerDto>
    where TEntity : class, IEntity<TPrimaryKey>
    where TEntityDto : IEntityDto<TPrimaryKey>
    where IRecoverDataInput : IGetAllFilteredPagination
    {
        protected DhsCrudAppService(IRepository<TEntity, TPrimaryKey> repository)
            : base(repository)
        {
        }
    }

    public abstract class DhsCrudAppService<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, IRecoverDataInput, TGetAllSelectInput> :
        DhsCrudAppService<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, IRecoverDataInput, TGetAllSelectInput, TEntityDto>
    where TEntity : class, IEntity<TPrimaryKey>
    where TEntityDto : IEntityDto<TPrimaryKey>
    where IRecoverDataInput : IGetAllFilteredPagination
    where TGetAllSelectInput : IFilterToSelectPickerDto
    {
        protected DhsCrudAppService(IRepository<TEntity, TPrimaryKey> repository)
            : base(repository)
        {
        }
    }

    public abstract class DhsCrudAppService<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, IRecoverDataInput, TGetAllSelectInput, TCreateInput> :
        DhsCrudAppService<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, IRecoverDataInput, TGetAllSelectInput, TCreateInput, TCreateInput>
      where TEntity : class, IEntity<TPrimaryKey>
      where TEntityDto : IEntityDto<TPrimaryKey>
      where IRecoverDataInput : IGetAllFilteredPagination
      where TGetAllSelectInput : IFilterToSelectPickerDto
      where TCreateInput : IEntityDto<TPrimaryKey>
    {
        protected DhsCrudAppService(IRepository<TEntity, TPrimaryKey> repository)
            : base(repository)
        {
        }
    }

    public abstract class DhsCrudAppService<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, IRecoverDataInput, TGetAllSelectInput, TCreateInput, TUpdateInput> :
        DhsCrudAppService<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, IRecoverDataInput, TGetAllSelectInput, TCreateInput, TUpdateInput, EntityDto<TPrimaryKey>>
      where TEntity : class, IEntity<TPrimaryKey>
      where TEntityDto : IEntityDto<TPrimaryKey>
      where IRecoverDataInput : IGetAllFilteredPagination
      where TGetAllSelectInput : IFilterToSelectPickerDto
      where TCreateInput : IEntityDto<TPrimaryKey>
      where TUpdateInput : IEntityDto<TPrimaryKey>
    {
        protected DhsCrudAppService(IRepository<TEntity, TPrimaryKey> repository)
            : base(repository)
        {
        }
    }

    public abstract class DhsCrudAppService<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, IRecoverDataInput, TGetAllSelectInput, TCreateInput, TUpdateInput, TGetInput> :
        DhsCrudAppService<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, IRecoverDataInput, TGetAllSelectInput, TCreateInput, TUpdateInput, TGetInput, EntityDto<TPrimaryKey>>
      where TEntity : class, IEntity<TPrimaryKey>
      where TEntityDto : IEntityDto<TPrimaryKey>
      where IRecoverDataInput : IGetAllFilteredPagination
      where TGetAllSelectInput : IFilterToSelectPickerDto
      where TCreateInput : IEntityDto<TPrimaryKey>
      where TUpdateInput : IEntityDto<TPrimaryKey>
      where TGetInput : IEntityDto<TPrimaryKey>
    {
        protected DhsCrudAppService(IRepository<TEntity, TPrimaryKey> repository)
            : base(repository)
        {
        }
    }

    public abstract class DhsCrudAppService<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, IRecoverDataInput, TGetAllSelectInput, TCreateInput, TUpdateInput, TGetInput, TDeleteInput> :
        Service<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput, TGetInput, TDeleteInput>,
        IDhsCrudAppService<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, IRecoverDataInput, TGetAllSelectInput, TCreateInput, TUpdateInput, TGetInput, TDeleteInput>
    where TEntity : class, IEntity<TPrimaryKey>
    where TEntityDto : IEntityDto<TPrimaryKey>
    where IRecoverDataInput : IGetAllFilteredPagination
    where TGetAllSelectInput : IFilterToSelectPickerDto
    where TCreateInput : IEntityDto<TPrimaryKey>
    where TUpdateInput : IEntityDto<TPrimaryKey>
    where TGetInput : IEntityDto<TPrimaryKey>
    where TDeleteInput : IEntityDto<TPrimaryKey>
    {
        private readonly IRepository<TEntity, TPrimaryKey> _repository;
        private readonly IMapper _mapper;

        protected DhsCrudAppService(IRepository<TEntity, TPrimaryKey> repository)
            : base(repository)
        {
            _repository = repository;
        }

        #region Ordering 
       
        public virtual Expression<Func<TEntity, object>> Sort(IRecoverDataInput input)
        {
            Expression<Func<TEntity, object>> exp;
            exp = (x => x.Id);
  
            return exp;
        }

        private IQueryable<TEntity> ApplySorting(IQueryable<TEntity> query, IRecoverDataInput input)
        {
            var ordering = Sort(input);
            if (input.IsAsc)
                return query.OrderBy(ordering);
            else
                return query.OrderByDescending(ordering);
        }

        #endregion

        #region Filtering 
  
        private async Task<IQueryable<TEntity>> ApplyFiltering(IQueryable<TEntity> query, IRecoverDataInput input)
        {
            query = await Filter(query, input);
        
            return query;
        }
    
        public virtual async Task<IQueryable<TEntity>> Filter(IQueryable<TEntity> query, IRecoverDataInput input)
        {
            return query;
        }

        public virtual async Task<PagedResultDto<TEntityDto>> GetAllToFilter(TGetAllInput input)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<PagedResultDto<TEntityDto>> FilterToSelectPicker(TGetAllSelectInput input)
        {
            throw new NotImplementedException();
        }
        
        #endregion

        #region Pagination 
        
        public virtual IQueryable<TEntity> Pagination(IQueryable<TEntity> query, IRecoverDataInput input)
        {
            return query.Skip(input.PagedRequest.SkipCount).Take(input.PagedRequest.MaxResultCount);
        }

        #endregion

        #region Create Query
    
        public virtual IQueryable<TEntity> CreateQuery()
        {
            return _repository.GetAll();
        }

        #endregion

        
        public virtual async Task<List<TEntityDto>> ProcessToReturn(List<TEntityDto> dtoList)
        {
            return dtoList;
        }

        public virtual async Task<PagedResultDto<TEntityDto>> RecoverData(IRecoverDataInput input)
        {
            var query = CreateQuery();

            query = await ApplyFiltering(query, input);

            query = ApplySorting(query, input);

            var count = query.Count();

            query = Pagination(query, input);

            var entityList = query.ToList();

            var dtoList = _mapper.Map<List<TEntityDto>>(entityList);

            var processToReturn = await ProcessToReturn(dtoList);

            return new PagedResultDto<TEntityDto>(count, processToReturn.AsReadOnly());
        }

    }
}
