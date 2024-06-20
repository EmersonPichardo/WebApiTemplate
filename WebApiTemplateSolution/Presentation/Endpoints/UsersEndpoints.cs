using Application.Users.Register;
using Presentation._Common.Endpoints;

namespace Presentation.Endpoints;

public class UsersEndpoints : BaseEndpointCollection
{
    public UsersEndpoints() : base("Users")
    {
        DefineAddEndpoint<RegisterUserCommand>();
    }
}
