using System.Collections.Generic;

namespace DHS.Domain.Core.Interfaces.Mapper
{
    public interface IMapping<TEntity, TEntityDto, TCreateInput, TUpdateInput, TDeleteInput>
    {
        TEntity MapEntityDtoToEntity(TEntityDto input);
        TEntityDto MapEntityToEntityDto(TEntity input);
        List<TEntity> MapEntityDtoToEntityList(List<TEntityDto> input);
        List<TEntityDto> MapEntityToEntityDtoList(List<TEntity> input);

        #region Others

        TEntity MapEntityDtoToEntity(TCreateInput input);
        TEntity MapEntityDtoToEntity(TUpdateInput input);
        TEntity MapEntityDtoToEntity(TDeleteInput input);

        List<TEntity> MapEntityDtoToEntityList(List<TCreateInput> input);
        List<TEntity> MapEntityDtoToEntityList(List<TUpdateInput> input);
        List<TEntity> MapEntityDtoToEntityList(List<TDeleteInput> input);

        #endregion
    }
}
