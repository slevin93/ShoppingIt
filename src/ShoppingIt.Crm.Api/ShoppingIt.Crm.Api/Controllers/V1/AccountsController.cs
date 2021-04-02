// <copyright file="AccountsController.cs" company="ShoppingIt Ltd">
// Copyright (c) ShoppingIt Ltd. All rights reserved.
// </copyright>

namespace ShoppingIt.Crm.Api.Controllers
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using ShoppingIt.Crm.Core.Dto.Accounts;
    using ShoppingIt.Crm.Core.Services.Accounts;

    /// <summary>
    /// Gabdkes queryes relating to accounts.
    /// </summary>
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService accountService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountsController"/> class.
        /// </summary>
        /// <param name="accountService">The injected account service.</param>
        public AccountsController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        /// <summary>
        /// Get user account details.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Returns found account details.</returns>
        [HttpGet]
        public async Task<ActionResult<AccountDetails>> AccountDetails(CancellationToken cancellationToken)
        {
            return this.Ok(await this.accountService.GetAccountsAsync(cancellationToken));
        }
    }
}
