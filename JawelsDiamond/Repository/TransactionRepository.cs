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
        {
            var unfinishedTransactions = (from x in db.TransactionHeaders
                                          where (x.TransactionStatus == "Payment Pending"
                                                    || x.TransactionStatus == "Shipment Pending"
                                                    || x.TransactionStatus == "Arrived")
                                          select x).ToList();


            return unfinishedTransactions;
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

        public static List<TransactionHeader> GetFinishedTransaction()
        {
            var finishedTransactions = (from x in db.TransactionHeaders where x.TransactionStatus == "Done" select x).ToList();

            return finishedTransactions;
        }
    }
}