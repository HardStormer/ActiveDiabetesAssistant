namespace ActiveDiabetesAssistant.DAL.Entities;

public class PersonInfoDto : BaseDto
{
	public string Name { get; set; } = null!;
	public int Age { get; set; }
	public Sex Sex { get; set; }
	public DiabetesType DiabetesType { get; set; }
	public Guid UserId { get; set; }
	public UserDto User { get; set; } = null!;
	public IEnumerable<GlucoseInfoDto> GlucoseInfos { get; set; } = [];
}

public class PersonInfoDtoConfiguration : IEntityTypeConfiguration<PersonInfoDto>
{
	public void Configure(EntityTypeBuilder<PersonInfoDto> builder)
	{
		builder.HasQueryFilter(x => x.IsDeleted == false);

		builder
			.HasOne(x => x.User)
			.WithOne(x => x.PersonInfo)
			.HasForeignKey<PersonInfoDto>(x => x.UserId);
	}
}