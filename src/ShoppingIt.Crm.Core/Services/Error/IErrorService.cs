// <copyright file="IErrorService.cs" company="ShoppingIt Ltd">
// Copyright (c) ShoppingIt Ltd. All rights reserved.
// </copyright>

namespace ShoppingIt.Crm.Core.Services.Error
{
    /// <summary>
    /// Defines error service operations.
    /// </summary>
    public interface IErrorService
    {
        /// <summary>
        /// Handle bad request errors.
        /// </summary>
        /// <param name="message">The error message to return to client.</param>
        void HandleBadRequest(string message);
    }
}
