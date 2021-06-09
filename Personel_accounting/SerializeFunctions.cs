using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;

namespace Personel_accounting
{
    class SerializeFunctions
    {
        public SerializeFunctions()
        {

        }
        public void Serialize(Token token)
        {

            using (FileStream file = new FileStream(System.AppDomain.CurrentDomain.BaseDirectory + "Setings.bin", FileMode.OpenOrCreate))
            {
                var binFormater = new BinaryFormatter();
                binFormater.Serialize(file, token);
            }
        }
        public void Serialize(Token token, bool create )
        {
            using (FileStream file = new FileStream(System.AppDomain.CurrentDomain.BaseDirectory + "Setings.bin", FileMode.Create))
            {
                var binFormater = new BinaryFormatter();
                binFormater.Serialize(file, token);
            }
        }
        public Token Deserialize()
        {
            Token deserializeToken;
            using (FileStream file = new FileStream(System.AppDomain.CurrentDomain.BaseDirectory + "Setings.bin", FileMode.Open))
            {
                var binFormater = new BinaryFormatter();
                deserializeToken = binFormater.Deserialize(file) as Token;
            }
            return deserializeToken;
        }

        public bool GetAccess(Token token, string login, byte[] bytePassword)
        {
            byte[] tmpHash = token.password;
            byte[] tmpNewHash = new MD5CryptoServiceProvider().ComputeHash(bytePassword);

            if (tmpNewHash.Length == token.password.Length)
            {
                int i = 0;
                while ((i < tmpNewHash.Length) && (tmpNewHash[i] == tmpHash[i]))
                {
                    i += 1;
                }
                if (i == tmpNewHash.Length && login == token.login)
                {
                    return true;
                }
            }

            return false;
        }

    }
}
