﻿using Azure;
using BlogPost.API.Model.DTO;
using BlogPost.API.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Microsoft.Win32;

namespace BlogPost.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly ITokenRepository tokenrepository;

        public AuthController(UserManager<IdentityUser> userManager,
            ITokenRepository tokenrepository)
        {
            this.userManager = userManager;
            this.tokenrepository = tokenrepository;
        }

        //POST:{apibaseurl}/api/auth/login 
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> logIn([FromBody] LogInRequestsDto requestDtoLogIn)
        {
            //check email 
            var identityUser = await userManager.FindByEmailAsync(requestDtoLogIn.Email);

            if (identityUser != null)
            {
                var checkPasswordResult = await userManager.CheckPasswordAsync(identityUser, requestDtoLogIn.Password);

                if (checkPasswordResult)
                {
                    var roles = await userManager.GetRolesAsync(identityUser);

                    //Create Token and Response
                    var jwtToken = tokenrepository.CreateJwtToken(identityUser, roles.ToList());

                    var logInresponse = new LogInResponseDto()
                    {
                        Email = requestDtoLogIn.Email,
                        Roles = roles.ToList(),
                        Token = jwtToken
                    };

                    return Ok(logInresponse);
                }
            }

            ModelState.AddModelError("", "Email or Password Incorrect");
            return ValidationProblem(ModelState);
        }






        //POST: {apibaseurl}/api/auth/register
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto requestDtoRegister)
        {
            //Create IdentityUser object 

            var user = new IdentityUser
            {
                UserName = requestDtoRegister.Email?.Trim(),
                Email = requestDtoRegister.Email?.Trim()
            };


            //Create User
            var identityResult = await userManager.CreateAsync(user, requestDtoRegister.Password);

            if (identityResult.Succeeded)
            {
                //Add Role to user (Reader) 
                identityResult = await userManager.AddToRoleAsync(user, "Reader");

                if (identityResult.Succeeded) 
                {
                    return Ok("Succeeded Added Role to User");
                }
                else
                {
                    if (identityResult.Errors.Any())
                    {
                        foreach (var error in identityResult.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                    }
                }

            }

            else
            {
                if(identityResult.Errors.Any())
                {
                    foreach (var error in identityResult.Errors) 
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }

            return ValidationProblem(ModelState);
        }
    }
}
