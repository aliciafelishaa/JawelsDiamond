using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JawelsDiamond.Model;

namespace JawelsDiamond.Repository
{
    public class CartRepository
    {
        private static Database1Entities db = DatabaseSingleton.getInstance();
        public static List<Cart> GetCartItems()
        {
            return (from cart in db.Carts select cart).ToList();
        }
        public static void InsertCart(Cart cart)
        {

            db.Carts.Add(cart);
            db.SaveChanges();
        }
        public static void DeleteCart(int cartId)
        {
            var cartItem = db.Carts.Find(cartId);
            if (cartItem != null)
            {
                db.Carts.Remove(cartItem);
                db.SaveChanges();
            }
        }
        public static Cart FindCart(int id)
        {
            return (from c in db.Carts where c.CartID == id select c).FirstOrDefault();
        }
    }
}