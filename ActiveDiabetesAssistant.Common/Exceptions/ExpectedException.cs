using System.Net;

namespace ActiveDiabetesAssistant.Common.Exceptions;

/// <summary>
/// Класс ExpectedException представляет исключение, которое может быть ожидаемым и имеет дополнительное поле для представления статусного кода HTTP.
/// </summary>
/// <remarks>
/// Конструктор класса, который принимает сообщение об ошибке и статусный код HTTP. Он вызывает базовый конструктор класса Exception, передавая сообщение об ошибке, а затем устанавливает поле httpStatusCode, чтобы хранить статусный код HTTP.
/// </remarks>
/// <param name="message"></param>
/// <param name="httpStatusCode"></param>
public class ExpectedException(string message, HttpStatusCode httpStatusCode) : Exception(message)
{
	/// <summary>
	/// Поле, представляющее статусный код HTTP, связанный с исключением.
	/// </summary>
	public HttpStatusCode httpStatusCode = httpStatusCode;
}