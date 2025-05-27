using JawelsDiamond.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JawelsDiamond.Repository
{
    public class TransactionRepository
    {
        //private static Database1Entities db = new Database1Entities();
        private static Database1Entities db = DatabaseSingleton.getInstance();
        public static List<TransactionHeader> GetUnfinishedTransaction()
        {
            var unfinishedTransactions = (from x in db.TransactionHeaders
                                          where (x.TransactionStatus == "Payment Pending"
                                                    || x.TransactionStatus == "Shipment Pending"
                                                    || x.TransactionStatus == "Arrived")
                                          select x).ToList();


            return unfinishedTransactions;
        }

        public static List<TransactionHeader> GetFinishedTransaction()
        {
            var finishedTransactions = (from x in db.TransactionHeaders where x.TransactionStatus == "Done" select x).ToList();

            return finishedTransactions;
        }

        public static List<TransactionHeader> GetUserTransactions(int userId)
        {
            return db.TransactionHeaders
                     .Where(t => t.UserID == userId)
                     .ToList();
        }

        public static void UpdateTransactionStatus(int transactionId, string newStatus)
        {
            TransactionHeader oldTransaction = db.TransactionHeaders.Find(transactionId);
            if (oldTransaction != null)
            {
                oldTransaction.TransactionStatus = newStatus;
                db.SaveChanges();
            }
        }
    }
}