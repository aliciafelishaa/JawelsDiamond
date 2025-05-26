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

        // Fungsi milik temen kamu
        public static List<TransactionHeader> GetUnfinishedTransaction()
        {
            return db.TransactionHeaders
                .Where(x => x.TransactionStatus == "Payment Pending"
                         || x.TransactionStatus == "Shipment Pending"
                         || x.TransactionStatus == "Arrived")
                .ToList();
        }

        public static List<TransactionHeader> GetFinishedTransaction()
        {
            return db.TransactionHeaders
                .Where(x => x.TransactionStatus == "Done")
                .ToList();
        }

        // Fungsi milik kamu
        public static List<TransactionHeader> GetUserTransactions(int userId)
        {
            return db.TransactionHeaders
                     .Where(t => t.UserID == userId)
                     .ToList();
        }

        public static void UpdateTransactionStatus(int transactionId, string newStatus)
        {
            var transaction = db.TransactionHeaders.Find(transactionId);
            if (transaction != null)
            {
                transaction.TransactionStatus = newStatus;
                db.SaveChanges();
            }
        }
    }
}