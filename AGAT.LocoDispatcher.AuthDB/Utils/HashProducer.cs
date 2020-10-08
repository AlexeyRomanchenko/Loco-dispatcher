using AGAT.LocoDispatcher.AuthDB.Interfaces;
using System;
using System.Collections.Generic;

namespace AGAT.LocoDispatcher.AuthDB.Utils
{
    internal class HashProducer: IHashProducer, IComparator
    {
        public bool Compare(string incomeString, string hashedString)
        {
            string hashed = HashPassword(incomeString);
            return hashed == incomeString;
        }

        static string HashPassword( string parrword)
        {
            return "";
        }

    }
}
