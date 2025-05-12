using Microsoft.AspNetCore.Identity;

namespace BlogPost.API.Repository.Interface
{
    public interface ITokenRepository
    {

        string CreateJwtToken(IdentityUser user, List<string> roles );


    }
}
