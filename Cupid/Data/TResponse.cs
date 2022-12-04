namespace Cupid.Data;
public record TResponse<T>(T? Value, string Message, bool Error);
public record TListResponse<T>(List<T>? Value, string Message, bool Error)
    : TResponse<List<T>>(Value, Message, Error);