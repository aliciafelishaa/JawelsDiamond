using JawelsDiamond.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace JawelsDiamond.Repository
{
	public class JewelsRepository
	{
		private static Database1Entities db = new Database1Entities();

        public static List<MsBrand> GetBrands()
        {
            return (from brands in db.MsBrands select brands).ToList();
        }

        public static List<MsCategory> GetCategories()
        {
            return (from catg in db.MsCategories select catg).ToList();
        }

        public static void InsertJewel(MsJewel jewel)
        {
            db.MsJewels.Add(jewel);
            db.SaveChanges();
        }

        public static List<MsJewel> getJewel()
        {
            return (from jewels in db.MsJewels select jewels).ToList();
        }

        public static MsJewel findJewel(int id)
        {

            //return db.MsJewels.FirstOrDefault(j => j.JewelID == id);
            using (var db = new Database1Entities())
            {
                return db.MsJewels.Include(j => j.MsCategory).Include(j => j.MsBrand).FirstOrDefault(j => j.JewelID == id);
            }
            //return (from jwl_id in db.MsJewels where jwl_id.JewelID == id select jwl_id).FirstOrDefault();
        }

        public static void DeleteJewel(int jewelId)
        {
            var cartItems = db.Carts.Where(c => c.JewelID == jewelId).ToList();
            if (cartItems.Any()) db.Carts.RemoveRange(cartItems);

            var trxDetails = db.TransactionDetails.Where(td => td.JewelID == jewelId).ToList();
            if (trxDetails.Any()) db.TransactionDetails.RemoveRange(trxDetails);

            var jewel = db.MsJewels.Find(jewelId);
            if (jewel != null)
            {
                db.MsJewels.Remove(jewel);
                db.SaveChanges();
            }

        }
        public static void EditJewel(int jewelId)
        {  
            var jewel = db.MsJewels.Find(jewelId);
            if (jewel != null)
            {
                db.SaveChanges();
                
            }
        }

        public static String GetBrandName(int brandId)
        {
            MsBrand brand = db.MsBrands.Find(brandId);
            if (brand != null)
            {
                return brand.BrandName;
            }
            return null;
        }
    }
}