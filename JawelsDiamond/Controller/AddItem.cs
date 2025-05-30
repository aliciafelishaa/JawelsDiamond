using JawelsDiamond.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JawelsDiamond.Controller
{
	public class AddItem
	{
        public static string checkItem(string jewelName, string brandIdStr,  string categoryIdStr, string jewelPrice, string jewelReleaseYear)
        {
            if (string.IsNullOrWhiteSpace(jewelName) ||
                string.IsNullOrWhiteSpace(jewelPrice) ||
                string.IsNullOrWhiteSpace(jewelReleaseYear) ||
                brandIdStr.Equals("0") ||
                categoryIdStr.Equals("0"))
            {
                return "All fields are required";
            }

            if (jewelName.Length < 3 || jewelName.Length > 25)
            {
                return "Jewel Name must be between 3 and 25 characters";
            }

            int brandId;
            int categoryId;
            if (!int.TryParse(brandIdStr, out brandId))
            {
                return "Brand ID must be a valid number.";
            }
            if (!int.TryParse(categoryIdStr, out categoryId))
            {
                return "Category ID must be a valid number.";
            }

            // Kita lempar semua ke handler
            return JewelsHandler.InsertJewel(jewelName, brandId, categoryId, jewelPrice, jewelReleaseYear);
        }
    }
}