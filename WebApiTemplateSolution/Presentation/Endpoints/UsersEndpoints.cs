using Application.Users.Add;
using Application.Users.Login;
using Application.Users.Logout;
using MediatR;
using Presentation._Common.Endpoints;

namespace Presentation.Endpoints;

public class UsersEndpoints : BaseEndpointCollection
{
    public UsersEndpoints() : base("Users")
    {
        DefineInsertEndpoint<AddUserCommand>();

        DefineEndpoint(HttpVerbose.Post, "/login",
            Login, 200, typeof(LoginUserCommandResponse));

        DefineEndpoint(HttpVerbose.Post, "/logout",
            Logout, 200);
    }

    private async Task<IResult> Login(ISender mediator, LoginUserCommand command)
    {
        var response = await mediator.Send(command);
        return Results.Ok(response);
    }
    private async Task<IResult> Logout(ISender mediator)
    {
        var command = new LogoutCurrentUserCommand();
        await mediator.Send(command);

        return Results.Ok();
    }
}
