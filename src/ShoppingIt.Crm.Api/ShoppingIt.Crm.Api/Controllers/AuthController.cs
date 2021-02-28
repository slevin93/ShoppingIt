using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingIt.Crm.Core.Dto;
using ShoppingIt.Crm.Core.Dto.Accounts;
using ShoppingIt.Crm.Core.Models.Account;
using ShoppingIt.Crm.Core.Services.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ShoppingIt.Crm.Api.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAccountService accountService;

        public AuthController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        /// <summary>
        /// Login with provided details.
        /// </summary>
        /// <param name="loginModel">Login information.</param>
        /// <returns>Returns access token.</returns>
        [HttpPost("login")]
        public async Task<ActionResult<AccessToken>> Login(LoginModel loginModel, CancellationToken cancellationToken)
        {
            return Ok(await this.accountService.LoginAsync(loginModel, cancellationToken));
        }

        /// <summary>
        /// Register account with provided details. Note, this is for public users not admin.
        /// </summary>
        /// <param name="registerModel">The account details to save.</param>
        /// <returns>Returns newly created account.</returns>
        [HttpPost("register")]
        public async Task<ActionResult<AccountDetails>> Register(RegisterModel registerModel, CancellationToken cancellationToken)
        {
            return Ok(await this.accountService.RegisterAsync(registerModel, cancellationToken));
        }
    }
}
