﻿using ECommerceWebApp.Data.Interfaces;
using ECommerceWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerceWebApp.Data
{
    public class ShoppingCartRepository : Repository<ShoppingCart>, IShoppingCartRepository
    {
        private readonly DatabaseContext _context;
        public ShoppingCartRepository(DatabaseContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<ShoppingCart> GetShoppingCart(string shoppingCartId) => _context.ShoppingCarts.Where(sc => sc.CartId == shoppingCartId).Include(sc => sc.CartItems).ToList();

    }
}