using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JawelsDiamond.Model;

namespace JawelsDiamond.Repository
{
    public class CartRepository
    {
        //private static Database1Entities db = DatabaseSingleton.getInstance();
        private static Database1Entities db = new Database1Entities();
        public static List<Cart> GetCartItems(int userId)
        {
            using (var db = new Database1Entities())
            {
                var list = db.Carts
                             .AsNoTracking()
                             .Where(c => c.UserID == userId)
                             .ToList();

                foreach (var item in list)
                {
                    System.Diagnostics.Debug.WriteLine($"Fetched from DB - UserID: {item.UserID}, JewelID: {item.JewelID}, Quantity: {item.Quantity}");
                }

                return list;
            }
        }
        public static void AddToCart(int userId, int jewelId, int quantity)
        {
            using (Database1Entities db = new Database1Entities())
            {
                Cart cartItem = db.Carts.FirstOrDefault(c => c.UserID == userId && c.JewelID == jewelId);
                    
                if (cartItem != null)
                {   
                    cartItem.Quantity += quantity;
                }
                else
                {
                 
                   Cart newItem = new Cart
                   {
                       UserID = userId,
                       JewelID = jewelId,
                       Quantity = quantity
                   };
                    db.Carts.Add(newItem);
                }

                db.SaveChanges();
            }

        }

        public static void DeleteCartItem(int userId, int jewelId)
        {
            using (Database1Entities db = new Database1Entities())
            {
                // Fetch the cart item based on both userId and jewelId
                Cart cartItem = db.Carts
                                  .Where(c => c.UserID == userId && c.JewelID == jewelId)
                                  .FirstOrDefault();  // Ensure it's a single match

                if (cartItem != null)
                {
                    System.Diagnostics.Debug.WriteLine($"Deleting Cart Item: UserID = {cartItem.UserID}, JewelID = {cartItem.JewelID}");

                    // Remove the cart item only if it's the correct one
                    db.Carts.Remove(cartItem);
                    db.SaveChanges();
                }
            }
        }

        public static void UpdateCart(int userId, int jewelId, int quantity)
        {
            using (Database1Entities db = new Database1Entities())
            {
                Cart cartItem = db.Carts.FirstOrDefault(c => c.UserID == userId && c.JewelID == jewelId);

                if (cartItem != null)
                {
                    cartItem.Quantity = quantity;
                    db.SaveChanges();
                }
            }
        }
        //public static Cart FindCart(int id)
        //{
        //    return (from c in db.Carts where c.CartID == id select c).FirstOrDefault();
        //}
    }
}