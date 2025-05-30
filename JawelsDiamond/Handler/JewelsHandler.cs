using JawelsDiamond.Factory;
using JawelsDiamond.Model;
using JawelsDiamond.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JawelsDiamond.Handler
{
	public class JewelsHandler
	{

		public static string InsertJewel(string jName, int brandId, int categoryId, string jewelPrice, string jewelReleaseYear)
		{
            if (!int.TryParse(jewelPrice, out int price))
            {
                return "Price must be a valid number."; // Jika parsing gagal, ini adalah business logic error
            }
            if (price <= 25)
            {
                return "Price must be a number more than $25";
            }

            if (!int.TryParse(jewelReleaseYear, out int releaseYear))
            {
                return "Release Year must be a valid number."; // Jika parsing gagal, ini adalah business logic error
            }
            if (releaseYear >= DateTime.Now.Year)
            {
                return "Release Year must be a number and less than current year";
            }
            var jewel = JewelFactory.createJewel(jName, brandId, categoryId, price, releaseYear);
            JewelsRepository.InsertJewel(jewel);
            return "Success Add Items!";
		}

        public static string UpdateJewels(string jName, int brandId, int categoryId, string jPrice, string jReleaseYear)
        {
            if (!int.TryParse(jPrice, out int price))
            {
                return "Price must be a valid number."; 
            }
            if (price <= 25)
            {
                return "Price must be a number more than $25";
            }

            if (!int.TryParse(jReleaseYear, out int releaseYear))
            {
                return "Release Year must be a valid number.";
            }
            if (releaseYear >= DateTime.Now.Year)
            {
                return "Release Year must be a number and less than current year";
            }

            var jewel = JewelFactory.createJewel(jName, brandId, categoryId, price, releaseYear);
            return "Success Edit Items!";
        }
    }
}