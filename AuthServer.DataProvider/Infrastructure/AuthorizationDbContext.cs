using Microsoft.EntityFrameworkCore;

namespace AuthServer.DataProvider.Infrastructure;

public class AuthorizationDbContext : DbContext
{
    public AuthorizationDbContext(DbContextOptions<AuthorizationDbContext> options)
       : base(options)
    {
    }
}