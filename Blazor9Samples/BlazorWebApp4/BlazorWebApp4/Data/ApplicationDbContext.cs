using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlazorWebApp4.Data
{
    public class ApplicationDbContext ( DbContextOptions<ApplicationDbContext> options ) : IdentityDbContext<ApplicationUser>( options )
    {
    }
}
