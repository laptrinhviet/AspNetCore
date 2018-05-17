﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AspNetCore.Services.Systems.Functions;
using AspNetCore.Services.Systems.Functions.Dtos;
using AspNetCore.Utilities.Constants;
using AspNetCore.Extensions;

namespace AspNetCore.Areas.Admin.Components
{
    public class SideBarViewComponent : ViewComponent
    {
        private readonly IFunctionService _functionService;

        public SideBarViewComponent(IFunctionService functionService)
        {
            _functionService = functionService;
        }      

        public async Task<IViewComponentResult> InvokeAsync()
        {
            //var roles = ((ClaimsIdentity)User.Identity).Claims.FirstOrDefault(x => x.Type == CommonConstants.UserClaims.Roles);
            //List<FunctionViewModel> functions;
            //if (roles != null && roles.Value.Split(";").Contains(CommonConstants.AppRole.Admin))
            //    functions = await _functionService.GetAll(string.Empty);
            //else
            //    functions = await _functionService.GetAllWithPermission(User.Identity.Name);
            //return View(functions);

            var roles = ((ClaimsPrincipal)User).GetSpecificClaim("Roles");
            List<FunctionViewModel> functions;
            if (roles.Split(";").Contains(CommonConstants.AppRole.Admin))
            {
             functions = await _functionService.GetAll(string.Empty);
            
            }
            else
            {
                //TODO: Get by permission

                //functions = new List<FunctionViewModel>();

                //functions = await _functionService.GetAllWithPermission(User.Identity.Name);

                functions = await _functionService.GetAll(string.Empty);
            }
            return View(functions);
        }

    }
}
