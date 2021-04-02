// <copyright file="ErrorService.cs" company="ShoppingIt Ltd">
// Copyright (c) ShoppingIt Ltd. All rights reserved.
// </copyright>

namespace ShoppingIt.Crm.Core.Services.Error
{
    using System;

    /// <summary>
    /// Implements error service operations.
    /// </summary>
    public class ErrorService : IErrorService
    {
        /// <inheritdoc/>
        public void HandleBadRequest(string message)
        {
            throw new Exception(message);
        }
    }
}
