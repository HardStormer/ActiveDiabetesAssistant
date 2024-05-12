namespace ActiveDiabetesAssistant.PL.API.Middlewares;

/// <summary>
/// Класс ExceptionHandlingMiddleware представляет промежуточное ПО (middleware) для обработки исключений в запросах HTTP.
/// </summary>
/// <remarks>
/// Конструктор класса, который принимает ссылку на следующий делегат запроса и интерфейс ILogger. Он сохраняет ссылку на следующий делегат и интерфейс ILogger для использования в методе InvokeAsync.
/// </remarks>
/// <param name="next"></param>
/// <param name="logger"></param>
public class ExceptionHandlingMiddleware(
	RequestDelegate next,
	ILogger<ExceptionHandlingMiddleware> logger)
{
	/// <summary>
	/// Метод, который обрабатывает запросы, перехватывает исключения и обрабатывает их в соответствии с определенными правилами. Метод вызывает следующий делегат в конвейере middleware (httpContext), и если происходит исключение, оно перехватывается и обрабатывается соответствующим обработчиком.
	/// </summary>
	/// <param name="httpContext"></param>
	/// <returns></returns>
	public async Task InvokeAsync(HttpContext httpContext)
	{
		try
		{
			await next(httpContext);
		}
		catch (ValidationException ex)
		{
			HandleValidationException(
				httpContext,
				ex,
				HttpStatusCode.Forbidden);
		}
		catch (ExpectedException ex)
		{
			HandleExpectedException(
				httpContext,
				ex,
				ex.httpStatusCode);
		}
		catch (NotFoundException ex)
		{
			HandleExpectedException(
				httpContext,
				ex,
				HttpStatusCode.NotFound);
		}
		catch (Exception ex)
		{
			HandleException(
				httpContext,
				ex,
				HttpStatusCode.InternalServerError,
				"Internal server error");
		}
	}

	private void HandleValidationException(HttpContext context, ValidationException ex, HttpStatusCode httpStatusCode)
	{
	}

	private void HandleExpectedException(HttpContext context, Exception ex, HttpStatusCode httpStatusCode)
	{
		logger.LogError(JsonConvert.SerializeObject(new
		{
			ex.Message,
			ex.Source,
			ex.StackTrace
		}));

		HttpResponse response = context.Response;

		response.ContentType = "application/json";
		response.StatusCode = (int)httpStatusCode;
	}

	private void HandleException(HttpContext context, Exception ex, HttpStatusCode httpStatusCode, string message)
	{
		logger.LogError(JsonConvert.SerializeObject(new
		{
			ex.Message,
			ex.Source,
			ex.StackTrace
		}));

		HttpResponse response = context.Response;

		response.ContentType = "application/json";
		response.StatusCode = (int)httpStatusCode;
	}
}