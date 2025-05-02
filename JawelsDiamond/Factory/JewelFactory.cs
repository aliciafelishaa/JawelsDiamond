using JawelsDiamond.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JawelsDiamond.Factory
{
	public class JewelFactory
	{
        public static MsJewel createJewel(string jwlName, int brandId, int catId, int price, int releaseYear)
        {
            return new MsJewel
            {
                JewelName = jwlName,
                BrandID = brandId,
                CategoryID = catId,
                JewelPrice = price,
                JewelReleaseYear = releaseYear
            };
        }
    }
}