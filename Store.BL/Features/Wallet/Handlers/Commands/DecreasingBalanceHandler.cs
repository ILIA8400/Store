using MediatR;
using Store.BL.Features.Wallet.Requests.Commands;
using Store.Domain.Entities;
using Store.Repositories.Address;
using Store.Repositories.Basket;
using Store.Repositories.Invoice;
using Store.Repositories.InvoiceItem;
using Store.Repositories.Product;
using Store.Repositories.Wallet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BL.Features.Wallet.Handlers.Commands
{
    public class DecreasingBalanceHandler : IRequestHandler<DecreasingBalanceCommandRequest>
    {
        private readonly IWalletRepository walletRepository;
        private readonly IBasketRepository basketRepository;
        private readonly IProductRepository productRepository;
        private readonly IInvoiceRepository invoiceRepository;
        private readonly IAddressRepository addressRepository;
        private readonly IInvoiceItemRepository invoiceItemRepository;

        public DecreasingBalanceHandler(
            IWalletRepository walletRepository,
            IBasketRepository basketRepository,
            IProductRepository productRepository,
            IInvoiceRepository invoiceRepository,
            IAddressRepository addressRepository,
            IInvoiceItemRepository invoiceItemRepository
            )
        {
            this.walletRepository = walletRepository;
            this.basketRepository = basketRepository;
            this.productRepository = productRepository;
            this.invoiceRepository = invoiceRepository;
            this.addressRepository = addressRepository;
            this.invoiceItemRepository = invoiceItemRepository;
        }

        public async Task Handle(DecreasingBalanceCommandRequest request, CancellationToken cancellationToken)
        {
            var walletUserDiscount = await walletRepository.GetWalletByUserAndDisount(request.UserId);

            // کاهش موجودی کیف پول
            var newBalance = walletUserDiscount.Balance - request.Amount;
            walletUserDiscount.Balance = newBalance;

            // ساخت تراکنش
            var transaction = new Store.Domain.Entities.Transaction
            {
                Amount = request.Amount,
                DateTime = DateTime.Now,
                TransactionStatus = Domain.Enum.TransactionStatus.Successed,
                TransactionType = -1,
                WalletId = walletUserDiscount.WalletId,
                Wallet = walletUserDiscount,
            };

            // اضافه کردن تراکنش به کیف پول
            if (walletUserDiscount.Transactions == null)
            {
                walletUserDiscount.Transactions = new List<Store.Domain.Entities.Transaction>();
            }
            walletUserDiscount.Transactions.Add(transaction);

            // حذف تخفیف در صورت استفاده
            if (request.Discount > 0)
            {             
                walletUserDiscount.User.Discount = null;
                walletUserDiscount.User.DiscountId = null;
            }

            // کاهاش موجودی محصولات
            await productRepository.ReducingTheInventoryOfPurchasedProducts(request.UserId);

            // داده های مورد نیاز         
            int? discountId = null;
            if (request.Discount > 0)
            {
                discountId = walletUserDiscount.User.Discount.DiscountId;
            }
            var defaultAddressId = await addressRepository.GetDefaultAddressIdOfUser(request.UserId);
            var numberOfItems = await basketRepository.GetTotalNumberOfProducts(request.UserId);
            var invoiceItems = await invoiceItemRepository.GetInvoiceItemWithUserId(request.UserId);
            ///////////////

            // افزودن فاکتور
            var newInvoice = new Invoice
            {
                ApplicationUserId = request.UserId,
                TotalAmount = request.Amount,
                DateTime = DateTime.Now,
                DiscountId = discountId,
                AddressId = defaultAddressId,
                NumberOfItem = numberOfItems,
                InvoiceItems = invoiceItems,
            };
            invoiceRepository.Add(newInvoice);

            // خالی کردن سبد و ایتم هاش
            await basketRepository.ClearBasket(request.UserId);

            await walletRepository.SaveChange();
        }
    }
}
