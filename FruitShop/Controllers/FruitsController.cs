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
    public class FruitsController : ControllerBase
    {
        private readonly IFruitService _fruitService;

        public FruitsController(IFruitService fruitService)
        {
            _fruitService = fruitService;
        }

        // GET: api/<FruitsController>
        [HttpGet, AllowAnonymous]
        public IActionResult Get([FromQuery] PaginationFilter filter)
        {
            return Ok(_fruitService.Get(filter.PageNumber, filter.PageSize));
        }

        // GET api/<FruitsController>/5
        [HttpGet("{id}"), AllowAnonymous]
        public IActionResult Get(long id)
        {
            try
            {
                return Ok(_fruitService.GetById(id));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST api/<FruitsController>
        [HttpPost]
        public IActionResult Post([FromBody] FruitViewModel fruitViewModel)
        {
            try
            {
                if (Convert.ToBoolean(TokenService.GetValueFromClaim(HttpContext.User.Identity, ClaimTypes.Role)))
                {
                    _fruitService.Insert(fruitViewModel);
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

        // PUT api/<FruitsController>
        [HttpPut]
        public IActionResult Put([FromBody] FruitViewModel fruitViewModel)
        {
            try
            {
                if (Convert.ToBoolean(TokenService.GetValueFromClaim(HttpContext.User.Identity, ClaimTypes.Role)))
                {
                    _fruitService.Update(fruitViewModel);
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

        //TODO: Allow this function to only registered users. 
        [HttpPut("addtocart"), AllowAnonymous]
        public IActionResult AddToCart([FromBody] FruitToCartViewModel fruitToCart)
        {
            try
            {
                _fruitService.AddToCart(fruitToCart);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        // DELETE api/<FruitsController>
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            try
            {
                if (Convert.ToBoolean(TokenService.GetValueFromClaim(HttpContext.User.Identity, ClaimTypes.Role)))
                {
                    return Ok(_fruitService.Delete(id));
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
    }
}
