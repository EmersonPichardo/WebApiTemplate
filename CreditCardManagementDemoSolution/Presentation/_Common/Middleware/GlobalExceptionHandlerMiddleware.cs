using Application._Common.Exceptions;

namespace Presentation._Common.Middleware;

internal class GlobalExceptionHandlerMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        HttpExceptionsResult result;

        try
        {
            await next(context);
        }
        catch (UnauthorizedAccessException)
        {
            await Results
                .Unauthorized()
                .ExecuteAsync(context);
        }
        catch (PasswordChangeRequiredException exception)
        {
            await Results
                .Problem(
                    statusCode: 403,
                    title: exception.Message
                )
                .ExecuteAsync(context);
        }
        catch (NotFoundException exception)
        {
            await Results
                .Problem(
                    statusCode: 404,
                    title: exception.Message
                )
                .ExecuteAsync(context);
        }
        catch (ValidationException exception)
        {
            result = new HttpExceptionsResult(
                exception.Errors
            );

            await Results
                .UnprocessableEntity(result)
                .ExecuteAsync(context);
        }
        catch (Exception exception)
        {
            await Results
                .Problem(
                    statusCode: 500,
                    title: exception.Message
                )
                .ExecuteAsync(context);
        }
    }

    private sealed record HttpExceptionsResult
    {
        public IReadOnlyDictionary<string, dynamic> Errors { get; init; }

        public HttpExceptionsResult(IDictionary<string, dynamic> errors)
            => Errors = errors.AsReadOnly();

        public HttpExceptionsResult(string key, dynamic value)
            => Errors = new Dictionary<string, dynamic>() {
                { key, value }
            };
    }
}
