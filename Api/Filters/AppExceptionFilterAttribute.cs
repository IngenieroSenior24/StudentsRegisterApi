using System.Net;
using Application.Common.Exceptions;
using Domain.Exceptions;
using Domain.Exceptions.Common;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.Filters;

[AttributeUsage(AttributeTargets.All)]
public sealed class AppExceptionFilterAttribute : ExceptionFilterAttribute
{
    private readonly ILogger<AppExceptionFilterAttribute> _logger;

    public AppExceptionFilterAttribute(ILogger<AppExceptionFilterAttribute> logger)
    {
        _logger = logger;
    }


    public override void OnException(ExceptionContext context)
    {
        if (context == null) return;

        context.HttpContext.Response.StatusCode = context.Exception switch
        {
            ValidationException  => (int)HttpStatusCode.BadRequest,
            ResourceNotFoundException => (int)HttpStatusCode.NotFound,
            ResourceAlreadyExistException => (int)HttpStatusCode.Conflict,
            CoreBusinessException => (int)HttpStatusCode.BadRequest,
            ForbiddenException => (int)HttpStatusCode.Forbidden,
            ConflictException => (int)HttpStatusCode.Conflict,
            CustomException => (int)HttpStatusCode.BadRequest,
            InvalidOperationException => (int)HttpStatusCode.BadRequest,
            
            _ => (int)HttpStatusCode.InternalServerError
        };

        _logger.LogError(context.Exception, context.Exception.Message, context.Exception.StackTrace);
        ErrorResponse errorResponse = new ErrorResponse(context.HttpContext.Response.StatusCode, context.Exception.Message, context.Exception.GetType().Name);

        context.Result = new ObjectResult(errorResponse);
    }

}