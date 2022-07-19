using Newtonsoft.Json;
using SGWebAPI.Core;
using SGWebAPI.Models.Message;

namespace SGWebAPI.Middleware
{
    public class SGExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public SGExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }            
            catch (Exception ex)
            {
                var uiErrorMessages = GetMessage(ex);
                var json = GetJson(uiErrorMessages);
                await WriteResponseAsync(context, json, ex);
            }
        }

        private static IEnumerable<string> GetMessage(Exception ex)
        {
            yield return ex is SGException gravityException ? gravityException.UserFriendlyMessage : ex.Message;
        }
       
        private static string GetJson(IEnumerable<string> messages)
        {
            return
                JsonConvert.SerializeObject(new UIMessage
                {
                    Messages = messages.ToList()
                });
        }

        private static async Task WriteResponseAsync(HttpContext context, string errorMessage, Exception ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = GetStatusCode(ex);
            await context.Response.WriteAsync(errorMessage);
        }

        private static int GetStatusCode(Exception ex)
        {
            switch (ex)
            {
                case Exception11HK _:
                    return StatusCodes.Status504GatewayTimeout;
                case Exception388HK _:
                    return StatusCodes.Status403Forbidden;
                default:
                    return StatusCodes.Status500InternalServerError;
            }
        }
    }
}
