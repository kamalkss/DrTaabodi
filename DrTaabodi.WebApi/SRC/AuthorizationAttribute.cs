using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace DrTaabodi.WebApi.SRC
{
    public class AuthorizationAttribute : Attribute, IAuthorizationFilter, IOrderedFilter
    {
        public int Order => 0;
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            context.Result = new UnauthorizedResult();
        }
    }
}
