using BLL.Interfaces.Localizations.Exceptions;
using Microsoft.AspNetCore.Builder;

namespace WebApiLayer.Middleware
{
    public static class ErrorHandlingMiddlewareExtensions
    {
        public static IApplicationBuilder UseErrorHandlingMiddleware(this IApplicationBuilder builder, IUnitOfWorkExceptionMessageLocalization unitOfWorkExceptionMessageLocalization)
        {
            return builder.UseMiddleware<ErrorHandlingMiddleware>(unitOfWorkExceptionMessageLocalization);
        }
    }
}
