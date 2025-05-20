using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JawelsDiamond.Model;

namespace JawelsDiamond.Factory
{
    public class CartFactory
    {
        public Cart CreateNewCartItem(int jewelId, int userId, int quantity)
        {
            Cart newCartItem = new Cart();
            newCartItem.JewelID = jewelId;
            newCartItem.UserID = userId;
            newCartItem.Quantity = quantity;
            return newCartItem;
        }
    }
}