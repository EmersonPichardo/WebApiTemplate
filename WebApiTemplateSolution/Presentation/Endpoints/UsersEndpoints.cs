using Application.Users.Login;
using Application.Users.Register;
using MediatR;
using Presentation._Common.Endpoints;

namespace Presentation.Endpoints;

public class UsersEndpoints : BaseEndpointCollection
{
    public UsersEndpoints() : base("Users")
    {
        DefineAddEndpoint<RegisterUserCommand>();

        DefineEndpoint(HttpVerbose.Post, "/login",
            Login, 200, typeof(LoginUserCommandResponse));
    }

    private async Task<IResult> Login(ISender mediator, LoginUserCommand command)
    {
        var response = await mediator.Send(command);
        return Results.Ok(response);
    }
}
