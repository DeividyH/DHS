using DHS.Domain.Core.Interfaces;
using DHS.Domain.Core.Interfaces.Audit;
using DHS.Domain.Core.Interfaces.Audit.Dtos;
using DHS.Domain.Core.Interfaces.Repositories;
using DHS.Domain.Core.Mapper;
using DHS.Domain.Core.Services.Dtos.Audit;
using DHS.Domain.Core.Services.Dtos.Pages;
using System.Threading.Tasks;

namespace DHS.Domain.Core.Services
{
    public abstract class Service<TEntity, TEntityDto>
        : Service<TEntity, TEntityDto, int>
           where TEntity : class, IEntity<int>
           where TEntityDto : IEntityDto<int>
    {
        protected Service(IRepository<TEntity, int> repository)
            : base(repository)
        {
        }
    }

    public abstract class Service<TEntity, TEntityDto, TPrimaryKey>
        : Service<TEntity, TEntityDto, TPrimaryKey, TEntityDto>
           where TEntity : class, IEntity<TPrimaryKey>
           where TEntityDto : IEntityDto<TPrimaryKey>
    {
        protected Service(IRepository<TEntity, TPrimaryKey> repository)
            : base(repository)
        {
        }
    }

    public abstract class Service<TEntity, TEntityDto, TPrimaryKey, TGetAllInput>
        : Service<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TEntityDto>
           where TEntity : class, IEntity<TPrimaryKey>
           where TEntityDto : IEntityDto<TPrimaryKey>
    {
        protected Service(IRepository<TEntity, TPrimaryKey> repository)
            : base(repository)
        {
        }
    }

    public abstract class Service<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput>
        : Service<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TCreateInput>
           where TEntity : class, IEntity<TPrimaryKey>
           where TEntityDto : IEntityDto<TPrimaryKey>
           where TCreateInput : IEntityDto<TPrimaryKey>
    {
        protected Service(IRepository<TEntity, TPrimaryKey> repository)
            : base(repository)
        {
        }
    }

    public abstract class Service<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput>
        : Service<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput, EntityDto<TPrimaryKey>>
           where TEntity : class, IEntity<TPrimaryKey>
           where TEntityDto : IEntityDto<TPrimaryKey>
           where TUpdateInput : IEntityDto<TPrimaryKey>
    {
        protected Service(IRepository<TEntity, TPrimaryKey> repository)
            : base(repository)
        {
        }
    }

    public abstract class Service<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput, TGetInput>
        : Service<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput, TGetInput, EntityDto<TPrimaryKey>>
           where TEntity : class, IEntity<TPrimaryKey>
           where TEntityDto : IEntityDto<TPrimaryKey>
           where TUpdateInput : IEntityDto<TPrimaryKey>
           where TGetInput : IEntityDto<TPrimaryKey>
    {
        protected Service(IRepository<TEntity, TPrimaryKey> repository)
            : base(repository)
        {
        }
    }

    public abstract class Service<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput, TGetInput, TDeleteInput>
        : Mapping<TEntity, TEntityDto, TCreateInput, TUpdateInput, TDeleteInput>, 
        IService<TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput, TGetInput, TDeleteInput>
            where TEntity : class, IEntity<TPrimaryKey>
            where TEntityDto : IEntityDto<TPrimaryKey>
            where TUpdateInput : IEntityDto<TPrimaryKey>
            where TGetInput : IEntityDto<TPrimaryKey>
            where TDeleteInput : IEntityDto<TPrimaryKey>
    {
        private readonly IRepository<TEntity, TPrimaryKey> _repository;

        protected Service(IRepository<TEntity, TPrimaryKey> repository)
        {
            _repository = repository;
        }
        
        public virtual async Task<TEntityDto> Get(TGetInput input)
        {
            var entity = await _repository.GetAsync(input.Id);

            var dto = MapEntityToEntityDto(entity);

            return dto;
        }

        public virtual async Task<PagedResultDto<TEntityDto>> GetAll(TGetAllInput input)
        {
            var entityList = await _repository.GetAllListAsync();

            var dtoList = MapEntityToEntityDtoList(entityList);

            return new PagedResultDto<TEntityDto>(entityList.Count, dtoList.AsReadOnly());
        }

        public virtual async Task<TEntityDto> Create(TCreateInput input)
        {
            var entity = MapEntityDtoToEntity(input);

            await _repository.InsertAsync(entity);

            var dto = MapEntityToEntityDto(entity);

            return dto;
        }
        
        public virtual async Task<TEntityDto> Update(TUpdateInput input)
        {
            var entity = MapEntityDtoToEntity(input);

            await _repository.UpdateAsync(entity);

            var dto = MapEntityToEntityDto(entity);

            return dto;
        }

        public virtual async Task Delete(TDeleteInput input)
        {
            await _repository.DeleteAsync(input.Id);
        }
    }
}
