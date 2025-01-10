using MediatR;
using Microsoft.EntityFrameworkCore;
using Store.BL.DTOs;
using Store.BL.Features.AdminPanel.Requests.Queries;
using Store.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BL.Features.AdminPanel.Handlers.Queries
{
    public class GetProductListRequestHandler : IRequestHandler<GetProductListRequest, ProductInfoDto>
    {
        private readonly StoreDbContext context;

        public GetProductListRequestHandler(StoreDbContext storeDbContext)
        {
            this.context = storeDbContext;
        }
        public async Task<ProductInfoDto> Handle(GetProductListRequest request, CancellationToken cancellationToken)
        {
            var dto = new ProductInfoDto();
            dto.Products = new List<ProductInfoDto>();

            var productInfos = await context.Products
                .Join(context.Categories, p => p.CategoryId, c => c.CategoryId, (p, c) => new { p, c })
                .Join(context.Brands, pc => pc.p.BrandId, b => b.BrandId, (pc, b) => new { pc.p, pc.c, b })
                .GroupJoin(context.Discounts, pcb => pcb.p.DiscountId, d => d.DiscountId, (pcb, d) => new { pcb.p, pcb.c, pcb.b, d })
                .SelectMany(pcb => pcb.d.DefaultIfEmpty(), (pcb, discount) => new { pcb.p, pcb.c, pcb.b, Discount = discount })
                .GroupJoin(context.Medias, p => p.p.ProductId, m => m.ProductId, (p, m) => new { p.p, p.c, p.b, p.Discount, m })
                .SelectMany(p => p.m.DefaultIfEmpty(), (p, media) => new ProductInfoDto
                {
                    ProductId = p.p.ProductId,
                    ProductName = p.p.ProductName,
                    ProductDescription = p.p.Description,
                    Price = p.p.Price,
                    Path = media.Path,
                    AvaillableQuentity = p.p.AvaillableQuentity,
                    CategoryName = p.c.CategoryName,
                    DiscountPercentage = (byte)(p.Discount.DiscountPercentage != null ? p.Discount.DiscountPercentage : 0),
                    Brand = p.b.BrandName,
                    Products = null
                }).ToListAsync();

            dto.Products.AddRange(productInfos);
            return dto;

        }
    }
}
