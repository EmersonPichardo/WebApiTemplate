using Application;
using Application._Common.Caching;
using Application._Common.Events;
using Application._Common.Exceptions;
using Application._Common.Notifications.Emails;
using Application._Common.Persistence.Databases;
using Application._Common.Security.Authentication;
using FluentValidation;
using Infrastructure._Common.Behaviors;
using Infrastructure._Common.Caching;
using Infrastructure._Common.Events;
using Infrastructure._Common.Notification.Email;
using Infrastructure._Common.Persistence.Databases.ApplicationDbContext;
using Infrastructure._Common.Persistence.Databases.Interceptors;
using Infrastructure._Security;
using MediatR.NotificationPublishers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Infrastructure;

public static partial class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        return services
            .AddNotificationsServices()
            .AddDbContextServices(configuration)
            .AddSecurityServices()
            .AddAutoMapperServices()
            .AddFluentValidationServices()
            .AddCacheServices(configuration)
            .AddHealthChecksServices(configuration)
            .AddMediatorServices();
    }

    private static IServiceCollection AddNotificationsServices(this IServiceCollection services)
    {
        services
            .AddScoped<IEventPublisher, EventPublisher>()
            .AddTransient<IEmailSender, EmailSender>();

        return services;
    }
    private static IServiceCollection AddDbContextServices(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddDbContext<IApplicationDbContext, ApplicationDbContext>(options =>
                options.UseNpgsql(
                    configuration.GetConnectionString(nameof(ApplicationDbContext)),
                    builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)
                )
            );

        services
            .AddScoped<AuditableEntitySaveChangesInterceptor>();

        return services;
    }
    private static IServiceCollection AddSecurityServices(this IServiceCollection services)
    {
        services
            .AddTransient<IPasswordHasher, PasswordHasher>()
            .AddTransient<IJwtService, JwtService>();

        return services;
    }
    private static IServiceCollection AddAutoMapperServices(this IServiceCollection services)
    {
        services.AddAutoMapper(
            typeof(IApplicationAssembly).Assembly,
            Assembly.GetExecutingAssembly()
            );

        return services;
    }
    private static IServiceCollection AddFluentValidationServices(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(
            Assembly.GetExecutingAssembly(),
            includeInternalTypes: true
        );

        return services;
    }
    private static IServiceCollection AddCacheServices(this IServiceCollection services, IConfiguration configuration)
    {
        var cacheConnectionString = configuration.GetConnectionString(nameof(CacheStore))
            ?? throw new NotFoundException($"Connection string {nameof(CacheStore)} was nor found.");

        services
            .AddStackExchangeRedisCache(options =>
                options.Configuration = cacheConnectionString
            )
            .AddSingleton<ICacheStore, CacheStore>();

        return services;
    }
    private static IServiceCollection AddHealthChecksServices(this IServiceCollection services, IConfiguration configuration)
    {
        var cacheConnectionString = configuration.GetConnectionString(nameof(CacheStore))
            ?? throw new NotFoundException($"Connection string {nameof(CacheStore)} was nor found.");

        services
            .AddHealthChecks()
            .AddDbContextCheck<ApplicationDbContext>()
            .AddRedis(cacheConnectionString)
            .AddCheck<EmailHealthCheck>("Email");

        return services;
    }
    private static IServiceCollection AddMediatorServices(this IServiceCollection services)
    {
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());

            configuration.AddOpenRequestPreProcessor(typeof(LoggingBehavior<>));
            configuration.AddOpenBehavior(typeof(TransactionBehavior<,>));
            configuration.AddOpenBehavior(typeof(PerformanceBehavior<,>));
            configuration.AddOpenBehavior(typeof(AuthorizationBehavior<,>));
            configuration.AddOpenBehavior(typeof(CachingBehavior<,>));
            configuration.AddOpenBehavior(typeof(ValidationBehavior<,>));
            configuration.AddOpenRequestPostProcessor(typeof(EventBehavior<,>));
            configuration.AddOpenRequestPostProcessor(typeof(LoggingBehavior<,>));

            configuration.NotificationPublisher = new TaskWhenAllPublisher();
            configuration.NotificationPublisherType = typeof(TaskWhenAllPublisher);
            configuration.Lifetime = ServiceLifetime.Transient;
        });

        return services;
    }
}
