using JawelsDiamond.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JawelsDiamond.Repository
{
    public class TransactionRepository
    {
        private static Database1Entities db = new Database1Entities();

        public static List<TransactionHeader> GetUserTransactions(int userId)
        {
            return db.TransactionHeaders
                     .Where(t => t.UserID == userId)
                     .ToList();
        }

        public static void UpdateTransactionStatus(int transactionId, string status)
        {
            var transaction = db.TransactionHeaders.FirstOrDefault(t => t.TransactionID == transactionId);
            if (transaction != null)
            {
                transaction.TransactionStatus = status;
                db.SaveChanges();
            }
        }
    }
}
