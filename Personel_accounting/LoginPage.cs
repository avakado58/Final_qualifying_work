using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Personel_accounting
{
    public partial class LoginPage : Form
    {
        public string connectionString = @"Data Source = DESKTOP-IVMEK9L; Initial Catalog = Personel_accounting; Integrated Security = True"; // Строка соединения
        byte[] hashPassword;
        byte[] bytePassword;
        Token token = null;
        SerializeFunctions serializeFunctions = new SerializeFunctions();
        public LoginPage()
        {
            InitializeComponent();

            login.Text = "admin";
            password.Text = "admin";
            
         

            
        }
        
        private void entrance_Click(object sender, EventArgs e)
        {
            bytePassword = Encoding.ASCII.GetBytes(password.Text);
            try
            {
                token = serializeFunctions.Deserialize();
            }
            catch (FileNotFoundException)
            {
                hashPassword = new MD5CryptoServiceProvider().ComputeHash(bytePassword);
                token = new Token(hashPassword, login.Text);
                serializeFunctions.Serialize(token);
            }

            if (serializeFunctions.GetAccess(token, login.Text, bytePassword))
            {
                Admin a = new Admin(connectionString);
                this.Hide();
                a.ShowDialog();
                this.Show();
            }      
            else
            {
                MessageBox.Show("Проверьте данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        
    }
}
