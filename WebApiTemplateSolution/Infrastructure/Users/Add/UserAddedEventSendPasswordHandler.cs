using Application._Common.Notifications.Emails;
using Application.Users.Add;
using MediatR;

namespace Infrastructure.Users.Add;

internal class UserAddedEventSendPasswordHandler(
    IEmailSender emailSender
)
    : INotificationHandler<UserAddedEvent>
{
    public async Task Handle(UserAddedEvent @event, CancellationToken cancellationToken)
    {
        await emailSender.SendAsync(
            @event.Email,
            $"Welcome to the application {@event.FullName}!",
            $"Your password is: {@event.Password}",
            cancellationToken
        );
    }
}
