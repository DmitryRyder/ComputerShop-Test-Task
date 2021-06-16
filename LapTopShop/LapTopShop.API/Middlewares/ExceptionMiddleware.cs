using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace LapTopShop.API.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (ArgumentNullException ex)
            {
                await HandleExceptionAsync(context, ex.Message, HttpStatusCode.BadRequest);
            }
            catch (ArgumentException ex)
            {
                await HandleExceptionAsync(context, ex.Message, HttpStatusCode.BadRequest);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex.Message, HttpStatusCode.InternalServerError);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, string message, HttpStatusCode code)
        {
            var response = context.Response;

            response.ContentType = "application/json";
            response.StatusCode = (int)code;

            await response.WriteAsync(JsonConvert.SerializeObject(new BaseResponseModel(message, code)));
        }

        private class BaseResponseModel
        {
            public string ResponseMessage { get; set; }

            public HttpStatusCode ResponseCode { get; set; } = HttpStatusCode.OK;

            public BaseResponseModel() { }

            public BaseResponseModel(string message, HttpStatusCode httpCode)
            {
                ResponseMessage = message;
                ResponseCode = httpCode;
            }
        }
    }
}
