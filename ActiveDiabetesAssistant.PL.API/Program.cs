using ActiveDiabetesAssistant.DAL.SQL.Contexts;
using ActiveDiabetesAssistant.PL.API.DependencyInjection;
using ActiveDiabetesAssistant.PL.API.Middlewares;
using AutoMapper.Extensions.ExpressionMapping;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(options =>
{
	options.JsonSerializerOptions.PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase;
	options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

builder.Services.InjectRepositories();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
	options.SwaggerDoc("v1", new OpenApiInfo
	{
		Version = "v1",
		Title = "Active Diabetes Assistant Api"
	});

	options.AddSecurityRequirement(new OpenApiSecurityRequirement()
	  {
		{
		  new OpenApiSecurityScheme
		  {
			Reference = new OpenApiReference
			  {
				Type = ReferenceType.SecurityScheme,
				Id = "Bearer"
			  },
			  Scheme = "oauth2",
			  Name = "Authorization",
			  In = ParameterLocation.Header,
			},
			new List<string>()
		}
	});

	options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
	{
		Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
		Name = "Authorization",
		In = ParameterLocation.Header,
		Type = SecuritySchemeType.ApiKey
	});

	var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
	var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
	options.IncludeXmlComments(xmlPath);
});

builder.Services.AddDbContextFactory<BaseDbContext>(
	(DbContextOptionsBuilder options) => options.UseSqlServer(builder.Configuration.GetConnectionString("SQLConnStr")));

builder.Services.AddFluentValidationAutoValidation(cfg =>
{
	cfg.DisableDataAnnotationsValidation = true;
});

builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

builder.Services.AddAutoMapper(cfg =>
{
	cfg.AddExpressionMapping();
}, AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddAuthentication(DefaultApiAuthenticationOptions.DefaultScheme).AddDefaultApiAuthentication();

builder.Services.AddHttpContextAccessor();

builder.Services.AddCors(options =>
{
	options.AddPolicy("default", policy =>
	{
		policy.AllowAnyOrigin()
			.AllowAnyHeader()
			.AllowAnyMethod();
	});
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseCors("default");
app.UseRouting();

app.UseRouter(endpoints =>
{
	endpoints.MapGet("/", async context =>
	{
		await context.Response.WriteAsync("Hello World!");
		//await Task.Run(() => context.Response.Redirect(@"/swagger/index.html"));
	});
});

app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.MapControllers();

app.Run();