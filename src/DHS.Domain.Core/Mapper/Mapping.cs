using AutoMapper;
using DHS.Domain.Core.Interfaces.Mapper;
using System.Collections.Generic;

namespace DHS.Domain.Core.Mapper
{
    public abstract class Mapping<TEntity, TEntityDto, TCreateInput, TUpdateInput, TDeleteInput> :
        IMapping<TEntity, TEntityDto, TCreateInput, TUpdateInput, TDeleteInput>
    {
        private IMapper _mapper;

        public Mapping()
        {
            _mapper = ConfigurationMap();
        }

        private IMapper ConfigurationMap()
        {
            var config = new MapperConfiguration(x =>
            {
                x.CreateMap<TEntity, TEntityDto>();
                x.CreateMap<TEntityDto, TEntity>();
            });

            var mapper = config.CreateMapper();

            return mapper;
        }

        public TEntity MapEntityDtoToEntity(TEntityDto input)
        {
            return _mapper.Map<TEntity>(input);
        }

        public TEntityDto MapEntityToEntityDto(TEntity input)
        {
            return _mapper.Map<TEntityDto>(input);
        }

        public List<TEntity> MapEntityDtoToEntityList(List<TEntityDto> input)
        {
            return _mapper.Map<List<TEntity>>(input);
        }

        public List<TEntityDto> MapEntityToEntityDtoList(List<TEntity> input)
        {
            return _mapper.Map<List<TEntityDto>>(input);
        }

        #region Others 

        public TEntity MapEntityDtoToEntity(TCreateInput input)
        {
            return _mapper.Map<TEntity>(input);
        }

        public TEntity MapEntityDtoToEntity(TUpdateInput input)
        {
            return _mapper.Map<TEntity>(input);
        }

        public TEntity MapEntityDtoToEntity(TDeleteInput input)
        {
            return _mapper.Map<TEntity>(input);
        }


        public List<TEntity> MapEntityDtoToEntityList(List<TCreateInput> input)
        {
            return _mapper.Map<List<TEntity>>(input);
        }

        public List<TEntity> MapEntityDtoToEntityList(List<TUpdateInput> input)
        {
            return _mapper.Map<List<TEntity>>(input);
        }

        public List<TEntity> MapEntityDtoToEntityList(List<TDeleteInput> input)
        {
            return _mapper.Map<List<TEntity>>(input);
        }

        #endregion

    }
}
