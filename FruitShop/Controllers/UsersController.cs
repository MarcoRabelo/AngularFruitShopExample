using FruitShop.Application.Interfaces;
using FruitShop.Application.ViewModels;
using FruitShop.Auth.Services;
using FruitShop.WebAPI.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;

namespace FruitShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public IActionResult Get([FromQuery] PaginationFilter filter)
        {
            return Ok(_userService.Get(filter.PageNumber, filter.PageSize));
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            try
            {
                return Ok(_userService.GetById(id));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST api/<UsersController>
        [HttpPost, AllowAnonymous]
        public IActionResult Post([FromBody] UserViewModel userViewModel)
        {
            try
            {
                userViewModel.Admin = false;
                _userService.Insert(userViewModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        // PUT api/<UsersController>
        [HttpPut]
        public IActionResult Put([FromBody] UserViewModel userViewModel)
        {
            try
            {
                userViewModel.Id = Convert.ToInt64(TokenService.GetValueFromClaim(HttpContext.User.Identity, ClaimTypes.NameIdentifier));
                _userService.Update(userViewModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        // DELETE api/<UsersController>
        [HttpDelete]
        public IActionResult Delete()
        {
            try
            {
                //Delete your own account
                return Ok(_userService.Delete(Convert.ToInt64(TokenService.GetValueFromClaim(HttpContext.User.Identity, ClaimTypes.NameIdentifier))));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                if (Convert.ToBoolean(TokenService.GetValueFromClaim(HttpContext.User.Identity, ClaimTypes.Role)))
                {
                    //Admin delete someone's account
                    return Ok(_userService.Delete(id));
                }
                else
                {
                    return Unauthorized();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<UsersController>/authenticate
        [HttpPost("authenticate"), AllowAnonymous]
        public IActionResult Authenticate([FromBody] UserAuthenticateRequestViewModel userAuthenticateRequest)
        {
            try
            {
                return Ok(_userService.Authenticate(userAuthenticateRequest));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<UsersController>/newadmin
        [HttpPost("newadmin")]
        public IActionResult NewAdmin([FromBody] UserViewModel userViewModel)
        {
            try
            {
                if (Convert.ToBoolean(TokenService.GetValueFromClaim(HttpContext.User.Identity, ClaimTypes.Role)))
                {
                    _userService.Insert(userViewModel);
                }
                else
                {
                    return Unauthorized();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }
    }
}
