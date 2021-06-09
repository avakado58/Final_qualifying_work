using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Personel_accounting
{
    [Serializable]
    public class Token
    {

        public byte[] password = null;
        public string login = null;
        public Token(byte[] password, string login)
        {
            this.password = password;
            this.login = login;
        }
        

    }
}
