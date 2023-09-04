using Application.Exceptions;
using FluentValidation;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.Filters;

public class ValidationFilter<T>:Attribute, IActionFilter 
{
    
    public void OnActionExecuting(ActionExecutingContext context)
    {
      var model =  (T)context.ActionArguments["request"];
      var validator =(IValidator<T>)context.HttpContext.RequestServices.GetService(typeof(IValidator<T>));
     var result = validator.Validate(model);
     Console.WriteLine((validator.GetType().FullName));
  
     Console.WriteLine(!result.IsValid);
      if (!result.IsValid)
      {
          throw new ValidateException("неверные данные");
      }
    
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        return;
    }
}