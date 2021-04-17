// <copyright file="ILookupRepository.cs" company="ShoppingIt Ltd">
// Copyright (c) ShoppingIt Ltd. All rights reserved.
// </copyright>

namespace ShoppingIt.Crm.Core.Repository
{
    using System.Threading;
    using System.Threading.Tasks;
    using ShoppingIt.Crm.Core.Dto.Lookup;

    /// <summary>
    /// Define lookup data access.
    /// </summary>
    public interface ILookupRepository
    {
        /// <summary>
        /// Gets list of sales status.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token <see cref="CancellationToken"/>.</param>
        /// <returns>Returns array of sales status.</returns>
        Task<SalesStatusDetails[]> GetSaleStatusAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Gets list of payment types.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Returns array of payment types.</returns>
        Task<PaymentTypeDetails[]> GetPaymentTypeAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Gets payment type where the payment type is equal to the provided payment type.
        /// </summary>
        /// <param name="id">The payment type.</param>
        /// <param name="cancellationToken">The Cancellation token.</param>
        /// <returns>Returns the payment type where the id matches the provided id.</returns>
        Task<PaymentTypeDetails> GetPaymentTypeByIdAsync(int id, CancellationToken cancellationToken);

        /// <summary>
        /// Gets list of sales status.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Returns array of order status.</returns>
        Task<OrderStatusDetails[]> GetOrderStatusAsync(CancellationToken cancellationToken);
    }
}
