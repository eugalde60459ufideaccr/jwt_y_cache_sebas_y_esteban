using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_CreandoRecuerdos.Filters
{
    public class JwtSessionSyncFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var user = HttpContext.Current.User as ClaimsPrincipal;
            if (user != null && user.Identity.IsAuthenticated)
            {
                var rol = user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
                var nombre = user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;

                // Refrescar variables de sesión
                HttpContext.Current.Session["Rol"] = rol;
                HttpContext.Current.Session["Usuario"] = nombre;
            }

            base.OnActionExecuting(filterContext);
        }
    }
}