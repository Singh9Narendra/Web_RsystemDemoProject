﻿using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

public class GlobalExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        var statusCode = context.Exception switch
        {
            FileNotFoundException => StatusCodes.Status404NotFound,

            ValidationException => StatusCodes.Status400BadRequest,

            UnauthorizedAccessException => StatusCodes.Status401Unauthorized,

            _ => StatusCodes.Status500InternalServerError
        };

        context.Result = new ObjectResult(new
        {
            error = context.Exception.Message,
            stackTrace = context.Exception.StackTrace
        })
        {
            StatusCode = statusCode
        };
    }
}