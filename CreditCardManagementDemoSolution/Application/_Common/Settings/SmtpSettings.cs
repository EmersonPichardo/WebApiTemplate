using System.ComponentModel.DataAnnotations;

namespace Application._Common.Settings;

public record SmtpSettings
{
    [Required]
    public required string Server { get; init; }

    [Required, EmailAddress]
    public required string FromEmail { get; init; }

    [Required]
    public required string FromName { get; init; }

    [Required]
    public int Port { get; init; }

    public string? Password { get; init; }
}
