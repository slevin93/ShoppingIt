// <copyright file="AuthController.cs" company="ShoppingIt Ltd">
// Copyright (c) ShoppingIt Ltd. All rights reserved.
// </copyright>

namespace ShoppingIt.Crm.Api.Controllers
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using ShoppingIt.Crm.Core.Dto;
    using ShoppingIt.Crm.Core.Dto.Accounts;
    using ShoppingIt.Crm.Core.Models.Account;
    using ShoppingIt.Crm.Core.Services.Accounts;

    /// <summary>
    /// Handles queries relating to authentication.
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAccountService accountService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthController"/> class.
        /// </summary>
        /// <param name="accountService">The account service.</param>
        public AuthController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        /// <summary>
        /// Login with provided details.
        /// </summary>
        /// <param name="loginModel">Login information.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Returns access token.</returns>
        [HttpPost("login")]
        public async Task<ActionResult<AccessToken>> Login(LoginModel loginModel, CancellationToken cancellationToken)
        {
            return this.Ok(await this.accountService.LoginAsync(loginModel, cancellationToken));
        }

        /// <summary>
        /// Register account with provided details. Note, this is for public users not admin.
        /// </summary>
        /// <param name="registerModel">The account details to save.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Returns newly created account.</returns>
        [HttpPost("register")]
        public async Task<ActionResult<AccountDetails>> Register(RegisterModel registerModel, CancellationToken cancellationToken)
        {
            return this.Ok(await this.accountService.RegisterAsync(registerModel, cancellationToken));
        }
    }
}
