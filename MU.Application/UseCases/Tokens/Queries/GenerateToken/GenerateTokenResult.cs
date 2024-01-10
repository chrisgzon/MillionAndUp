namespace MU.Application.UseCases.Tokens.Queries.GenerateToken
{
    public record GenerateTokenResult(
        Guid Id,
        string Name,
        string Address,
        DateTime Birthay,
        string token);
}
