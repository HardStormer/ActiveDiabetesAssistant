namespace ActiveDiabetesAssistant.DAL.Entities;

public class UserDto : BaseDto
{
	public string? Name { get; set; }
	public string Login { get; set; } = string.Empty;
	public string Password { get; set; } = string.Empty;
	public string Bio { get; set; } = string.Empty;
	public DateTime? TokenExpiredAt { get; set; }
}

public class UserDtoConfiguration : IEntityTypeConfiguration<UserDto>
{
	public void Configure(EntityTypeBuilder<UserDto> builder)
	{
	}
}