using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Personel_accounting
{
    public partial class LoginPage : Form
    {
        public string connectionString = @"Data Source = DESKTOP-IVMEK9L; Initial Catalog = Personel_accounting; Integrated Security = True"; // Строка соединения
        public LoginPage()
        {
            InitializeComponent();//

            login.Text = "Admin";
            password.Text = "admin";
        }

        private void entrance_Click(object sender, EventArgs e)
        {
            if (login.Text == "Admin" && password.Text == "admin")
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
