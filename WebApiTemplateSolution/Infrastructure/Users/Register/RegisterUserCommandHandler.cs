using Application._Common.Events;
using Application._Common.Persistence.Databases;
using Application._Common.Security.Authentication;
using Application.Users.Register;
using Domain.Security;

namespace Infrastructure.Users.Register;

internal class RegisterUserCommandHandler(
    IApplicationDbContext dbContext,
    IPasswordHasher passwordHasher,
    IEventPublisher eventPublisher
)
    : IRegisterUserCommandHandler
{
    public async Task Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        (var password, var hashedPassword, var salt, var algorithm, var iterations) = passwordHasher.GenerateNewPassword();

        var user = new User()
        {
            FullName = request.FullName,
            Email = request.Email,
            Password = hashedPassword,
            Salt = salt,
            Algorithm = algorithm,
            Iterations = iterations,
            Status = UserStatus.Active
        };

        dbContext.Users.Add(user);
        await dbContext.SaveChangesAsync(cancellationToken);

        eventPublisher.EnqueueEvent(
            new UserRegisteredEvent()
            {
                UserId = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                Password = password
            }
        );
    }
}
