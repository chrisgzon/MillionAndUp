namespace MU.Application.UseCases.Tokens.Queries
{
    public record GenerateTokenResult(
        Guid Id,
        string Name,
        string Address,
        DateTime Birthay,
        string token);
}
