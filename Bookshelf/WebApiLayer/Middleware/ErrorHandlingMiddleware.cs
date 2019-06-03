using System;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using BLL.Interfaces.Localizations.Exceptions;

namespace WebApiLayer.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        IUnitOfWorkExceptionMessageLocalization _unitOfWorkExceptionMessageLocalization;
        public ErrorHandlingMiddleware(RequestDelegate next, IUnitOfWorkExceptionMessageLocalization unitOfWorkExceptionMessageLocalization)
        {
            _next = next;
            _unitOfWorkExceptionMessageLocalization = unitOfWorkExceptionMessageLocalization;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex, _unitOfWorkExceptionMessageLocalization);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception, IUnitOfWorkExceptionMessageLocalization unitOfWorkExceptionMessageLocalization)
        {
            var code = HttpStatusCode.InternalServerError; // 500 if unexpected
            var exceptionMessage = JsonConvert.SerializeObject(new { error = exception.Message });
            if (exception is NotFoundException) code = HttpStatusCode.NotFound;
            else if (exception is UnauthorizedException) code = HttpStatusCode.Unauthorized;
            else if (exception is ForbiddenException) code = HttpStatusCode.Forbidden;
            else if (exception is BadRequestException) code = HttpStatusCode.BadRequest;
            else if (exception is DbUpdateConcurrencyException)
            {
                code = HttpStatusCode.Conflict;
                exceptionMessage = JsonConvert.SerializeObject(new
                {
                    error = unitOfWorkExceptionMessageLocalization.DbUpdateConcurrencyException.RecordToEditWasModifiedAnotherUser
                }); 
            }
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(exceptionMessage);
        }
    }
}