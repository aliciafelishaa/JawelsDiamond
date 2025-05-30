using JawelsDiamond.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JawelsDiamond.Controller
{
	public class UpdateItem
	{
        public static string checkItem(string jewelName, string brandIdStr, string categoryIdStr, string price, string releaseYear)
        {
            if (string.IsNullOrWhiteSpace(jewelName) ||
                string.IsNullOrWhiteSpace(price) ||
                string.IsNullOrWhiteSpace(releaseYear) ||
                brandIdStr.Equals("0") ||
                categoryIdStr.Equals("0"))
            {
                return "All fields are required";
            }
            if ( jewelName.Length < 3 || jewelName.Length > 25)
            {
                return "Jewel Name must be between 3 and 25 characters";
            }
            int brandIdParse;
            int categoryIdParse;
            if (!int.TryParse(brandIdStr, out brandIdParse))
            {
                return "Brand ID must be a valid number.";
            }
            if (!int.TryParse(categoryIdStr, out categoryIdParse))
            {
                return "Category ID must be a valid number.";
            }

            // Kita lempar semua ke handler
            return JewelsHandler.UpdateJewels(jewelName, brandIdParse, categoryIdParse, price, releaseYear);
        }
    }
}