using System;
using System.Security.Cryptography;
using System.Text;

using System.Windows.Forms;

namespace Personel_accounting
{
    public partial class ChangePassword : Form
    {
        SerializeFunctions serializeFunctions = new SerializeFunctions();
        byte[] bytePassword;
        public ChangePassword()
        {
            InitializeComponent();
            butСhangePassword.Click += ButСhangePassword_Click;
            
        }

        private void ButСhangePassword_Click(object sender, EventArgs e)
        {
            bytePassword = Encoding.ASCII.GetBytes(textOldPassword.Text);
            if (serializeFunctions.GetAccess(serializeFunctions.Deserialize(),"admin", bytePassword ))
            {
                byte[] newBytePassword = Encoding.ASCII.GetBytes(textNewPassword.Text);
                byte[] newHashPassword = new MD5CryptoServiceProvider().ComputeHash(newBytePassword);
                serializeFunctions.Serialize(new Token(newHashPassword, "admin"),true);
                if( MessageBox.Show("Пароль изменён", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information)==DialogResult.OK)
                {
                    this.Close();
                }
                
            }
            else
            {
                MessageBox.Show("Пароли не совпадают", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
