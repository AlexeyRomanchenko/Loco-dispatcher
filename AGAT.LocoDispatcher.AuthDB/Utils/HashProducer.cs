using AGAT.LocoDispatcher.AuthDB.Interfaces;

namespace AGAT.LocoDispatcher.AuthDB.Utils
{
    public class HashProducer: IComparator
    {
        private static string GetRandomSalt()
        {
            return BCrypt.Net.BCrypt.GenerateSalt(12);
        }

        public bool Compare(string password, string hashedString)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedString);
        }

        public static string HashPassword( string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, GetRandomSalt());
        }

    }
}
