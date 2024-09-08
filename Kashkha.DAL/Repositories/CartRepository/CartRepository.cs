using Kashkha.DAL.Models;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Kashkha.DAL
{
    public class CartRepository : ICartRepository
    {
        private readonly IDatabase _database;

        public CartRepository(IConnectionMultiplexer redis)
        {
            _database = redis.GetDatabase();

        }
        public async Task<bool> DeleteCart(string cartId)
        {
            return await _database.KeyDeleteAsync(cartId);
        }

        public async Task<Cart?> GetCartAsync(string id)
        {
            var cart = await _database.StringGetAsync(id);

            //Deserialize=> from JSON to Cart Object

            return cart.IsNull ? null : JsonSerializer.Deserialize<Cart>(cart);


        }


        //wil be used in create or update the cart
        public async Task<Cart?> UpdateCart(Cart cart)
        {
            var myCart = JsonSerializer.Serialize(cart); // from Cart Obj to JSON
            var CreatedOrUpdated = await _database.StringSetAsync(cart.Id, myCart, TimeSpan.FromDays(3));

            if (!CreatedOrUpdated) return null;

            return await GetCartAsync(cart.Id);
        }
    }
}
