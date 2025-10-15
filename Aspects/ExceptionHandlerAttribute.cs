using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using UserLogin.Exception;

namespace UserLogin.Aspects
{
    public class ExceptionHandlerAttribute: ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)

        {

            var exceptionType = context.Exception.GetType();

            var message = context.Exception.Message;

            /*if (exceptionType == typeof(StudentNotFoundException))
 
            {
 
                var result = new NotFoundObjectResult(message);
 
                context.Result = result;
 
            }*/

            if (exceptionType == typeof(UserAlreadyExistsException))

            {

                var result = new ConflictObjectResult(message);

                context.Result = result;

            }
            else if(exceptionType == typeof(UserNotFoundException))
            {
                var result = new NotFoundObjectResult(message);

                context.Result = result;
            }
           

            else

            {

                var result = new StatusCodeResult(500);

                context.Result = result;

            }

        }

    }

}


    

