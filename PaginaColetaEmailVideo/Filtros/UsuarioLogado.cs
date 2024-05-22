﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using PaginaColetaEmailVideo.Models;

namespace PaginaColetaEmailVideo.Filtros
{
    public class UsuarioLogado : ActionFilterAttribute
    {

        public override void OnActionExecuted(ActionExecutedContext context)
        {

            string sessaoUsuario = context.HttpContext.Session.GetString("UsuarioAtivo");

            if (string.IsNullOrEmpty(sessaoUsuario))
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary
                {
                    {"controller", "Home" },
                    {"Action", "Index"}
                });
            }
            else
            {
                UsuarioModel usuario = JsonConvert.DeserializeObject<UsuarioModel>(sessaoUsuario);

                if(usuario == null) {

                    context.Result = new RedirectToRouteResult(new RouteValueDictionary
                {
                    {"controller", "Home" },
                    {"Action", "Index"}
                });
                }
            }



            base.OnActionExecuted(context);
        }


    }
}
