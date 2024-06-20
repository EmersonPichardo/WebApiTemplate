using Application._Common.Notifications.Emails;
using Application.Users.Register;
using MediatR;

namespace Infrastructure.Users.Register;

internal class UserRegisteredEventSendPasswordHandler(
    IEmailSender emailSender
)
    : INotificationHandler<UserRegisteredEvent>
{
    public async Task Handle(UserRegisteredEvent @event, CancellationToken cancellationToken)
    {
        await emailSender.SendAsync(
            @event.Email,
            $"Welcome to the application {@event.FullName}!",
            $"Your password is: {@event.Password}",
            cancellationToken
        );
    }
}
