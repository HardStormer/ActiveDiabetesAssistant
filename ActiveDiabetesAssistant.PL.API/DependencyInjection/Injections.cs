using ActiveDiabetesAssistant.DAL.SQL;

namespace ActiveDiabetesAssistant.PL.API.DependencyInjection;

/// <summary>
/// Статический класс Injections содержит методы для внедрения зависимостей (Dependency Injection) репозиториев в контейнер служб IServiceCollection.
/// </summary>
public static class Injections
{
	/// <summary>
	/// Расширяющий метод для IServiceCollection, который регистрирует репозитории в контейнере служб.
	/// </summary>
	/// <param name="services"></param>
	public static void InjectRepositories(this IServiceCollection services)
	{
		services.AddScoped<
			IUserRepository,
			UserRepository>();
	}
}