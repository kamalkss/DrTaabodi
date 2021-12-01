using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DrTaabodi.WebApi.SRC;

public class AuthorizationAttribute : Attribute, IAuthorizationFilter, IOrderedFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        context.Result = new UnauthorizedResult();
    }

    public int Order => 0;
}