using MU.Domain.Entities.Owners;

namespace MU.Application.Services.JWTGenerator
{
    public interface IJWTGenerator
    {
        string GenerateToken(
            Guid id,
            string name,
            string address,
            DateTime birthay);
    }
}