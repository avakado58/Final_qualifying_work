using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace QR_Cod_analysis
{
    public partial class Form2 : Form
    {
        DataSet ds;
        SQLiteConnection conn;
        SQLiteDataAdapter da;
        SQLiteCommand Command;
        string surname, name, middle, date;

        static string path = Path.Combine(Directory.GetCurrentDirectory(), "Journal.db");

        public string ConnectionString = @"Data Source=" + path + ";Version=3; New=True;Compress=True;";
        public Form2(string surname, string name, string middle, string date)
        {
            InitializeComponent();

            this.surname = surname;
            this.name = name;
            this.middle = middle;
            this.date = date;

            label_surname.Text = surname;
            label_name.Text = name;
            label_middle.Text = middle;
            label_date.Text = date;

            conn = new SQLiteConnection(ConnectionString); //Создаем соеденение

            string CommandText = string.Format("SELECT * FROM journal WHERE [Фамилия] ='{0}'", surname);
            conn.Open();
            Command = new SQLiteCommand(CommandText, conn);

            SQLiteDataReader r = Command.ExecuteReader();
            r.Read();
            MemoryStream stmBLOBData = new MemoryStream((byte[])r[4]);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Image = Image.FromStream(stmBLOBData);
            pictureBox1.Refresh();
            r.Close();
            r.Dispose();
            conn.Close();
        }
        
    }
}
