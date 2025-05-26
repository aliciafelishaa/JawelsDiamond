using JawelsDiamond.Model;
using JawelsDiamond.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JawelsDiamond.Handler
{
    public class TransactionHandlers
    {
        public static List<TransactionHeader> GetData()
        {
            return TransactionRepository.GetFinishedTransaction();
        }
    }
}