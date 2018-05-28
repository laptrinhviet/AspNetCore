using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore.Services.Systems.Users;
using AspNetCore.Services.Systems.Users.Dtos;
using AspNetCore.Authorization;
using AspNetCore.Helpers;

namespace AspNetCore.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserService _userService;
        private readonly IAuthorizationService _authorizationService;

        public UserController(IUserService userService, IAuthorizationService authorizationService)
        {
            _userService = userService;
            _authorizationService = authorizationService;
        }

        //[ClaimRequirement("","CanReadResource")]
        public async Task<IActionResult> Index()
        {
            var result = await _authorizationService.AuthorizeAsync(User, "USER", Operations.Read);
            if(result.Succeeded==false)
            {
                return new RedirectResult("/Admin/Login/Index");
            }
            return View();
        }

        public IActionResult GetAll()
        {
            var model = _userService.GetAllAsync();
            return new OkObjectResult(model);
        }

        [HttpGet]
        public async Task<IActionResult> GetById(Guid id)
        {
            var model = await _userService.GetById(id);
            return new OkObjectResult(model);
        }

        [HttpGet]
        public IActionResult GetAllPaging(string keyword, int page, int pageSize)
        {
            var model = _userService.GetAllPagingAsync(keyword, page, pageSize);
            return new OkObjectResult(model);
        }

        [HttpPost]
        public async Task<IActionResult> SaveEntity(AppUserViewModel appUserVm)
        {
            if(!ModelState.IsValid)
            {
                IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
                return new OkObjectResult(allErrors);
            }
            else
            {
                if(appUserVm.Id == Guid.Empty)
                {
                    await _userService.AddAsync(appUserVm);
                }
                else
                {
                    await _userService.UpdateAsync(appUserVm);
                }
                return new OkObjectResult(appUserVm);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            if(!ModelState.IsValid)
            {
                return new BadRequestObjectResult(ModelState);
            }
            else
            {
                await _userService.DeleteAsync(id);
                return new OkObjectResult(id);
            }
        }

    }
}