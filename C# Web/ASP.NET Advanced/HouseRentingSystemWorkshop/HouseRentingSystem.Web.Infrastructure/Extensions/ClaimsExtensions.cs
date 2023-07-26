using System.Security.Claims;

namespace HouseRentingSystem.Web.Infrastructure.Extensions
{
    public static class ClaimsExtensions
    {
        public static string? GetId(this ClaimsPrincipal user)
        {
            return user.FindFirst(ClaimTypes.NameIdentifier).ToString();
        }

        public static bool IsAdmin(this ClaimsPrincipal user)
        {
            return user.IsInRole("Admin");
        }
    }
}
