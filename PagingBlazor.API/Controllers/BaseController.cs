using Microsoft.AspNetCore.Mvc;
using PagingBlazor.API.Interfaces;

namespace PagingBlazor.API.Controllers
{
    public abstract class BaseController<T> : ControllerBase where T : IService
    {
        protected T service;
        protected ILogger logger;
        public BaseController(IServiceProvider serviceProvider)
        {
            service = serviceProvider.GetService<T>();
        }
        protected string GetExceptionMessage(Exception e)
        {
            string message = "";
            if (e.InnerException != null)
            {
                message = GetExceptionMessage(e.InnerException) + ", ";
            }
            return string.IsNullOrEmpty(message) ? e.Message : message;
        }
    }
}
