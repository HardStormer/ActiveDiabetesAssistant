namespace ActiveDiabetesAssistant.DAL.Interfaces;

public interface IPersonInfoRepository : IBaseRepository<PersonInfoDto>
{
	Task<Guid?> GetPersonId(Guid userId);
}