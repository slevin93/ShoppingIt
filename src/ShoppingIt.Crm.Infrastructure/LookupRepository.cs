// <copyright file="LookupRepository.cs" company="ShoppingIt Ltd">
// Copyright (c) ShoppingIt Ltd. All rights reserved.
// </copyright>

namespace ShoppingIt.Crm.Infrastructure
{
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using ShoppingIt.Crm.Core.Dto.Lookup;
    using ShoppingIt.Crm.Core.Repository;
    using ShoppingIt.Crm.Domain;

    /// <summary>
    /// Lookup data access layer.
    /// </summary>
    public class LookupRepository : RepositoryBase, ILookupRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LookupRepository"/> class.
        /// </summary>
        /// <param name="context">The ShoppingIt db context.</param>
        /// <param name="mapper">The mapper.</param>
        public LookupRepository(ShoppingItContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        /// <inheritdoc/>
        public Task<OrderStatusDetails[]> GetOrderStatusAsync(CancellationToken cancellationToken)
        {
            return this.GetArrayAsync<SalesStatus, OrderStatusDetails>(cancellationToken);
        }

        /// <inheritdoc/>
        public Task<PaymentTypeDetails[]> GetPaymentTypeAsync(CancellationToken cancellationToken)
        {
            return this.GetArrayAsync<PaymentType, PaymentTypeDetails>(cancellationToken);
        }

        /// <inheritdoc/>
        public Task<PaymentTypeDetails> GetPaymentTypeByIdAsync(int id, CancellationToken cancellationToken)
        {
            return this.FirstOrDefaultAsync<PaymentType, PaymentTypeDetails>(x => x.PaymentTypeId == id, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<SalesStatusDetails[]> GetSaleStatusAsync(CancellationToken cancellationToken)
        {
            return this.GetArrayAsync<SalesStatus, SalesStatusDetails>(cancellationToken);
        }
    }
}
