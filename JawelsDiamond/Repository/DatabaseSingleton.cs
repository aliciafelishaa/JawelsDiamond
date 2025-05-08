using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JawelsDiamond.Model;

namespace JawelsDiamond.Repository
{
    public class DatabaseSingleton
    {
        private static Database1Entities db;

        public static Database1Entities getInstance()
        {
            if(db == null)
            {
                db = new Database1Entities();
            }

            return db;
        }
    }

}
