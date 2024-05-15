namespace ActiveDiabetesAssistant.DAL.Entities;

public class GlucoseInfoDto : BaseDto
{
	public float GlucoseData { get; set; }
	public int? StepsCount { get; set; }
	public Guid PersonInfoId { get; set; }
	public PersonInfoDto PersonInfo { get; set; } = null!;
}

public class GlucoseInfoDtoConfiguration : IEntityTypeConfiguration<GlucoseInfoDto>
{
	public void Configure(EntityTypeBuilder<GlucoseInfoDto> builder)
	{
		builder.HasQueryFilter(x => x.IsDeleted == false);

		builder
			.HasOne(x => x.PersonInfo)
			.WithMany(x => x.GlucoseInfos)
			.HasForeignKey(x => x.PersonInfoId);
	}
}