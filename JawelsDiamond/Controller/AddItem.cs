using JawelsDiamond.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JawelsDiamond.Controller
{
	public class AddItem
	{
        public static string checkItem(string jewelName, string brandIdStr,  string categoryIdStr, string price, string releaseYear)
        {
            if (string.IsNullOrWhiteSpace(jewelName) ||
                string.IsNullOrWhiteSpace(price) ||
                string.IsNullOrWhiteSpace(releaseYear) ||
                brandIdStr.Equals("0") ||
                categoryIdStr.Equals("0"))
            {
                return "All fields are required";
            }
            int brandId = int.Parse(brandIdStr);
            int categoryId = int.Parse(categoryIdStr);

            // Kita lempar semua ke handler
            return JewelsHandler.InsertJewel(jewelName, brandId, categoryId, price, releaseYear);
        }
    }
}