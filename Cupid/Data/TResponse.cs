namespace Cupid.Data;
public record TResponse<T>(T? Value, string Message, bool Error);