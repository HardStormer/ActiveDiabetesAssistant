﻿using ActiveDiabetesAssistant.DAL.Entities.Wrappers;

namespace ActiveDiabetesAssistant.DAL.Interfaces.Base;

public interface IBaseRepository<TRepository>
	where TRepository : BaseDto
{
	Task<TRepository> AddAsync(TRepository entity);

	Task<TRepository?> PatchAsync(TRepository entity);

	Task<IEnumerable<TRepository>> GetAllAsync();

	Task<TRepository?> EditAsync(TRepository entity);

	Task RemoveAsync(Guid id, bool soft = true);

	Task<TRepository?> GetAsync(
		Guid id,
		IEnumerable<string>? includeProperties = null);

	Task<BasicWrapper<IEnumerable<TRepository>>> GetAsync(
		int? limit = null,
		int? offset = null,
		Expression<Func<TRepository, bool>>? filter = null,
		// Func<IQueryable<TBllEntity>, IOrderedQueryable<TBllEntity>>? orderBy = null,
		IEnumerable<string>? includeProperties = null
	);
}