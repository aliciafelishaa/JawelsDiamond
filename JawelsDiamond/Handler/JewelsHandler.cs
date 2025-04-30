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

		public static string InsertJewel(string jName, int brandId, int categoryId, string jPrice, string jReleaseYear)
		{
            if (string.IsNullOrWhiteSpace(jName) || jName.Length < 3 || jName.Length > 25)
            {
                return "Jewel Name must be between 3 and 25 characters";
            }
            if (!int.TryParse(jPrice, out int price) || price <= 25)
            {
                return "Price must be a number more than $25";
            }
            if (!int.TryParse(jReleaseYear, out int releaseYear) || releaseYear >= DateTime.Now.Year)
            {
                return "Release Year must be a number and less than current year";
            }

            var jewel = JewelFactory.createJewel(jName, brandId, categoryId, price, releaseYear);
            JewelsRepository.InsertJewel(jewel);
            return "Success Add Items!";
			
		}
	}
}