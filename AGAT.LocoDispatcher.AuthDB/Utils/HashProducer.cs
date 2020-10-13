using AGAT.LocoDispatcher.AuthDB.Interfaces;
using System;
using System.Collections.Generic;

namespace AGAT.LocoDispatcher.AuthDB.Utils
{
    public class HashProducer: IComparator
    {
        public bool Compare(string incomeString, string hashedString)
        {
            string hashed = HashPassword(incomeString);
            return hashed == incomeString;
        }

        public static string HashPassword( string password)
        {
            return $"hashed{password}";
        }

    }
}
