using quiLV_ALTA_Class.Model;

namespace quiLV_ALTA_Class.Services.JwtService
{
    public interface IJwtService
    {
        string GenerateToken(User user);

    }
}
