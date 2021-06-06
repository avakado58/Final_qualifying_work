using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Personel_accounting
{
    public partial class Dismissal : Form
    {
        DataSet ds;
        SqlConnection my_conn;
        SqlDataAdapter my_data;
        SqlCommand my_command, my_command_1;

        LoginPage form1 = new LoginPage();
        public Dismissal(string di, string FIO_employee)
        {
            InitializeComponent();

            this.di = di;
            this.FIO_employee = FIO_employee;

            Loading();
        }
        string di, FIO_employee;

        private void Dismissal_Load(object sender, EventArgs e)
        {
            table.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells; // Автоматическая высота столбцов
            table.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        }

        private void add_Click(object sender, EventArgs e)
        {
            if (quval.Text == "" || id.Text == "" || number.Text == "") // Проверка правильности введенных исходных данных
            {
                MessageBox.Show("Проверьте правильность заполнения полей!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); // Вывод сообщения о ошибке
            }
            else
            {
                string commandText = string.Format("INSERT INTO Увольнение (ФИО, [Дата увольнения], Причина, [Номер приказа]) VALUES ('{0}', '{1:yyyy.MM.dd}', '{2}', '{3}')", FIO.Text, dateTimePicker1.Value, quval.Text, number.Text); // Cтрока передачи данных

                my_conn = new SqlConnection(form1.connectionString); //Создаем соеденение

                my_conn.Open(); // Открытие соединения с базой данных

                my_command = new SqlCommand(commandText, my_conn);

                my_command.ExecuteNonQuery(); // sql возвращает сколько строк обработано

                string strQuery = string.Format("DELETE FROM Сотрудник WHERE ([Код сотрудника]) = {0}", id.Text); // запрос на удаление в БД

                my_command_1 = new SqlCommand(strQuery, my_conn);

                my_command_1.ExecuteNonQuery(); // sql возвращает сколько строк обработано


                MessageBox.Show("Операция выполнена!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information); // Вывод сообщения о добавлении

                my_conn.Close();

                Loading();
            }
        }

        public void Loading()
        {
            id.Text = di;
            FIO.Text = FIO_employee;
            // Настройки таблицы

            table.ColumnHeadersDefaultCellStyle.Font = new Font(table.ColumnHeadersDefaultCellStyle.Font.FontFamily, 11, FontStyle.Bold); // Шрифт и размер названий столбцов
            table.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // выравнивание названий столбцов по центру

            table.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;// выравнивание строк по центру
            table.DefaultCellStyle.Font = new Font("Times New Roman", 11); // Шрифт и размер строк

            ds = new DataSet(); //Создаем объект класса DataSet

            my_conn = new SqlConnection(form1.connectionString); //Создаем соеденение

            string sql = "Select * " +
                "FROM Увольнение ORDER BY [Код увольнения] ASC"; //Sql запрос (достать все из таблицы ...)

            my_data = new SqlDataAdapter(sql, my_conn);//Создаем объект класса DataAdapter (тут мы передаем наш запрос и получаем ответ)

            my_data.Fill(ds, "Увольнение");//Заполняем DataSet cодержимым DataAdapter'a

            table.DataSource = ds.Tables[0].DefaultView;//Заполняем созданный на форме dataGridView1
        }
    }
}
