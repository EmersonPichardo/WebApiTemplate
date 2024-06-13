using Infrastructure._Security;

namespace Infrastructure._Common.Validations;

internal static class ValidationErrorMessages
{
    internal const string Required = "Required";
    internal const string InvalidFormat = "Invalid format";
    internal const string OnlyNumbers = "Only numbers are allowed";
    internal const string NotFound = "Not found";
    internal const string Conflict = "Already registered";
    internal const string RestrictedDeletion = "Unable to delete resource as it is in use by another resource";
    internal const string MaximumLength = "Maximum length {MaxLength}";
    internal const string MinimumLength = "Minimum length {MinLength}";
    internal const string Length = "Length must be {MinLength}";
    internal const string GreaterThan = "Must be greater than {ComparisonValue}";
    internal const string LessThan = "Must be less than {ComparisonValue}";
    internal const string Between = "Must be between {From} and {To}";

    internal const string MustContainLowercase = "Must contain at least one lowercase letter";
    internal const string MustContainUppercase = "Must contain at least one uppercase letter";
    internal const string MustContainNumbers = "Must contain at least one number";
    internal const string MustContainSpecials = "Must contain at least one special character (!@#$%^&*()_+=[]{};:<>|./?,-)";
    internal const string PasswordsMustMatch = "Passwords are not the same";
    internal static readonly string IncorrectPasswordPolicy =
        @$"{MinimumLength.Replace("{MinLength}", PasswordPolicy.MinimumLength.ToString())}.
        {MustContainUppercase}.
        {MustContainUppercase}.
        {MustContainNumbers}.
        MustContainSpecials";
}
