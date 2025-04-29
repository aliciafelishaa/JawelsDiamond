using JawelsDiamond.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JawelsDiamond.Repository
{
	public class JewelsRepository
	{
		private static Database1Entities db = new Database1Entities();

        public static List<MsJewel> getJewel()
        {
            return (from jewels in db.MsJewels select jewels).ToList();
        }

        public static MsJewel findJewel(int id)
        {
            return (from jwl_id in db.MsJewels where jwl_id.JewelID == id select jwl_id).FirstOrDefault();
        }
    }
}