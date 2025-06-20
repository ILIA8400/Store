﻿using Microsoft.EntityFrameworkCore;
using Store.DAL;
using Store.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AddressEntity = Store.Domain.Entities.Address;

namespace Store.Repositories.Address
{
    public class AddressRepository : GenericRepository<AddressEntity>, IAddressRepository
    {
        private readonly StoreDbContext storeDbContext;

        public AddressRepository(StoreDbContext storeDbContext) : base(storeDbContext)
        {
            this.storeDbContext = storeDbContext;
        }

        public async Task DeleteAllUserAddress(string userId)
        {
            var user = storeDbContext.Users
                .Include(u => u.Addresses) // لود کردن آدرس‌های مرتبط
                .FirstOrDefault(u => u.Id == userId);

            if (user != null && user.Addresses.Any())
            {
                storeDbContext.Addresses.RemoveRange(user.Addresses); // حذف همه آدرس‌ها
                await storeDbContext.SaveChangesAsync();
            }
        }

        public async Task<List<AddressEntity>> GetAllAddressUser(string userId)
        {
            return await storeDbContext.Addresses.Where(x=>x.UserId == userId).ToListAsync();
        }

        public async Task<int> GetDefaultAddressIdOfUser(string userId)
        {
            return (await storeDbContext.Users.Where(x=>x.Id == userId).SingleOrDefaultAsync()).DefaultAddressId;
        }
    }
}
