using Microsoft.AspNetCore.Mvc;
using RoadBoM.Web.Exceptions;
using RoadBoM.Web.Models.DTOs.Response;
using System.Net;
using System.Runtime.CompilerServices;

namespace RoadBoM.Web.ApiControllers
{
    public class ApiControllerBase : ControllerBase
    {
        //private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        //protected string CurrentUserId => User.Identity.GetUserId() ?? "Anonymous"; // TODO: Remove in production
        protected string CurrentUserId = "Anonymous";
        protected async Task<IApiResponse<T>> HandleApiOperationAsync<T>(Func<Task<DefaultApiResponse<T>>> action, [CallerLineNumber] int lineNo = 0, [CallerMemberName] string method = "")
        {
            var apiResponse = new DefaultApiResponse<T> { Code = $"{(int)HttpStatusCode.OK}", ShortDescription = "SUCCESS" };

            var userId = CurrentUserId;

            //log.Info($" / {method} by {userId} BEGINS.");
            try
            {
                if (!ModelState.IsValid)
                    throw new GenericException("There are some errors in your input, please correct them.", $"{(int)HttpStatusCode.BadRequest}");

                var methodResponse = await action.Invoke();

                apiResponse.Object = methodResponse.Object;
                apiResponse.ShortDescription = string.IsNullOrEmpty(methodResponse.ShortDescription)
                    ? apiResponse.ShortDescription
                    : methodResponse.ShortDescription;
                apiResponse.Code = string.IsNullOrEmpty(methodResponse.Code) ? apiResponse.Code : methodResponse.Code;
            }
            catch (GenericException igex)
            {
                //log.Warn($"/ {method} L{lineNo} by {userId} - {igex.ErrorCode}: {igex.Message}");
                apiResponse.ShortDescription = igex.Message;
                apiResponse.Code = igex.ErrorCode;

                if (!ModelState.IsValid)
                {
                    apiResponse.ValidationErrors = ModelState.ToDictionary(
                        m =>
                        {
                            var tokens = m.Key.Split('.');
                            return tokens.Length > 0 ? tokens[tokens.Length - 1] : tokens[0];
                        },
                        m => m.Value.Errors.Select(e => e.Exception?.Message ?? e.ErrorMessage)
                    );
                }
            }
            catch (Exception ex)
            {
                //log.Error($"/ {method} L{lineNo} by {userId} \n\n{ex}\n");
                apiResponse.ShortDescription = ex.Message;
                apiResponse.Code = $"{(int)HttpStatusCode.InternalServerError}";
            }

            //log.Info($" / {method} by {userId} ENDS.");

            return apiResponse;
        }
    }
}
