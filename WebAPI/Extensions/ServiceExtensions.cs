using System.Runtime.CompilerServices;
using WebAPI.Exceptions;

namespace WebAPI.Extensions;

public static class ServiceExtensions
{
    public static void AddExceptionServices (this IServiceCollection service)
    {
        service.AddExceptionHandler<GlobalExceptionHandler>();
    }
}
