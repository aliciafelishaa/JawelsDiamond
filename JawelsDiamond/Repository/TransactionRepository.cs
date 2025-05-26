using JawelsDiamond.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JawelsDiamond.Repository
{
    public class TransactionRepository
    {
        private static Database1Entities db = new Database1Entities();

        public static List<TransactionHeader> GetUnfinishedTransaction()
        public static List<TransactionHeader> GetUserTransactions(int userId)
        {
            var unfinishedTransactions = (from x in db.TransactionHeaders
                                          where (x.TransactionStatus == "Payment Pending"
                                                    || x.TransactionStatus == "Shipment Pending"
                                                    || x.TransactionStatus == "Arrived")
                                          select x).ToList();


            return unfinishedTransactions;
            return db.TransactionHeaders
                     .Where(t => t.UserID == userId)
                     .ToList();
        }

        public static void UpdateTransactionStatus(int transactionId, string newStatus)
        public static void UpdateTransactionStatus(int transactionId, string status)
        {
            TransactionHeader oldTransaction = db.TransactionHeaders.Find(transactionId);
            if (oldTransaction != null)
            var transaction = db.TransactionHeaders.FirstOrDefault(t => t.TransactionID == transactionId);
            if (transaction != null)
            {
                oldTransaction.TransactionStatus = newStatus;
                transaction.TransactionStatus = status;
                db.SaveChanges();
            }
        }

        public static List<TransactionHeader> GetFinishedTransaction()
        {
            var finishedTransactions = (from x in db.TransactionHeaders where x.TransactionStatus == "Done" select x).ToList();

            return finishedTransactions;
        }
    }
}