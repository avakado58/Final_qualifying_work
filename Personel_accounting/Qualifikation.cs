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
    public partial class Qualifikation : Form
    {
        DataSet ds;
        SqlConnection my_conn;
        SqlDataAdapter my_data;
        SqlCommand my_command;

        LoginPage form1 = new LoginPage();
        public Qualifikation(string di, string FIO_employee)
        {
            InitializeComponent();

            this.di = di;
            this.FIO_employee = FIO_employee;

            Loading();
        }
        string di, FIO_employee;
        // кнопка добавить
        private void add_Click(object sender, EventArgs e)
        {
            if (quval.Text == "" || id.Text == "") // Проверка правильности введенных исходных данных
            {
                MessageBox.Show("Проверьте правильность заполнения полей!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); // Вывод сообщения о ошибке
            }
            else
            {
                string commandText = string.Format("INSERT INTO Квалификация ([Код сотрудника], Дата, [Вид квалификации]) VALUES ('{0}', '{1:yyyy.MM.dd}', '{2}')", id.Text, dateTimePicker1.Value, quval.Text); // Cтрока передачи данных

                my_conn = new SqlConnection(form1.connectionString); //Создаем соеденение

                my_command = new SqlCommand(commandText, my_conn);

                my_conn.Open(); // Открытие соединения с базой данных

                my_command.ExecuteNonQuery(); // sql возвращает сколько строк обработано

                MessageBox.Show("Операция выполнена!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information); // Вывод сообщения о добавлении

                my_conn.Close();

                Loading();
            }
        }

        private void Qualifikation_Load(object sender, EventArgs e)
        {
            table.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells; // Автоматическая высота столбцов
            table.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        }
        // удалить квалификацию
        private void delete_Click(object sender, EventArgs e)
        {
            int a = table.CurrentRow.Index; // Выделенная строка в таблице

            string id_table = Convert.ToString(table.Rows[a].Cells[0].Value); // номер строки для удаления

            string sql_delete = string.Format("DELETE FROM Квалификация WHERE ([Код квалификации]) = {0}", id_table); // запрос на удаление в БД

            my_command = new SqlCommand(sql_delete, my_conn);

            my_conn.Open(); // Открытие соединения с базой данных 

            my_command.ExecuteNonQuery(); // sql возвращает сколько строк обработано

            my_conn.Close();

            Loading();

            MessageBox.Show("Операция выполнена!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information); // Вывод сообщения об удалении
        }
        // сохранить изменения
        private void save_Click(object sender, EventArgs e)
        {
            int a = table.CurrentRow.Index; // Выделенная строка в таблице

            string id_table = Convert.ToString(table.Rows[a].Cells[0].Value);

            string strQuery = string.Format("UPDATE Квалификация SET Дата = @param1, [Вид квалификации] = @param2 WHERE [Код квалификации] = {0}", id_table); // Строка передачи данных
            my_command = new SqlCommand(strQuery, my_conn);

            my_conn.Open();

            // Обновление соответствующих столбцов
            my_command.Parameters.AddWithValue("@param1", table.Rows[a].Cells["Дата"].Value);
            my_command.Parameters.AddWithValue("@param2", table.Rows[a].Cells["Вид квалификации"].Value);

            my_command.ExecuteNonQuery();

            my_conn.Close();

            Loading();

            MessageBox.Show("Операция выполнена!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information); // Вывод сообщения об обновлении
        }

        private void search_TextChanged(object sender, EventArgs e)
        {
            ds.Tables[0].DefaultView.RowFilter = "[ФИО сотрудника] LIKE '" + search.Text + "%'"; // Критерий поиска
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

            string sql = "Select p.[Код квалификации], u.ФИО as [ФИО сотрудника], p.Дата, p.[Вид квалификации] " +
                "FROM Квалификация as p JOIN Сотрудник as u ON u.[Код сотрудника] = p.[Код сотрудника] ORDER BY p.[Код квалификации] ASC"; //Sql запрос (достать все из таблицы ...)

            my_data = new SqlDataAdapter(sql, my_conn);//Создаем объект класса DataAdapter (тут мы передаем наш запрос и получаем ответ)

            my_data.Fill(ds, "Квалификация");//Заполняем DataSet cодержимым DataAdapter'a

            table.DataSource = ds.Tables[0].DefaultView;//Заполняем созданный на форме dataGridView1
        }
    }
}
